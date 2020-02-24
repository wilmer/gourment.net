using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.Service.Lib.Realizations;
using PCE.Cocina.ViewModel.ViewModels.PedidoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCM.Cocina.WebApp3.Controllers
{
    public partial class PedidoController : Controller
    {
        private readonly IPedidoServices _pedidoServices = new PedidoServices();
        private readonly IMenuServices _menuServices = new MenuServices();
        // GET: Pedido
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult RegistrarPedido()
        {
            PedidoDTO model = new PedidoDTO();

            model.ListaCodigoMenu = new SelectList(_menuServices.obtenerComboMenu(), "CodigoMenu", "DescripcionMenu");

            //model.ListaCodigoTiposComprobantes = new SelectList(_tipoComprobante.obtenerTiposComprobantes(), "CodigoTipoComprobante", "DescriTipoComprobante");
            //model.CodigoTipoDocumento = 6;
            return PartialView("RegistrarPedido", model);
        }
        public virtual ActionResult ListarPedidos()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult CrearPedido(int Cantidad, int cbMenu)
        {
            try
            {

                var resultadActualizacion = _pedidoServices.InsertarPedido(cbMenu, Cantidad);
                if (resultadActualizacion.Sucess)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR" });
            }
        }

        [HttpPost]
        public virtual ActionResult AtenderPedido(int CodigoPedido)
        {
            try
            {

                var resultadActualizacion = _pedidoServices.ActualizarPedido(CodigoPedido);
                if (resultadActualizacion.Sucess)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR" });
            }
        }



        [HttpPost]
        public virtual ActionResult ListarPedidos(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null, string texto = null)
        {
            try
            {
                IList<PedidoDTO> menu;
                menu = _pedidoServices.obtenerListPedido(jtStartIndex + 1, jtStartIndex + jtPageSize, texto == null ? "" : texto);
                int totalRows = 0;
                if (menu != null && menu.Count > 0)
                    totalRows = menu.FirstOrDefault().TOTALROWS;
                return Json(new { Result = "OK", Records = menu, TotalRecordCount = totalRows });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }
    }
}