using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.ViewModel.ViewModels.UsuarioDTO
{
    public class UsuarioDTO : IValidatableObject
    {
        public int CodigoUsuario { get; set; }
        [Display(Name = "Usuario:")]
        public string Usuario { get; set; }
        [Display(Name = "Password:")]
        public string Password { get; set; }

        public UsuarioDTO()
        {
        }
        public UsuarioDTO(int CodigoUsuario)
        {
            this.CodigoUsuario = CodigoUsuario;
        }

        public static void EnDto(UsuarioModel model, ref UsuarioDTO resultadoDTO)
        {
            if (model != null)
                resultadoDTO = new UsuarioDTO()
                {
                    CodigoUsuario = model.id_usuario,
                    Usuario = model.usuario,
                    Password = model.contraseña
                    

                };
            else
                resultadoDTO = null;
        }
        public static void EnModelo(UsuarioDTO dto, ref UsuarioModel resultadoModelo)
        {
            if (dto != null)
                resultadoModelo = new UsuarioModel()
                {
                    id_usuario = dto.CodigoUsuario,
                    contraseña = dto.Password,
                    usuario = dto.Usuario
                   
                };
            else
                resultadoModelo = null;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (String.IsNullOrWhiteSpace(Usuario) && String.IsNullOrWhiteSpace(Password)
                )
                yield return new ValidationResult("Debe de ingresar al menos un dato.");

        }
    }

   
}
