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
    public class RefrescoServices : IRefrescoServices
    {
        private readonly RefrescoDBModel _refrescoDBModel = new RefrescoDBModel();

        public RefrescoServices()
        {

        }
        public IList<RefrescoDTO> obtenerRefresco()
        {

            var result = _refrescoDBModel.GetListRefresco();
            RefrescoDTO dto = null;
            return result.Select(e =>
            {
                RefrescoDTO.EnDto(e, ref dto);
                return dto;
            }).ToList();
        }
    }
}