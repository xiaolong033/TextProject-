using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.Model
{
    public class Student:BaseModel
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 宿舍号
        /// </summary>
        [ForeignKey(nameof(MyDorm))]
       
        public int DromNo { get; set; }

        public MyDorm MyDorm { get; set; }
    }
}
