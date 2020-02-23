using PCE.Cocina.Service.Lib.Contracts;
using PCE.Cocina.ViewModel.ViewModels.UsuarioDTO;
using PCM.Cocina.DataAccess.Lib.DMModel;
using PCM.Cocina.DataAccess.Model.Contracts;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Realizations
{
    public class UsuarioServices: IUsuarioServices
    {
        IUsuarioDBModel _usuarioDbModel = new UsuarioDBModel();
        public UsuarioDTO ObtenerUsuario(string usuario)
        {
            UsuarioDTO res = null;
            try
            {
                UsuarioModel _usuarioVO = _usuarioDbModel.GetAccessUsuario(usuario);
                res = new UsuarioDTO
                {
                    Usuario = _usuarioVO.usuario,
                    CodigoUsuario = _usuarioVO.id_usuario,
                    Password = _usuarioVO.contraseña
                };
            }
            catch (Exception ex)
            {
                //res = new CertificadoDTO();
                throw ex;
            }
            return res;
        }
    }
}
