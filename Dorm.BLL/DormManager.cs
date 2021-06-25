using Dorm.Dto;
using Dorm.IBLL;
using Dorm.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.BLL
{
    public class DormManager:IDormManager
    {
        public IDormService  dormService { get; set; }

        public async Task AddDorm(int no, int count)
        {
            using (dormService)
            {
               await dormService.Create(new Model.MyDorm() { Count = count, NumberNO = no });
            }
        }

        public async Task Edit(int id, int No, int count)
        {
            using (dormService)
            {
                await dormService.Edit(new Model.MyDorm() { Id = id, NumberNO = No, Count = count });
            }
        }

        public async Task<List<DormDto>> GetDorm()
        {
            using (dormService)
            {
             return  await dormService.GetAll().Select(m => new DormDto() { Dno = m.NumberNO, Id = m.Id, Count = m.Count }).ToListAsync();
            }
        }

        public async Task Removed(int id)
        {
            using (dormService)
            {
               await  dormService.Remove(id);
            }
        }
    }
}
