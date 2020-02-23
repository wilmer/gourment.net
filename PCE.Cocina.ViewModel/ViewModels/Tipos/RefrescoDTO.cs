using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.ViewModel.ViewModels.Tipos
{
    public  class RefrescoDTO
    {
        public int CodigoRefresco { get; set; }
        public string DescriRefresco { get; set; }

        public RefrescoDTO()
        {

        }
        public RefrescoDTO(int CodigoRefrescoDTO)
        {
            this.CodigoRefresco = CodigoRefresco;
        }

        public static void EnDto(RefrescoModel model, ref RefrescoDTO resultadoDTO)
        {
            if (model != null)
                resultadoDTO = new RefrescoDTO()
                {
                    CodigoRefresco = model.idrefresco,
                    DescriRefresco = model.refresco,
                };
            else
                resultadoDTO = null;
        }
    }
}
