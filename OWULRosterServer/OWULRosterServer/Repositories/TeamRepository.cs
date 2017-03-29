using OWULRosterServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWULRosterServer.Repositories
{
    public class TeamRepository
    {
        public static IQueryable<TeamModel> GetTeams()
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
                         });
            return teams;
        }

        public static void InsertTeam(TeamModel model)
        {
            var context = new RosterDBDataContext();
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
        }

        public static IQueryable<TeamModel> GetTeamDetails(int teamId)
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
                        });
            return team;
        }

        public static IQueryable<TeamModel> GetTeamDetailsWithPlayers(int teamId)
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
                        });
            return team;
        }

        public static void UpdateTeam(TeamModel model)
        {
            var context = new RosterDBDataContext();
            var team = context.Teams.Where(p => p.TeamId == model.TeamId).Single<Team>();
            team.Name = model.Name;
            if (!string.IsNullOrEmpty(model.Avatar)) team.Avatar = model.Avatar;
            team.Score = model.Score;
            team.Wins = model.Wins;
            team.Losses = model.Losses;
            team.Ties = model.Ties;
            context.SubmitChanges();
        }

        public static void DeleteTeam(TeamModel model)
        {
            var context = new RosterDBDataContext();
            var team = context.Teams.Where(p => p.TeamId == model.TeamId).Single<Team>();
            context.Teams.DeleteOnSubmit(team);
            context.SubmitChanges();
        }
    }
}