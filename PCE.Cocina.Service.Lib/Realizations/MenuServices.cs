using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.ViewModel.ViewModels.Menu;
using PCM.Cocina.DataAccess.Lib;
using PCM.Cocina.DataAccess.Lib.DMModel;
using PCM.Cocina.Service.Lib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Realizations
{
    public class MenuServices : IMenuServices
    {
        private readonly MenuDBModel _menuDBModel = new MenuDBModel();

        public MenuServices()
        {

        }
        public Msg InsertarMenu(int codigoEntrada_1, int codigoEntrada_2, int codigoPlatoDeFondo_1, 
            int codigoPlatoDeFondo_2, int idrefresco, int usuario_creacion, string menu
        )
        {
            Msg mensajeResultado = new Msg();
            var transaction = OperationHelper.GetTransaction();
            bool resultadoCabecera = false;

            try
            {

                resultadoCabecera = _menuDBModel.InsertarMenu(ref transaction,
                codigoEntrada_1, codigoEntrada_2,
                codigoPlatoDeFondo_1, codigoPlatoDeFondo_2,
                idrefresco,
                usuario_creacion,
                menu);
                transaction.Commit();
                if (resultadoCabecera)
                    mensajeResultado.Success("Se inserto correctamente el reclamo");
                else
                {
                    mensajeResultado.Error("Error al insertar el reclamo");
                }

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            return mensajeResultado;
        }
        public IList<MenuDTO> obtenerListMenu(int inicio, int fin,string texto)
        {

            var result = _menuDBModel.GetListMenu(inicio, fin, texto);
            MenuDTO dto = null;
            return result.Select(e =>
            {
                MenuDTO.EnDto(e, ref dto);
                return dto;
            }).ToList();
        }

        public IList<MenuDTO> obtenerComboMenu()
        {

            var result = _menuDBModel.GetListComboMenu();
            MenuDTO dto = null;
            return result.Select(e =>
            {
                MenuDTO.EnDto(e, ref dto);
                return dto;
            }).ToList();
        }
    }
}
