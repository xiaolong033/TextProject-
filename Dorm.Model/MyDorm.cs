using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.Model
{
  public class MyDorm:BaseModel
    {
        /// <summary>
        /// 宿舍号
        /// </summary>
        public int NumberNO { get; set; }
        /// <summary>
        /// 宿舍人数
        /// </summary>
        public int Count { get; set; }
    }
}
