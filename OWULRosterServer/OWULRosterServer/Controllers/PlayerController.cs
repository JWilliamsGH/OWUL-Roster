using OWULRosterServer.Models;
using OWULRosterServer.Repositories;
using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OWULRoster.Controllers
{
    public class PlayerController : Controller
    {
        #region MVC ACTIONS

        public ActionResult Index(int? teamId)
        {
            // If this were larger, we'd need pagination
            var players = PlayerRepository.GetPlayers(teamId).Take(100).ToList();
            return View(players);
        }

        public ActionResult Details(int playerId)
        {
            var player = PlayerRepository.GetPlayerDetails(playerId).SingleOrDefault();
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
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    PlayerRepository.InsertPlayer(model);
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
            var player = PlayerRepository.GetPlayerDetails(playerId).SingleOrDefault();
            PopulateTeamsSelect(player);
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(PlayerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GetUploadedImage(model);
                    PlayerRepository.UpdatePlayer(model);
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
            var player = PlayerRepository.GetPlayerDetails(playerId).SingleOrDefault();
            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(PlayerModel model)
        {
            try
            {
                PlayerRepository.DeletePlayer(model);
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
            var players = PlayerRepository.GetPlayers(null).Take(100).ToArray();
            return Json(new { players = players }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTeamPlayers(int TeamId)
        {
            var players = PlayerRepository.GetPlayers(TeamId).Take(100).ToArray();
            return Json(new { players = players }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SavePlayer()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PRIVATE METHODS

        private void PopulateTeamsSelect(PlayerModel model)
        {
            PlayerRepository.GetTeamSelectList(model);
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