using PCE.Cocina.ViewModel.ViewModels.Menu;
using PCM.Cocina.Service.Lib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Contracts
{
    public interface IMenuServices
    {
        IList<MenuDTO> obtenerListMenu(int inicio, int fin, string texto);
        IList<MenuDTO> obtenerComboMenu();
        Msg InsertarMenu(int codigoEntrada_1, int codigoEntrada_2, int platoDeFondo_1, int platadeFondo_2, int idrefresco, int usuario_creacion, string menu);
    }
}
