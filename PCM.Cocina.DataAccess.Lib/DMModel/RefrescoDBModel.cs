using Microsoft.Practices.EnterpriseLibrary.Data;
using PCM.Cocina.DataAccess.Model.Contracts;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.DMModel
{
    public  class RefrescoDBModel: OperationHelper, IRefrescoDBModel
    {
        public IList<RefrescoModel> GetListRefresco()
        {
            var db = GetGBLDataBase();
            IRowMapper<RefrescoModel> reclamacionesRowMapper = MapBuilder<RefrescoModel>.MapAllProperties()

                .Build();
            object[] parameters = new object[] {  };
            var resultCertificados = db.ExecuteSprocAccessor("Listar_Refresco", reclamacionesRowMapper, parameters);
            return resultCertificados.ToList();
        }
    }
}
