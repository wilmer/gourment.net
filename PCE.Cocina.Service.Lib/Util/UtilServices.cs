using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCE.Cocina.Service.Lib.Util;
using PCE.Cocina.ViewModel.ViewModels.Base;
using PCM.Cocina.Service.Lib.Util;
using System.Globalization;

namespace PCE.Cocina.Service.Lib.Util
{
    public class UtilServices
    {
        public static String getCelEmpty(string x)
        {
            return x != null && !x.Equals("") ? x : Constants.PROSPECTO_MOVIL_DEFAULT;
        }

        public static String getFijoNumberEmpty(string x)
        {
            return x != null && !x.Equals("") ? x : Constants.PROSPECTO_TELEFONOFIJO_DEFAULT;
        }

        public static String getEmailEmpty(string x)
        {
            return x != null && !x.Equals("") ? x : Constants.PROSPECTO_CORREO_DEFAULT;
        }

        public static MsgDTO conveMsgToMsgDTO(Msg msg)
        {
            MsgDTO msgDTO = new MsgDTO
            {
                Sucess = msg.Sucess,
                Message = msg.Message,
                MessageType = msg.MessageType
            };
            return msgDTO;
        }

        public static DateTime parseDate(String date)
        {
            DateTime result = new DateTime();
            result = DateTime.ParseExact(date, Constants.FORMATO_FECHA_SALIDA_YYYYMMDD, CultureInfo.CurrentCulture);
            return result;
        }
        public static DateTime? parseNullableDate(String date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
            {
                return result;
            }
            else
            {
                return null;
            }

        }
        public static string GetSubStringConSuspensivos(string a, int n)
        {
            if (a == null) return a;
            return a.Length > n ? a.Substring(0, n) + "..." : a;
        }

        public static string ConvertDateNullableToString(DateTime? x)
        {
            String res = "";
            if (x.HasValue)
            {
                res = x.Value.ToString(Constants.FORMATO_FECHA_SALIDA_YYYYMMDD);
            }
            return res;
        }

        public static string ConvertDecimalToFormatNumber(Decimal num)
        {
            string res = "";
            string numStr = num + "";
            int n = numStr.Length;
            int pi = numStr.Length % 3;
            // parte entera
            for (int i = 0; i < pi; i++)
            {
                res += numStr[i] + (i + 1 == pi && n > 6 ? "," : "");
            }
            for (int i = pi; i < n - 3; i++)
            {
                res += numStr[i] + ((i + 1 - pi) % 3 == 0 && i != n - 4 ? "," : "");
            }
            //parte decimal mas punto
            for (int i = n - 3; i < n; i++)
                res += numStr[i];
            return res;
        }
    }
}
