using ApplicationService.DTOs;

namespace MVC.Models.Orders
{
    public class OrdersIndexViewModel
    {
        public int Id { get; set; }

        public OrdersIndexViewModel(OrderDTO orderDTO)
        {
            this.Id = orderDTO.Id;
        }
        public OrdersIndexViewModel()
        {

        }
    }
}
