using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OWULRosterServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region MVC ROUTES

            routes.MapRoute(
                name: "All Players",
                url: "Player",
                defaults: new { controller = "Player", action = "Index" }
            );

            routes.MapRoute(
                name: "Players on Team",
                url: "Player/TeamId/{teamId}",
                defaults: new { controller = "Player", action = "Index", teamId = "teamId" }
            );

            routes.MapRoute(
                name: "Team Default",
                url: "{controller}/{action}/{teamId}",
                defaults: new { controller = "Home", action = "Index", teamId = "teamId" }
            );

            routes.MapRoute(
                name: "Player Default",
                url: "{controller}/{action}/{playerId}",
                defaults: new { controller = "Home", action = "Index", playerId = "playerId" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            #endregion

            #region API ROUTES

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "API All Teams",
                url: "API/Teams",
                defaults: new { controller = "Team", action = "GetTeams" }
            );

            routes.MapRoute(
                name: "API Team Details",
                url: "API/Teams/{teamId}",
                defaults: new { controller = "Team", action = "GetTeamDetails", teamId = "teamId" }
            );

            routes.MapRoute(
                name: "API All Players",
                url: "API/Players",
                defaults: new { controller = "Player", action = "GetPlayers" }
            );

            routes.MapRoute(
                name: "API Players on Team",
                url: "API/Players/TeamId/{teamId}",
                defaults: new { controller = "Player", action = "GetTeamPlayers", teamId = "teamId" }
            );



            #endregion
        }
    }
}
