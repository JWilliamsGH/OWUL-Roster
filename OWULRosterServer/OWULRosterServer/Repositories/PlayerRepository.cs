using OWULRosterServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWULRosterServer.Repositories
{
    public class PlayerRepository
    {
        public static IQueryable<PlayerModel> GetPlayers(int? teamId)
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
                           });
            return players;
        }

        public static IQueryable<PlayerModel> GetPlayerDetails(int playerId)
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
                          });
            return player;
        }

        public static void GetTeamSelectList(PlayerModel model)
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

        public static void InsertPlayer(PlayerModel model)
        {
            var context = new RosterDBDataContext();
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
        }

        public static void UpdatePlayer(PlayerModel model)
        {
            var context = new RosterDBDataContext();
            var player = context.Players.Where(p => p.PlayerId == model.PlayerId).Single();
            player.Name = model.Name;
            player.BNetTag = model.BNetTag;
            if (!string.IsNullOrEmpty(model.Avatar)) player.Avatar = model.Avatar;
            player.TeamId = model.TeamId;
            player.SkillRating = model.SkillRating;
            player.AverageKills = model.AverageKills;
            player.AverageDeaths = model.AverageDeaths;
            player.AverageAssists = model.AverageAssists;
            context.SubmitChanges();
        }

        public static void DeletePlayer(PlayerModel model)
        {
            var context = new RosterDBDataContext();
            var player = context.Players.Where(p => p.PlayerId == model.PlayerId).Single();
            context.Players.DeleteOnSubmit(player);
            context.SubmitChanges();
        }
    }
}