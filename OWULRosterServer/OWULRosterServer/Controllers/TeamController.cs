using Newtonsoft.Json;
using OWULRosterServer.Models;
using System.Linq;
using System.Web.Mvc;
using OWULRosterServer.Utils;

namespace OWULRoster.Controllers
{
    public class TeamController : Controller
    {
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
                         }).Take(100).ToList();

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