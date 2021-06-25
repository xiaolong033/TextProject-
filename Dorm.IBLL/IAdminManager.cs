using Dorm.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.IBLL
{
    public interface IAdminManager
    {
        Task<AdminUser> Login(string name, string pwd);
    }
}
