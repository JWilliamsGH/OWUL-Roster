﻿using System;
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
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "All Teams",
                url: "Teams",
                defaults: new { controller = "Team", action = "GetTeams" }
            );

            routes.MapRoute(
                name: "Team Details",
                url: "Teams/{teamId}",
                defaults: new { controller = "Team", action = "GetTeamDetails", teamId = "teamId" }
            );

            routes.MapRoute(
                name: "All Players",
                url: "Players",
                defaults: new { controller = "Player", action = "GetPlayers" }
            );

            routes.MapRoute(
                name: "Players on Team",
                url: "Players/TeamId/{teamId}",
                defaults: new { controller = "Player", action = "GetTeamPlayers", teamId = "teamId" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
