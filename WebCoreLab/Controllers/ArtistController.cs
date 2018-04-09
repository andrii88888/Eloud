using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Domain.Context;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreLab.Controllers
{
    public class ArtistController : Controller
    {
        private MyContext context { get; set; }

        public ArtistController(MyContext _context)
        {
            context = _context;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
