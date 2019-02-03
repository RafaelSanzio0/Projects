using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simulator
{
    public static class Migrator
    {
        public static string StartMigration(string userLogin)
        {
            string xml = string.Empty;

            Random random = new Random();
            int id = random.Next(1000, 50000);
            bool failed = false;

            if (id % 2 > 0)
                failed = true;

            xml = string.Format("<result><id>{0}</id><failed>{1}</failed></result>", id, failed);

            return xml;
        }

    }
}