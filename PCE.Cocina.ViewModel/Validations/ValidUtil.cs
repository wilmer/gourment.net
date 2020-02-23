using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.ViewModel.Validations
{
    public class ValidUtil
    {

        public static Boolean isValidNumberNDigits(string x, int n)
        {
            return x != null ? Regex.IsMatch(x, "^(\\d{" + n + "})$") : false;
        }
        public static Boolean isValidNumberMtoNDigits(string x, int m, int n)
        {
            return x != null ? Regex.IsMatch(x, "^(\\d{" + m + "," + n + "})$") : false;
        }

        public static Boolean isEmailValid(string x)
        {
            return x != null ? Regex.IsMatch(x,
               "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$") : false;
        }

        public static Boolean isNameValid(string x)
        {
            //return x != null ? Regex.IsMatch(x, "^[a-zA-Z ]*$") : false;
            return x != null;
        }

        public static Boolean isStringValid(String x)
        {
            return x != null && x.Length > 0;
        }

        public static Boolean isStringValid(String x, int n)
        {
            return x != null && x.Length == n;
        }

        public static Boolean validRuc(string x)
        {
            if (!ValidUtil.isValidNumberNDigits(x, 11))
                return false;
            bool res = true;
            res &= x.Substring(0, 2).Equals("10") || x.Substring(0, 2).Equals("15") || x.Substring(0, 2).Equals("20");
            int totalSum = 0, parEnt = 0;
            int[] fac = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 10; i++)
                totalSum += Int32.Parse(x[i] + "") * fac[i];
            parEnt = totalSum / 11;
            int finDig = 11 - totalSum % 11;
            res &= (x[10] + "").Equals(finDig + "");
            return res;
        }

        public static Boolean validEjecutivo(int x)
        {
            string str = x + "";
            return Regex.IsMatch(str, "^([1-9]|\\d{2,})$");
        }

        public static Boolean validEstaCivil(int x)
        {
            string str = x + "";
            return Regex.IsMatch(str, "^([1-9]|\\d{2,})$");
        }

        public static Boolean EsMayorCero(int x)
        {
            return x > 0;
        }
    }
}
