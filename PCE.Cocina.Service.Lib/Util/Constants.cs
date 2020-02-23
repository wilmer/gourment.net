using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Util
{
    public class Constants
    {
        public static readonly string Message = "Message";
        public static readonly string MessageType = "MessageType";
        public static readonly string CODE_LOGIN_OK = "000";
        public static readonly string CODE_LOGIN_NO_EXISTE = "001";
        public static readonly string CODE_LOGIN_USER_SUSPENDIDO = "002";

        public static readonly string CODE_LOGIN_ERROR = "003";
        public static readonly string CONTRASENA_OK = "000";
        public static readonly string CONTRASENA_PORDEFECTO = "001";
        public static readonly string CONTRASENA_CADUCA = "002";
        public static readonly string CONTRASENA_ERROR = "003";

        public static readonly string TIPO_TABLA_PRIORIDAD = "PRI";
        public static readonly string TIPO_TABLA_DOCUMENTO = "TDI";
        public static readonly string TIPO_TABLA_ENDOSATARIO = "END";
        public static readonly string TIPO_TABLA_DIRECCION = "TDR";
        public static readonly string TIPO_TABLA_ESTADO = "EST";
        public static readonly string TIPO_TABLA_MONEDA = "MND";
        public static readonly string TIPO_TABLA_CANAL = "CNL";
        public static readonly string TIPO_TABLA_SITUACION_FECHAS_MONTO = "PSF";
        public static readonly string TIPO_TABLA_REPORTE = "TRE";

        public static readonly string PROSPECTO_ESTADO_INICIAL_COD = "004";
        public static readonly string PROSPECTO_ESTADO_NOELEGIDO = "000";
        public static readonly string PROSPECTO_ESTADO_ACEPTADO = "001";
        public static readonly string PROSPECTO_ESTADO_COTIZADO = "002";
        public static readonly string PROSPECTO_ESTADO_DESESTIMADO = "003";
        public static readonly string PROSPECTO_ESTADO_PENDIENTE = "004";
        public static readonly string FORMATO_FECHA_YYYYMMDD = "yyyyMMdd";
        public static readonly string FORMATO_FECHA_SALIDA_YYYYMMDD = "dd/MM/yyyy";

        public static readonly int PROSPECTO_ESTADO_INICIAL = 2;
        public static readonly string ZONA_GEOGRAFICA_CODIGO_RAIZ = "";

        public static readonly bool ESTADO_ELIMINADO = true;
        public static readonly bool ESTADO_NO_ELIMINADO = false;

        public static readonly string COD_TIPO_RUC = "002";
        public static readonly string PROSPECTO_CORREO_DEFAULT = "SINCORREO@MAIL.COM";
        public static readonly string PROSPECTO_MOVIL_DEFAULT = "999999999";
        public static readonly string PROSPECTO_TELEFONOFIJO_DEFAULT = "999999";

        public static readonly string ESTADO_ACEPTADO = "ACEPTADO";
        public static readonly string ESTADO_DESESTIMADO = "DESESTIMADO";
        public static readonly string ESTADO_COTIZADO = "COTIZADO";
        public static readonly string ESTADO_PENDIENTE = "PENDIENTE";

        public static readonly string ARCHIVO_CODIGO_SUCURSAL = "01";
        public static readonly string ARCHIVO_CODIGO_TIPO_INSERT = "1";
        public static readonly string ARCHIVO_CODIGO_TIPO_SELECT = "0";

        public static readonly int MODEL_VALID_DTO = 1;
        public static readonly int MODEL_INVALID_DTO = 0;

        public static readonly int SUBMIT_DETALLE_SI = 1;
        public static readonly int SUBMIT_DETALLE_NO = 0;

        public static readonly string TIENE_PERMISO = "H";
        public static readonly string NO_TIENE_PERMISO = "D";

        public static string GetNameEstadoByCode(string code)
        {
            string res = ESTADO_PENDIENTE;
            if (code.Equals(PROSPECTO_ESTADO_ACEPTADO))
                res = ESTADO_ACEPTADO;
            else if (code.Equals(PROSPECTO_ESTADO_COTIZADO))
                res = ESTADO_COTIZADO;
            else if (code.Equals(PROSPECTO_ESTADO_DESESTIMADO))
                res = ESTADO_DESESTIMADO;
            return res;
        }
    }
}
