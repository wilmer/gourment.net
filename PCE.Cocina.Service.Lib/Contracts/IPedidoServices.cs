using PCE.Cocina.ViewModel.ViewModels.PedidoDTO;
using PCM.Cocina.Service.Lib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Contracts
{
    public interface IPedidoServices
    {
        Msg InsertarPedido(int codigoMenu, int cantidad);
        Msg ActualizarPedido(int codigoPedido);
        IList<PedidoDTO> obtenerListPedido(int inicio, int fin, string texto);
    }
}
