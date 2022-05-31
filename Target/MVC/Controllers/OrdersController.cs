using ApplicationService.Implementaions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Orders;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private OrderManagementService orderManagementService = new OrderManagementService();

        public IActionResult Index()
        {
            List<OrdersIndexViewModel> ordersVM = new List<OrdersIndexViewModel>();
            foreach (var order in orderManagementService.Get())
            {
                ordersVM.Add(new OrdersIndexViewModel(order));
            }

            return View(ordersVM);
        }
    }
}
