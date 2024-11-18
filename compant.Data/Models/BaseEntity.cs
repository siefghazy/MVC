using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comapny.Data.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? createdAt { get; set; } = DateTime.Now;
        public bool? isDeleted { get; set; }
    }
}
