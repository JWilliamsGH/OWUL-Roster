using Newtonsoft.Json;
using OWULRosterServer.Models;
using OWULRosterServer.Utils;
using System.Linq;
using System.Web.Mvc;

namespace OWULRoster.Controllers
{
    public class PlayerController : Controller
    {
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
    }
}