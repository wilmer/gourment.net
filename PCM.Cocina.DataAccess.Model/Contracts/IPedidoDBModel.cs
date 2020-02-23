using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Model.Contracts
{
    public interface IPedidoDBModel
    {
        bool InsertarPedido(ref DbTransaction transaction, int idMenu, int cantidad);
        IList<Pedido> GetListPedido(int from, int to, string nombre);

        bool AtenderPedido(ref DbTransaction transaction, int idPedido);
    }
}
