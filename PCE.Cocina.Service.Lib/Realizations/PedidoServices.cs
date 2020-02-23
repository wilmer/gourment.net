using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.ViewModel.ViewModels.PedidoDTO;
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
    public class PedidoServices : IPedidoServices
    {
        private readonly PedidoDBModel _pedidoDBModel = new PedidoDBModel();
        public PedidoServices()
        {

        }
        public Msg InsertarPedido(int codigoMenu, int cantidad
        )
        {
            Msg mensajeResultado = new Msg();
            var transaction = OperationHelper.GetTransaction();
            bool resultadoCabecera = false;

            try
            {

                resultadoCabecera = _pedidoDBModel.InsertarPedido(ref transaction,
                codigoMenu, cantidad);
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

        public Msg ActualizarPedido(int codigoPedido)
        {
            Msg mensajeResultado = new Msg();
            var transaction = OperationHelper.GetTransaction();
            bool resultadoCabecera = false;

            try
            {

                resultadoCabecera = _pedidoDBModel.AtenderPedido(ref transaction,
                codigoPedido);
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
        public IList<PedidoDTO> obtenerListPedido(int inicio, int fin, string texto)
        {

            var result = _pedidoDBModel.GetListPedido(inicio, fin, texto);
            PedidoDTO dto = null;
            return result.Select(e =>
            {
                PedidoDTO.EnDto(e, ref dto);
                return dto;
            }).ToList();
        }
    }
}