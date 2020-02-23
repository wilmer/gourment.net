using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Model.Contracts.Base
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Insert(ref DbTransaction transaction, T model);
        bool Update(ref DbTransaction transaction, T model);
        bool Delete(ref DbTransaction transaction, int id);
    }
}
