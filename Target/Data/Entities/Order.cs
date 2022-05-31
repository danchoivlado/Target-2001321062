using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {
        public Nullable<int> UserID { get; set; }
        public virtual User User { get; set; }
    }
}
