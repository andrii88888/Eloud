using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Controllers
{
    [Authorize(Roles = "admin")]
    public class StatsController : Controller
    {
        [HttpGet]
        public IActionResult stats()
        {
            return View("StatsMain");
        }
    }
}
