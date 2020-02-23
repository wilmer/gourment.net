using PCE.Cocina.ViewModel.ViewModels.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Contracts
{
    public interface IRefrescoServices
    {
        IList<RefrescoDTO> obtenerRefresco();
    }
}
