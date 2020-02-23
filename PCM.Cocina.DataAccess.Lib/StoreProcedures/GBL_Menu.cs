using Microsoft.Practices.EnterpriseLibrary.Data;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.StoreProcedures
{
    public class GBL_Menu
    {
        public static DbCommand MENU_INSERTAR(ref Database db, int entrada_1,
                               int entrada_2, int plato_de_fondo_1, int plato_de_fondo_2,
                               int id_refresco,
                               int usuario_creacion, string menu)
        {
            DbCommand sp = db.GetStoredProcCommand("COCINA_INSERTAR");

            db.AddInParameter(sp, "@IDENTRADA_1", DbType.Int32, entrada_1);
            db.AddInParameter(sp, "@IDENTRADA_2", DbType.Int32, entrada_2);
            db.AddInParameter(sp, "@ID_PLATO_DEFONDO_1", DbType.Int32, plato_de_fondo_1);
            db.AddInParameter(sp, "@ID_PLATO_DE_FONDO_2", DbType.Int32, plato_de_fondo_2);
            db.AddInParameter(sp, "@ID_REFRESCO", DbType.Int32, id_refresco);
            db.AddInParameter(sp, "@DESCRI_MENU", DbType.String, menu);
        
            return sp;
        }

      
    }
}
    