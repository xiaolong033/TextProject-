using Dorm.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.IBLL
{
    public interface IStudentManager
    {
        Task<List<StudentDto>> GetStudents();

        Task<List<StudentDto>> GetStudents(int dormno);

        Task AddStu(string name, string phone, int dno);
    }
}
