using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreLab.Domain;
using WebCoreLab.Domain.Context;

namespace WebCoreLab.Controllers
{
    [RedirectFilterNotAdmin]
    public class ArtistController : BaseController
    {
        private MyContext context { get; set; }

        public ArtistController(MyContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewData["Message"] = "Artists";
            List<Artist> list = context.Artists.ToList();
            return View(list);
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var artist = await context.Artists.Include(a=> a.LineUps)

            //if (artist == null)
            //{
            //    return NotFound();
            //}

            return View(/*artist*/);
        }
    }
}
