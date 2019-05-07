using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.DataAccess
{
    public interface IExcelRepository<T>
    {
        IEnumerable<T> All();
        T Add(T entity);
        bool Delete(Guid id);
        bool Update(Guid id, T entity);
        T FindById(Guid id);

    }
}
