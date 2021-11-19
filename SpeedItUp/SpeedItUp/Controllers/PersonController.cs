using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedItUp.Data;
using SpeedItUp.Models;

namespace SpeedItUp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = this._context.Users.Where(x => x.Id == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .Select(u => new PersonViewModel { FullName = u.UserName, Children = u.Children }).FirstOrDefault();
            return View(user);
        }
    }
}
