using Dorm.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.IBLL
{
    public interface IDormManager
    {
        Task<List<DormDto>> GetDorm();

        Task AddDorm(int no, int count);

        Task Removed(int id);

        Task Edit(int id, int No, int count);
    }
}
