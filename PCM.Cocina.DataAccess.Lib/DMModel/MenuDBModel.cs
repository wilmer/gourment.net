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
    public class MenuDBModel : OperationHelper, IMenuDBModel
    {
        public bool InsertarMenu(ref DbTransaction transaction, int identrada1, int idEntrada2, int platodeFondo1, int plataodeFondo2,int refresco, int usuario_creacion,string menu)
        {

            bool res = true;
            try
            {
                var db = GetGBLDataBase();
                var sp = GBL_Menu.MENU_INSERTAR(ref db, identrada1, idEntrada2, platodeFondo1, plataodeFondo2, refresco, usuario_creacion, menu);
                db.ExecuteNonQuery(sp, transaction);
               // res = Convert.ToBoolean(db.GetParameterValue(sp, "@Codigo_menu"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public IList<MenuModel> GetListMenu(int from, int to, string nombre)
        {
            var db = GetGBLDataBase();
            IRowMapper<MenuModel> reclamacionesRowMapper = MapBuilder<MenuModel>.MapAllProperties()
              
                .Build();
            object[] parameters = new object[] { from, to, nombre };
            var resultCertificados = db.ExecuteSprocAccessor("Menu_Filtrado", reclamacionesRowMapper, parameters);
            return resultCertificados.ToList();
        }

        public IList<MenuModel> GetListComboMenu()
        {
            var db = GetGBLDataBase();
            IRowMapper<MenuModel> reclamacionesRowMapper = MapBuilder<MenuModel>.MapAllProperties()
                .DoNotMap(s=>s.DescriEntrada1).DoNotMap(s=>s.IdEntrada1)
                .DoNotMap(s=>s.IdEntrada2).DoNotMap(s=>s.DescriEntrada2)
                .DoNotMap(s=>s.IdPlatoDeFondo1).DoNotMap(s=>s.DescriPlatoDeFondo1)
                .DoNotMap(s=>s.IdPlatoDeFondo2).DoNotMap(S=>S.DescriPlatoDeFondo2)
                .DoNotMap(s=>s.IdRefresco).DoNotMap(s=>s.DescriRefresco)
                .DoNotMap(s=>s.TotalRows).DoNotMap(s=>s.RowNumber)
       
                .Build();
            object[] parameters = new object[] { };
            var resultCertificados = db.ExecuteSprocAccessor("Listar_Menus", reclamacionesRowMapper, parameters);
            return resultCertificados.ToList();
        }
    }
}

