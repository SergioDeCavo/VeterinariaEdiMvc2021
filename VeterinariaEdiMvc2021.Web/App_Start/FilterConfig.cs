﻿using System.Web;
using System.Web.Mvc;

namespace VeterinariaEdiMvc2021.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
