using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.Util
{
    public class UtilDB
    {
        public static int INT = 1;
        public static int STRING = 2;

        public static string val(Object obj, int code)
        {
            string res = null;
            if (code == INT) res = obj.ToString() == null ? "0" : obj.ToString();
            else if (code == STRING) res = obj.ToString() == null ? null : obj.ToString();
            return res;
        }

        public static object valIn(int x)
        {
            if (x == 0) return null;
            return x;
        }
    }
}
