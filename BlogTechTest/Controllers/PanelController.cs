using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTechTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
