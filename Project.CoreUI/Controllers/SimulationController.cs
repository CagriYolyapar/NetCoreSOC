using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services.Abstracts;
using Project.ENTITIES.Models;

namespace Project.CoreUI.Controllers
{
    public class SimulationController : Controller
    {

        IProductManager _irp;
        IUserManagerSpecial _iup;

        public SimulationController(IProductManager irp, IUserManagerSpecial iup)
        {
            _irp = irp;
            _iup = iup;
        }
        public async Task<IActionResult> Index()
        {
            IdentityUser newUser = new IdentityUser { UserName = "cgr1", Email = "cgr@gmail.com", PasswordHash = "123456789" };

            await _iup.TestUser(newUser);

            Product p = new Product();
             _irp.IntTest(p);
            return View();
        }
    }
}
