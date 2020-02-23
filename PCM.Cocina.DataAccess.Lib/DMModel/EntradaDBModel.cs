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
    public class EntradaDBModel: OperationHelper, IEntradaDBModel
 
    {
        public IList<EntradaModel> GetListEntrada()
        {
            var db = GetGBLDataBase();
            IRowMapper<EntradaModel> reclamacionesRowMapper = MapBuilder<EntradaModel>.MapAllProperties()

                .Build();
            object[] parameters = new object[] { };
            var resultCertificados = db.ExecuteSprocAccessor("Listar_Entradas", reclamacionesRowMapper, parameters);
            return resultCertificados.ToList();
        }
    }
}
