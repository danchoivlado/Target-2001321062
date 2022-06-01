using ApplicationService.DTOs;
using ApplicationService.Implementaions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Orders;
using MVC.Models.Users;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private OrderManagementService orderManagementService = new OrderManagementService();
        private UserManagementService userManagementService = new UserManagementService();

        public IActionResult Index()
        {
            List<OrdersIndexViewModel> ordersVM = new List<OrdersIndexViewModel>();
            foreach (var order in orderManagementService.Get())
            {
                ordersVM.Add(new OrdersIndexViewModel(order));
            }

            return View(ordersVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<UserIndexViewModel> usersVM = new List<UserIndexViewModel>();
            foreach (var user in userManagementService.Get())
            {
                usersVM.Add(new UserIndexViewModel(user));
            }
            ViewBag.users = usersVM;
            return View(new OrderCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel orderCreateView)
        {
            OrderDTO orderDTO = new OrderDTO();
            orderDTO.UserId = orderCreateView.UserId;
            orderManagementService.Save(orderDTO);

            return RedirectToAction("index");
        }
    }
}
