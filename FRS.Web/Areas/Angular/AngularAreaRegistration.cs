﻿using System.Web.Mvc;

namespace FRS.Web.Areas.Angular
{
    public class AngularAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Angular";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Angular_default",
                "Angular/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "FRS.Web.Areas.Angular.Controllers" }
            );
        }
    }
}