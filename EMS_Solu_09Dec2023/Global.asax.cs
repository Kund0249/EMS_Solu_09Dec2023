﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;


namespace EMS_Solu_09Dec2023
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["TotalUser"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["TotalUser"] = Convert.ToInt32(Application["TotalUser"]) + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //step-1 : Get the Error
            //Exception ex = Server.GetLastError();

            //step-2 : Log Error and Clear the Error
            //log ex
           // Server.ClearError();

            //step-2 : Redirect to error pages
            //Response.Redirect("~/ErrorPages/Error.aspx");
            //Server.Execute("~/ErrorPages/Error.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["TotalUser"] = Convert.ToInt32(Application["TotalUser"]) - 1;

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}