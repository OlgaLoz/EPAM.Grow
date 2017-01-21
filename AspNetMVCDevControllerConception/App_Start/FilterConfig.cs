﻿using System.Web;
using System.Web.Mvc;
using AspNetMVCDevControllerConception.Filters;

namespace AspNetMVCDevControllerConception
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new BrowserFilter());
        }
    }
}
