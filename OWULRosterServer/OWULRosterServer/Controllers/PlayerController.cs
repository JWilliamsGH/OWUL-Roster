using Newtonsoft.Json;
using OWULRosterServer.Models;
using OWULRosterServer.Utils;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OWULRoster.Controllers
{
    public class PlayerController : Controller
    {
        #region MVC ACTIONS

        public ActionResult Index(int? teamId)
        {
            var context = new RosterDBDataContext();
            var players = (from p in context.Players
                           where teamId == null || p.TeamId == teamId
                           orderby p.PlayerId
                           select new PlayerModel()
                           {
                               PlayerId = p.PlayerId,
                               Name = p.Name,
                               BNetTag = p.BNetTag,
                               Avatar = p.Avatar,
                               TeamName = p.Team.Name,
                               SkillRating = p.SkillRating,
                               AverageKills = p.AverageKills,
                               AverageDeaths = p.AverageDeaths,
                               AverageAssists = p.AverageAssists,
                               TeamId = p.TeamId.Value
                           }).Take(100).ToArray();

            return View(players);
        }

        public ActionResult Details(int playerId)
        {
            var context = new RosterDBDataContext();
            var player = (from p in context.Players
                          where p.PlayerId == playerId
                          select new PlayerModel()
                          {
                              PlayerId = p.PlayerId,
                              Name = p.Name,
                              BNetTag = p.BNetTag,
                              Avatar = p.Avatar,
                              TeamName = p.Team.Name,
                              SkillRating = p.SkillRating,
                              AverageKills = p.AverageKills,
                              AverageDeaths = p.AverageDeaths,
                              AverageAssists = p.AverageAssists,
                              TeamId = p.TeamId.Value
                          }).SingleOrDefault();

            return View(player);
        }

        public ActionResult Create()
        {
            var model = new PlayerModel();
            PopulateTeamsSelect(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PlayerModel model)
        {
            var context = new RosterDBDataContext();
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    var player = new Player()
                    {
                        PlayerId = model.PlayerId,
                        Name = model.Name,
                        BNetTag = model.BNetTag,
                        Avatar = model.Avatar,
                        TeamId = model.TeamId,
                        SkillRating = model.SkillRating,
                        AverageKills = model.AverageKills,
                        AverageDeaths = model.AverageDeaths,
                        AverageAssists = model.AverageAssists
                    };

                    context.Players.InsertOnSubmit(player);
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

        public ActionResult Edit(int playerId)
        {
            var context = new RosterDBDataContext();
            var player = (from p in context.Players
                          where p.PlayerId == playerId
                          select new PlayerModel()
                          {
                              PlayerId = p.PlayerId,
                              Name = p.Name,
                              BNetTag = p.BNetTag,
                              Avatar = p.Avatar,
                              TeamName = p.Team.Name,
                              SkillRating = p.SkillRating,
                              AverageKills = p.AverageKills,
                              AverageDeaths = p.AverageDeaths,
                              AverageAssists = p.AverageAssists
                          }).SingleOrDefault();

            PopulateTeamsSelect(player);
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(PlayerModel model)
        {
            var context = new RosterDBDataContext();
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    var player = context.Players.Where(p => p.PlayerId == model.PlayerId).Single<Player>();
                    player.Name = model.Name;
                    player.BNetTag = model.BNetTag;
                    if(!string.IsNullOrEmpty(model.Avatar)) player.Avatar = model.Avatar;
                    player.TeamId = model.TeamId;
                    player.SkillRating = model.SkillRating;
                    player.AverageKills = model.AverageKills;
                    player.AverageDeaths = model.AverageDeaths;
                    player.AverageAssists = model.AverageAssists;
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

        public ActionResult Delete(int playerId)
        {
            var context = new RosterDBDataContext();
            var player = (from p in context.Players
                          where p.PlayerId == playerId
                          select new PlayerModel()
                          {
                              PlayerId = p.PlayerId,
                              Name = p.Name,
                              BNetTag = p.BNetTag,
                              Avatar = p.Avatar,
                              TeamName = p.Team.Name,
                              SkillRating = p.SkillRating,
                              AverageKills = p.AverageKills,
                              AverageDeaths = p.AverageDeaths,
                              AverageAssists = p.AverageAssists
                          }).SingleOrDefault();

            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(PlayerModel model)
        {
            var context = new RosterDBDataContext();
            try
            {
                var player = context.Players.Where(p => p.PlayerId == model.PlayerId).Single<Player>();
                context.Players.DeleteOnSubmit(player);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // This is a bit of a hack.
                // The Delete POST is just passing in an 'int playerId' and nothing else but that is the signature for the GET method
                // There were two options that I saw, #1) pass the model every delete attempt or 
                // #2) retrieve the model a second time if something went wrong. I opted for #2.
                return Delete(model.PlayerId);
            }
        }

        #endregion

        #region API METHODS

        [HttpGet]
        public JsonResult GetPlayers()
        {
            var context = new RosterDBDataContext();
            var playersResults = (from p in context.Players
                                  orderby p.PlayerId
                                  select new
                                  {
                                      PlayerId = p.PlayerId,
                                      Name = p.Name,
                                      BNetTag = p.BNetTag,
                                      Avatar = p.Avatar,
                                      SkillRating = p.SkillRating,
                                      AverageKills = p.AverageKills,
                                      AverageDeaths = p.AverageDeaths,
                                      AverageAssists = p.AverageAssists
                                  }).Take(100).ToArray();

            return Json(new { players = playersResults }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTeamPlayers(int TeamId)
        {
            var context = new RosterDBDataContext();
            var playersResults = (from p in context.Players
                                  where p.TeamId == TeamId
                                  orderby p.PlayerId
                                  select new
                                  {
                                      PlayerId = p.PlayerId,
                                      Name = p.Name,
                                      BNetTag = p.BNetTag,
                                      Avatar = p.Avatar,
                                      SkillRating = p.SkillRating,
                                      AverageKills = p.AverageKills,
                                      AverageDeaths = p.AverageDeaths,
                                      AverageAssists = p.AverageAssists
                                  }).Take(100).ToArray();

            return Json(new { players = playersResults }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SavePlayer()
        {
            return null;
        }

        #endregion

        #region PRIVATE METHODS

        private void PopulateTeamsSelect(PlayerModel model)
        {
            var context = new RosterDBDataContext();
            model.Teams = context.Teams.AsQueryable<Team>().Select(x =>
            new SelectListItem()
            {
                Text = x.Name,
                Value = x.TeamId.ToString(),
                Selected = (x.TeamId == model.TeamId)
            });
        }

        private static void GetUploadedImage(PlayerModel model)
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