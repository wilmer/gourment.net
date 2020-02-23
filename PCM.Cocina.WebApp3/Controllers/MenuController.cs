using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.Service.Lib.Realizations;
using PCE.Cocina.ViewModel.ViewModels.Base;
using PCE.Cocina.ViewModel.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCM.Cocina.WebApp3.Controllers
{
    public partial class MenuController : Controller
    {

        private readonly IMenuServices _menuServices = new MenuServices();
        private readonly IEntradaServices _entradaServices = new EntradaServices();
        private readonly IRefrescoServices _refrescoServices = new RefrescoServices();
        private readonly IPlatoDeFondoServices _platoDeFondoServices = new PlatoDeFondoServices();

        public MenuController()
        {

        }
        // GET: Menu
        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult ListaMenus()
        {
            return View();
        }

        public virtual ActionResult RegistrarMenu()
        {
            MenuDTO model = new MenuDTO();
          
            model.ListaCodigoEntrada1 = new SelectList(_entradaServices.obtenerEntrada(), "CodigoEntrada", "DescriEntrada");
            model.ListaCodigoEntrada2 = new SelectList(_entradaServices.obtenerEntrada(), "CodigoEntrada", "DescriEntrada");
            model.ListaPlatoDeFondo1 = new SelectList(_platoDeFondoServices.obtenerPlatoDeFondo(), "CodigoPlatoDeFondo", "DescriPlatoDeFondo");
            model.ListaPlatoDeFondo2 = new SelectList(_platoDeFondoServices.obtenerPlatoDeFondo(), "CodigoPlatoDeFondo", "DescriPlatoDeFondo");
            model.ListaCodigoRefresco = new SelectList(_refrescoServices.obtenerRefresco(), "CodigoRefresco", "DescriRefresco");
            //model.ListaCodigoTiposComprobantes = new SelectList(_tipoComprobante.obtenerTiposComprobantes(), "CodigoTipoComprobante", "DescriTipoComprobante");
            //model.CodigoTipoDocumento = 6;
            return PartialView("RegistrarMenu", model);
        }

        [HttpPost]
        public virtual ActionResult ListarMenus(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null, string texto = null)
        {
            try
            {
                IList<MenuDTO> menu;
                menu = _menuServices.obtenerListMenu(jtStartIndex + 1, jtStartIndex + jtPageSize, texto == null ? "" : texto);
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


        [HttpPost]
        public virtual ActionResult CrearMenu(string nombreMenu, int cbEntrada1, int cbEntrada2, int cbPlatoDeFondo1, int cbPlatoDeFondo2, int cbRefresco)
        {
            try
            {

                MenuDTO menuDTO = new MenuDTO();
                menuDTO.DescripcionMenu = nombreMenu;
                menuDTO.CodigoEntrada1 = cbEntrada1;
                menuDTO.CodigoEntrada2 = cbEntrada2;
                menuDTO.CodigoPlatoDeFondo1 = cbPlatoDeFondo1;
                menuDTO.CodigoPlatodeFondo2 = cbPlatoDeFondo2;
                menuDTO.CodigoRefresco = cbRefresco;
                var resultadActualizacion = _menuServices.InsertarMenu(menuDTO.CodigoEntrada1, menuDTO.CodigoEntrada2, menuDTO.CodigoPlatoDeFondo1, menuDTO.CodigoPlatodeFondo2, menuDTO.CodigoRefresco, 1, menuDTO.DescripcionMenu);
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

    }
}