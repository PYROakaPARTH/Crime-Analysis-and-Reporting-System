using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Util
{
    static class PropertyUtil
    {
        public static string getPropertyString()
        {
            string hostname = "DESKTOP-2CKOTL1";
            string dbname = "CARS";
            return $"Data Source = {hostname}; Initial Catalog = {dbname}; Integrated Security = True";
        }
    }
}
