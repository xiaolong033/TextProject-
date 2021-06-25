using Dorm.IDAL;
using Dorm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseModel, new()
    {
        private DormEntity dormEntity = new DormEntity();
        public async Task Create(T t, bool IsSave = true)
        {
            dormEntity.Set<T>().Add(t);
            if (IsSave)
                await dormEntity.SaveChangesAsync();
        }

        public void Dispose()
        {
            dormEntity.Dispose();
        }

        public async Task Edit(T t, bool IsSave = true)
        {
            dormEntity.Entry(t).State = EntityState.Modified;
            if (IsSave)
                await dormEntity.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return dormEntity.Set<T>().Where(m => !m.IsRemoved).AsNoTracking();
        }

        public Task<T> GetOne(int id)
        {
            return GetAll().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Remove(int id, bool IsSave = true)
        {
            dormEntity.Configuration.ValidateOnSaveEnabled = false;
            T t = new T() { Id = id };
            dormEntity.Entry(t).State = EntityState.Unchanged;
            t.IsRemoved = true;
            if (IsSave)
                await dormEntity.SaveChangesAsync();


            dormEntity.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
