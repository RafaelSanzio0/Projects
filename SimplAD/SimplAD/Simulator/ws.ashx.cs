using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simulator
{
    /// <summary>
    /// Summary description for ws
    /// </summary>
    public class ws : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;

            string userLogin = context.Request.QueryString["u"]; // ?

            string xmlResult = Migrator.StartMigration(userLogin);

            context.Response.Write(xmlResult);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}