using PCM.Cocina.DataAccess.Lib.DMModel;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.ViewModel.ViewModels.Tipos
{
    public class PlatoDeFondoDTO
    {
        public int CodigoPlatoDeFondo { get; set; }
        public string DescriPlatoDeFondo { get; set; }

        public PlatoDeFondoDTO()
        {

        }
        public PlatoDeFondoDTO(int CodigoPlatoDeFondoDTO)
        {
            this.CodigoPlatoDeFondo = CodigoPlatoDeFondo;
        }


        public static void EnDto(PlatoDeFondo model, ref PlatoDeFondoDTO resultadoDTO)
        {
            if (model != null)
                resultadoDTO = new PlatoDeFondoDTO()
                {
                    CodigoPlatoDeFondo = model.id_platodefondo,
                    DescriPlatoDeFondo = model.descri_platodefondo,
                };
            else
                resultadoDTO = null;
        }
    }
}
