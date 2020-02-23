using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.ViewModel.ViewModels.Tipos
{
    public class EntradaDTO
    {
        public int CodigoEntrada { get; set; }
        public string DescriEntrada { get; set; }

        public EntradaDTO()
        {

        }
        public EntradaDTO(int CodigoEntradaDTO)
        {
            this.CodigoEntrada = CodigoEntrada;
        }

        public static void EnDto(EntradaModel model, ref EntradaDTO resultadoDTO)
        {
            if (model != null)
                resultadoDTO = new EntradaDTO()
                {
                    CodigoEntrada = model.id_entrada,
                    DescriEntrada = model.descri_entrada,
                };
            else
                resultadoDTO = null;
        }
    }
}
