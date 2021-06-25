using Dorm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.IDAL
{
    public interface IBaseService<T> : IDisposable where T : BaseModel
    {
        Task Create(T t, bool IsSave = true);
        Task Remove(int id, bool IsSave = true);

        Task Edit(T t, bool IsSave = true);

        IQueryable<T> GetAll();

        Task<T> GetOne(int id);
    }
}
