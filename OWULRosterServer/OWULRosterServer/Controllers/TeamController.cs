using Newtonsoft.Json;
using OWULRosterServer.Models;
using System.Linq;
using System.Web.Mvc;
using OWULRosterServer.Utils;
using System.Collections.Generic;

namespace OWULRoster.Controllers
{
    public class TeamController : Controller
    {
        private RosterDBDataContext context;

        public TeamController()
        {
            context = new RosterDBDataContext();
        }

        public ActionResult Index()
        {
            var context = new RosterDBDataContext();
            var teams = (from t in context.Teams
                         orderby t.TeamId
                         select new
                         {
                             TeamId = t.TeamId,
                             Name = t.Name,
                             Avatar = t.Avatar
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
            if (ModelState.IsValid)
            {
                try
                {
                    var team = new Team()
                    {
                        Name = model.Name,
                        Avatar = model.Avatar,
                        Wins = model.Wins,
                        Losses = model.Losses,
                        Ties = model.Ties,
                        Score = 0
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
    }
}