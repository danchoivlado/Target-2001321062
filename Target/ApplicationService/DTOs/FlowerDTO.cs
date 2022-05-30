using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class FlowerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public double Price { get; set; }
    }
}
