using Microsoft.Practices.EnterpriseLibrary.Data;
using PCM.Cocina.DataAccess.Lib.StoreProcedures;
using PCM.Cocina.DataAccess.Model.Contracts;
using PCM.Cocina.DataAccess.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Lib.DMModel
{
    public class UsuarioDBModel: OperationHelper, IUsuarioDBModel
    {
        public IEnumerable<UsuarioModel> GetAll()
        {
            throw new NotImplementedException();
        }
        public UsuarioModel GetAccessUsuario(string usuario)
        {
            UsuarioModel res = new UsuarioModel();
            var db = GetGBLDataBase();
            using (var conn = db.CreateConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    var sp = GBL_Usuario.GBL_USUASS_UnReg(ref db, usuario);
                    var mapper = MapBuilder<UsuarioModel>.MapAllProperties().
                           Build();
                    IList<UsuarioModel> lista = db.ExecuteSqlStringAccessor(OperationHelper.GenerateAccessorString(sp), mapper).ToList();
                    if (lista.Count > 0)
                        res = lista[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return res;
        }

        public bool Insert(ref DbTransaction transaction, UsuarioModel model)
        {
            throw new NotImplementedException();
        }
        public bool Update(ref DbTransaction transaction, UsuarioModel model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(ref DbTransaction transaction, int id)
        {
            throw new NotImplementedException();
        }
        public UsuarioModel GetById(int id)
        {
            throw new NotImplementedException();
        }
      
    }
}
