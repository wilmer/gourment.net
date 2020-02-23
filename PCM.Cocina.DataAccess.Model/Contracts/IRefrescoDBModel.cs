using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Model.Contracts
{
    public interface IRefrescoDBModel
    {
        IList<RefrescoModel> GetListRefresco();
    }
}
