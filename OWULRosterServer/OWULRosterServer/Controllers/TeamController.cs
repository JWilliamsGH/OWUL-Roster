using Newtonsoft.Json;
using OWULRosterServer.Models;
using System.Linq;
using System.Web.Mvc;
using OWULRosterServer.Utils;
using System.Collections.Generic;
using System.Web.Helpers;
using System;

namespace OWULRoster.Controllers
{
    public class TeamController : Controller
    {
        #region MVC ACTIONS

        public ActionResult Index()
        {
            var context = new RosterDBDataContext();
            var teams = (from t in context.Teams
                         orderby t.TeamId
                         select new TeamModel
                         {
                             TeamId = t.TeamId,
                             Name = t.Name,
                             Avatar = t.Avatar,
                             Score = t.Score,
                             Wins = t.Wins,
                             Losses = t.Losses,
                             Ties = t.Ties
                         }).ToList();

            return View(teams);
        }

        public ActionResult Create()
        {
            var model = new TeamModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TeamModel model)
        {
            var context = new RosterDBDataContext();
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    var team = new Team()
                    {
                        Name = model.Name,
                        Avatar = model.Avatar,
                        Wins = model.Wins,
                        Losses = model.Losses,
                        Ties = model.Ties,
                        Score = model.Score
                    };
                    context.Teams.InsertOnSubmit(team);
                    context.SubmitChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }

            }
            return View(model);
        }

        public ActionResult Details(int teamId)
        {
            var context = new RosterDBDataContext();
            var team = (from t in context.Teams
                        where t.TeamId == teamId
                        select new TeamModel()
                        {
                            TeamId = t.TeamId,
                            Name = t.Name,
                            Avatar = t.Avatar,
                            Score = t.Score,
                            Wins = t.Wins,
                            Losses = t.Losses,
                            Ties = t.Ties,
                            Players = (from p in context.Players
                                       where p.TeamId == t.TeamId
                                       select new TeamDetailsPlayerModel()
                                       {
                                           PlayerId = p.PlayerId,
                                           Name = p.Name,
                                           SkillRating = p.SkillRating,
                                           AverageKills = p.AverageKills,
                                           AverageDeaths = p.AverageDeaths,
                                           AverageAssists = p.AverageAssists
                                       })
                        }).SingleOrDefault();

            return View(team);
        }

        public ActionResult Edit(int teamId)
        {
            var context = new RosterDBDataContext();
            var team = (from t in context.Teams
                        where t.TeamId == teamId
                        select new TeamModel()
                        {
                            TeamId = t.TeamId,
                            Name = t.Name,
                            Avatar = t.Avatar,
                            Score = t.Score,
                            Wins = t.Wins,
                            Losses = t.Losses,
                            Ties = t.Ties
                        }).SingleOrDefault();

            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(TeamModel model)
        {
            var context = new RosterDBDataContext();
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    var team = context.Teams.Where(p => p.TeamId == model.TeamId).Single<Team>();
                    team.Name = model.Name;
                    if (!string.IsNullOrEmpty(model.Avatar)) team.Avatar = model.Avatar;
                    team.Score = model.Score;
                    team.Wins = model.Wins;
                    team.Losses = model.Losses;
                    team.Ties = model.Ties;
                    context.SubmitChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult Delete(int teamId)
        {
            var context = new RosterDBDataContext();
            var team = (from t in context.Teams
                        where t.TeamId == teamId
                        select new TeamModel()
                        {
                            TeamId = t.TeamId,
                            Name = t.Name,
                            Avatar = t.Avatar,
                            Score = t.Score,
                            Wins = t.Wins,
                            Losses = t.Losses,
                            Ties = t.Ties
                        }).SingleOrDefault();

            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(TeamModel model)
        {
            var context = new RosterDBDataContext();
            try
            {
                var team = context.Teams.Where(p => p.TeamId == model.TeamId).Single<Team>();
                context.Teams.DeleteOnSubmit(team);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // This is a bit of a hack.
                // The Delete POST is just passing in an 'int teamId' and nothing else but that is the signature for the GET method
                // There were two options that I saw, #1) pass the model every delete attempt or 
                // #2) retrieve the model a second time if something went wrong. I opted for #2.
                return Delete(model.TeamId);
            }
        }

        #endregion

        #region API METHODS

        public JsonResult GetTeams()
        {
            var context = new RosterDBDataContext();
            var teams = (from t in context.Teams
                         orderby t.TeamId
                         select new
                         {
                             TeamId = t.TeamId,
                             Name = t.Name,
                             Avatar = t.Avatar
                         }).Take(100).ToList(); // TODO: A real world scenario would need pagination

            return Json(new { teams = teams }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeamDetails(int teamId)
        {
            var context = new RosterDBDataContext();
            var team = (from t in context.Teams
                        where t.TeamId == teamId
                        select new
                        {
                            TeamId = t.TeamId,
                            Name = t.Name,
                            Avatar = t.Avatar,
                            Score = t.Score,
                            Wins = t.Wins,
                            Losses = t.Losses,
                            Ties = t.Ties
                        }).FirstOrDefault();

            return Json(new { team = team }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region PRIVATE METHODS

        private static void GetUploadedImage(TeamModel model)
        {
            var avatarImage = WebImage.GetImageFromRequest();
            if (avatarImage != null)
            {
                model.Avatar = Guid.NewGuid().ToString() + "_" + avatarImage.FileName;
                avatarImage.Save(@"~\Content\Images\" + model.Avatar);
            }
        }

        #endregion
    }
}