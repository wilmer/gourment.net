using Microsoft.Practices.EnterpriseLibrary.Data;
using PCM.Cocina.DataAccess.Lib.DMModel;
using PCM.Cocina.DataAccess.Model.Contracts;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.DMModel
{
    public class PlatoDeFondoDBModel: OperationHelper, IPlatoDeFondoDBModel
    {
        public IList<PlatoDeFondo> GetListPlatoDeFondo()
        {
            var db = GetGBLDataBase();
            IRowMapper<PlatoDeFondo> reclamacionesRowMapper = MapBuilder<PlatoDeFondo>.MapAllProperties()

                .Build();
            object[] parameters = new object[] { };
            var resultCertificados = db.ExecuteSprocAccessor("Listar_PlatoDeFondo", reclamacionesRowMapper, parameters);
            return resultCertificados.ToList();
        }
    }
}
