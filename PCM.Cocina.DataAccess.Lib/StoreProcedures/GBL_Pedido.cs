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
    public class GBL_Pedido
    {
        public static DbCommand PEDIDO_INSERTAR(ref Database db, int id_menu, int cantidad)
        {
            DbCommand sp = db.GetStoredProcCommand("INSERTAR_PEDIDO");

            db.AddInParameter(sp, "@ID_MENU", DbType.Int32, id_menu);
            db.AddInParameter(sp, "@cantidad", DbType.Int32, cantidad);

            return sp;
        }
        public static DbCommand PEDIDO_ACTUALIZAR(ref Database db, int id_pedido)
        {
            DbCommand sp = db.GetStoredProcCommand("Actualizar_Estado_Orden");

            db.AddInParameter(sp, "@CodigoOrden", DbType.Int32, id_pedido);
           

            return sp;
        }
    }
}
