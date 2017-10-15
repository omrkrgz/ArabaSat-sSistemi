﻿using Araba.BLL.Account;
using Araba.Entity.IdentityModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Araba.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var roleManager = MemberShipTools.NewRoleManager();
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Admin",
                    Description = "Site Yöneticisi"
                });
            }
            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "User",
                    Description = "Standart kayıtlı üye"
                });
            }
            if (!roleManager.RoleExists("Banned"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Banned",
                    Description = "Yasaklı Üye"
                });
            }
        }
    }
}
