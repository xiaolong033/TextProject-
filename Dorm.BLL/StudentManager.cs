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
    public class StudentManager : IStudentManager
    {
        public IStudentService studentService { get; set; }
        public async Task AddStu(string name, string phone, int dno)
        {
            using (studentService)
            {
               await studentService.Create(new Model.Student() { Name = name, Phone = phone, DromNo = dno });
            }
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            using (studentService)
            {
                return await studentService.GetAll().Include(m=>m.MyDorm).Select(m => new StudentDto() { Name = m.Name, Phone = m.Phone, Id = m.Id, DormId = m.DromNo, DormNo = m.MyDorm.NumberNO }).ToListAsync();
            }
        }

        public async Task<List<StudentDto>> GetStudents(int dormno)
        {
            var res = await GetStudents();
            return res.Where(m => m.DormId == dormno).ToList();
        }
    }
}
