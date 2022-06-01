using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FlowerId { get; set; }
        public int Quantity { get; set; }
        public virtual FlowerDTO Flower { get; set; }
        public virtual OrderDTO Order { get; set; }
    }
}
