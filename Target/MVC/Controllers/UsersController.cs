using ApplicationService.Implementaions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Users;
using System.Net;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private UserManagementService userManagementService = new UserManagementService();

        public IActionResult Index()
        {
            List<UserIndexViewModel> usersVM = new List<UserIndexViewModel>();
            foreach (var user in userManagementService.Get())
            {
                usersVM.Add(new UserIndexViewModel(user));
            }


            return View(usersVM);
        }

        //[Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            var user = userManagementService.GetById(id);

            return View(new UserIndexViewModel(user));
        }
    }
}
