using PCE.Cocina.ViewModel.ViewModels.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Contracts
{
    public interface IEntradaServices
    {
        IList<EntradaDTO> obtenerEntrada();
    }
}
