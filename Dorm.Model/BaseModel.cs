using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.Model
{
    public class BaseModel
    {
        public int Id { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
