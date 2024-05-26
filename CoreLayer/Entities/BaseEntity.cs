using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int Delete { get; set; } = 0;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; }
    }
}
