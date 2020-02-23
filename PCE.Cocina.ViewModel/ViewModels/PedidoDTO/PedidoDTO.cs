using PCE.Cocina.ViewModel.ViewModels.Base;
using PCM.Cocina.DataAccess.Lib.DMModel;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PCE.Cocina.ViewModel.ViewModels.PedidoDTO
{
    public class PedidoDTO
    {
        public int CodigoPedido { get; set; }
        public int CodigoMenu { get; set; }
        public string DescriMenu { get; set; }
        public SelectList ListaCodigoMenu { get; set; }
        public string Correlativo { get; set; }
        public string Detalle { get; set; }
        public int CodigoEstado { get; set; }
        public string DescriEstado { get; set; }
        public SelectList ListaCodigoEstado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public MsgDTO msgDTO { get; set; }
        public int EstadoValidezModelo { get; set; }
        public int ErrorValidation { get; set; }
        public int modelValidCont { get; set; }
        public MsgDTO MensajeResultadoDTO { get; set; }
        public int ROW;
        public int TOTALROWS;
        public int Cantidad { get; set; }

        public PedidoDTO()
        {
        }
        public PedidoDTO(int CodigoPedido)
        {
            this.CodigoPedido = CodigoPedido;
        }

        public static void EnDto(Pedido model, ref PedidoDTO resultadoDTO)
        {
            if (model != null)
                resultadoDTO = new PedidoDTO()
                {
                    ROW = model.RowNumber,
                    TOTALROWS = model.TotalRows,
                    CodigoMenu = model.IdMenu,
                    DescriMenu=model.Menu,
                    Correlativo = model.correlativo,
                    Detalle = model.Detalle,
                    DescriEstado=model.estadopedido,
                    Cantidad=model.Cantidad,
                    CodigoPedido=model.id_pedido




                };
            else
                resultadoDTO = null;
        }
        public static void EnModelo(PedidoDTO dto, ref Pedido resultadoModelo)
        {
            if (dto != null)
                resultadoModelo = new Pedido()
                {
                    id_pedido = dto.CodigoPedido,
                    correlativo = dto.Correlativo,
                    estadopedido = dto.DescriEstado,
                    Menu=dto.DescriMenu,
                    Detalle = dto.Detalle,
                    Cantidad=dto.Cantidad
                   

                };
            else
                resultadoModelo = null;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (String.IsNullOrWhiteSpace(Correlativo)
                )
                yield return new ValidationResult("Debe de ingresar al menos un dato.");

        }
    }
}
