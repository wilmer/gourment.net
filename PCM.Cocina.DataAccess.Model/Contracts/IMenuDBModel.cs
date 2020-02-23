using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Model.Contracts
{
    public interface IMenuDBModel
    {
        bool InsertarMenu(ref DbTransaction transaction, int identrada1, int idEntrada2, int platodeFondo1, int plataodeFondo2, int refresco, int usuario_creacion, string menu);
        IList<MenuModel> GetListMenu(int from, int to, string nombre);
        IList<MenuModel> GetListComboMenu();
    }
}
