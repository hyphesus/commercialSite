using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO;

namespace HerSeyci
{

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            LogError(exception);

            if (exception is HttpException httpException && httpException.GetHttpCode() == 404)
            {
                Response.Redirect("~/Error/NotFound");
            }
            else
            {
                Response.Redirect("~/Error");
            }

        }
        private void LogError(Exception exception)
        {
            string logPath = Server.MapPath("~/App_Data/ErrorLog.txt");
            string message = $"Time: {DateTime.Now}\nException: {exception}\n\n";

            // Dosya yoksa olu�tur, varsa sonuna ekle
            File.AppendAllText(logPath, message);
        }

    }
}
