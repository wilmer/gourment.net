using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.ViewModel.ViewModels.Tipos;
using PCM.Cocina.DataAccess.Lib.DMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Realizations
{
    public class PlatoDeFondoServices : IPlatoDeFondoServices
    {
        private readonly PlatoDeFondoDBModel _platodefondoDBModel = new PlatoDeFondoDBModel();

        public PlatoDeFondoServices()
        {

        }
        public IList<PlatoDeFondoDTO> obtenerPlatoDeFondo()
        {

            var result = _platodefondoDBModel.GetListPlatoDeFondo();
            PlatoDeFondoDTO dto = null;
            return result.Select(e =>
            {
                PlatoDeFondoDTO.EnDto(e, ref dto);
                return dto;
            }).ToList();
        }
    }
}
