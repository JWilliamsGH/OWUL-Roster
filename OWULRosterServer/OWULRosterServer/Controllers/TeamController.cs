using Newtonsoft.Json;
using OWULRosterServer.Models;
using System.Linq;
using System.Web.Mvc;
using OWULRosterServer.Utils;
using System.Collections.Generic;
using System.Web.Helpers;
using System;
using OWULRosterServer.Repositories;

namespace OWULRoster.Controllers
{
    public class TeamController : Controller
    {
        #region MVC ACTIONS

        public ActionResult Index()
        {
            var teams = TeamRepository.GetTeams().ToList();
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
                    GetUploadedImage(model);
                    TeamRepository.InsertTeam(model);
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
            var team = TeamRepository.GetTeamDetailsWithPlayers(teamId).SingleOrDefault();
            return View(team);
        }

        public ActionResult Edit(int teamId)
        {
            var team = TeamRepository.GetTeamDetails(teamId).SingleOrDefault();
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    TeamRepository.UpdateTeam(model);
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
            var team = TeamRepository.GetTeamDetails(teamId).SingleOrDefault();
            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(TeamModel model)
        {
            try
            {
                TeamRepository.DeleteTeam(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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
            var teams = TeamRepository.GetTeams().ToList(); // TODO: A real world scenario would need pagination
            return Json(new { teams = teams }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeamDetails(int teamId)
        {
            var team = TeamRepository.GetTeamDetails(teamId).SingleOrDefault();
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