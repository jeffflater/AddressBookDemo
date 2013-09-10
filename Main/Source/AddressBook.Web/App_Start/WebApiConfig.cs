﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AddressBook.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{typeId}",
                defaults: new { id = RouteParameter.Optional, typeId = RouteParameter.Optional }
            );
        }
    }
}
