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
    public class EntradaServices : IEntradaServices
    {
        private readonly EntradaDBModel _entradaDBModel = new EntradaDBModel();

        public EntradaServices()
        {

        }
        public IList<EntradaDTO> obtenerEntrada()
        {

            var result = _entradaDBModel.GetListEntrada();
           EntradaDTO dto = null;
            return result.Select(e =>
            {
                EntradaDTO.EnDto(e, ref dto);
                return dto;
            }).ToList();
        }
    }
}
