
using Dorm.Dto;
using Dorm.IBLL;
using Dorm.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Dorm.BLL
{
    public class AdminManager : IAdminManager
    {
        public IAdminService adminService { get; set; }
         public async Task<AdminUser> Login(string name, string pwd)
        {
            using (adminService)
            {
                return  await adminService.GetAll().Select(m=>new AdminUser() { LoginName=m.LoginName,LoginPwd=m.LoginPwd}).FirstOrDefaultAsync(m => m.LoginName == name && m.LoginPwd == pwd);
            }
        }
    }
}
