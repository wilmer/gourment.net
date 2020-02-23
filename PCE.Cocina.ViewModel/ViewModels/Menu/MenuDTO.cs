using PCE.Cocina.ViewModel.ViewModels.Base;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PCE.Cocina.ViewModel.ViewModels.Menu
{
    public class MenuDTO
    {
        public int CodigoMenu { get; set; }
        public string DescripcionMenu { get; set; }
        public int CodigoEntrada1 { get; set; }
        public string DescriEntrada1 { get; set; }
        public SelectList ListaCodigoEntrada1 { get; set; }
        public int CodigoEntrada2 { get; set; }

        public string DescriEntrada2 { get; set; }
        public SelectList ListaCodigoEntrada2 { get; set; }
        public int CodigoPlatoDeFondo1 { get; set; }
        public string DescriPlatoDeFondo1 { get; set; }
        public SelectList ListaPlatoDeFondo1 { get; set; }
        public int CodigoPlatodeFondo2 { get; set; }
        public string DescriPlatoDeFondo2 { get; set; }
        public SelectList ListaPlatoDeFondo2 { get; set; }
        public int CodigoRefresco { get; set; }
        public string DescriRefresco { get; set; }
        public SelectList ListaCodigoRefresco { get; set; }

        public MsgDTO msgDTO { get; set; }
        public int EstadoValidezModelo { get; set; }
        public int ErrorValidation { get; set; }
        public int modelValidCont { get; set; }
        public MsgDTO MensajeResultadoDTO { get; set; }
        public int ROW;
        public int TOTALROWS;


        public MenuDTO()
        {
        }
        public MenuDTO(int CodigoMenu)
        {
            this.CodigoMenu = CodigoMenu;
        }

        public static void EnDto(MenuModel model, ref MenuDTO resultadoDTO)
        {
            if (model != null)
                resultadoDTO = new MenuDTO()
                {
                    ROW = model.RowNumber,
                    TOTALROWS = model.TotalRows,
                    CodigoMenu = model.IdMenu,
                    CodigoEntrada1 = model.IdEntrada1,
                    CodigoEntrada2 = model.IdEntrada2,
                    CodigoPlatoDeFondo1=model.IdPlatoDeFondo1,
                    CodigoPlatodeFondo2=model.IdPlatoDeFondo2,
                    DescriEntrada1=model.DescriEntrada1,
                    DescriEntrada2=model.DescriEntrada2,
                    DescriPlatoDeFondo1=model.DescriPlatoDeFondo1,
                    DescriPlatoDeFondo2=model.DescriPlatoDeFondo2,
                    CodigoRefresco=model.IdRefresco,
                    DescriRefresco=model.DescriRefresco,
                    DescripcionMenu=model.Menu


                };
            else
                resultadoDTO = null;
        }
        public static void EnModelo(MenuDTO dto, ref MenuModel resultadoModelo)
        {
            if (dto != null)
                resultadoModelo = new MenuModel()
                {
                    IdMenu = dto.CodigoMenu,
                    IdEntrada1 = dto.CodigoEntrada1,
                    DescriEntrada1 = dto.DescriEntrada1,
                    IdEntrada2=dto.CodigoEntrada2,
                    DescriEntrada2=dto.DescriEntrada2,
                    IdPlatoDeFondo1=dto.CodigoPlatoDeFondo1,
                    DescriPlatoDeFondo1=dto.DescriPlatoDeFondo1,
                    IdPlatoDeFondo2=dto.CodigoPlatodeFondo2,
                    DescriPlatoDeFondo2=dto.DescriPlatoDeFondo2,
                    IdRefresco=dto.CodigoRefresco,
                    DescriRefresco=dto.DescriRefresco,
                    Menu=dto.DescripcionMenu


                };
            else
                resultadoModelo = null;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (String.IsNullOrWhiteSpace(DescripcionMenu)
                )
                yield return new ValidationResult("Debe de ingresar al menos un dato.");

        }
    }
}
