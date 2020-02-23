using Microsoft.Practices.EnterpriseLibrary.Data;
using PCM.Cocina.DataAccess.Lib.StoreProcedures;
using PCM.Cocina.DataAccess.Model.Contracts;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.DMModel
{
    public class PedidoDBModel : OperationHelper, IPedidoDBModel
    {
        public bool InsertarPedido(ref DbTransaction transaction, int idMenu, int cantidad)
        {

            bool res = true;
            try
            {
                var db = GetGBLDataBase();
                var sp = GBL_Pedido.PEDIDO_INSERTAR(ref db, idMenu, cantidad);
                db.ExecuteNonQuery(sp, transaction);
                // res = Convert.ToBoolean(db.GetParameterValue(sp, "@Codigo_menu"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public bool AtenderPedido(ref DbTransaction transaction, int idPedido)
        {

            bool res = true;
            try
            {
                var db = GetGBLDataBase();
                var sp = GBL_Pedido.PEDIDO_ACTUALIZAR(ref db, idPedido);
                db.ExecuteNonQuery(sp, transaction);
                // res = Convert.ToBoolean(db.GetParameterValue(sp, "@Codigo_menu"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }


        public IList<Pedido> GetListPedido(int from, int to, string nombre)
        {
            var db = GetGBLDataBase();
            IRowMapper<Pedido> reclamacionesRowMapper = MapBuilder<Pedido>.MapAllProperties()

                .Build();
            object[] parameters = new object[] { from, to, nombre };
            var resultCertificados = db.ExecuteSprocAccessor("Pedido_Filtrado", reclamacionesRowMapper, parameters);
            return resultCertificados.ToList();
        }
    }
}
