using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.StoreProcedures
{
    public class GBL_Usuario
    {
        public static DbCommand GBL_USUASS_UnReg(ref Database db, string usuario)
        {
            DbCommand sp = db.GetStoredProcCommand("USUARIOS_BUSCAR_UN_USUARIO");
            db.AddInParameter(sp, "@USUARIO", DbType.String, usuario);

            return sp;
        }
    }
}
