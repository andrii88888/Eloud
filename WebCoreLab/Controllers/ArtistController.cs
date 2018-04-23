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

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Message"] = "List";
            if (id == null)
            {
                return NotFound();
            }

            var artist = await context.Artists.Include(s => s.LineUps).ThenInclude(l=>l.Festival).AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [RedirectFilterNotAdmin]
        [HttpGet]
        public IActionResult edit(long? id)
        {
            ViewData["Message"] = "List";
            Artist artist = id.HasValue ? context.Artists.FirstOrDefault(x => x.ID == id.Value) :
                                              new Artist() { };

            return View(artist);
        }

        [RedirectFilterNotAdmin]
        [HttpPost]
        public ActionResult edit(Artist model)
        {
            try
            {
                Artist artist = model.ID != 0 ? context.Artists.FirstOrDefault(x => x.ID == model.ID) : new Artist();

                if (artist.ID == 0)
                {
                    if (String.IsNullOrEmpty(model.Name))
                        throw new Exception("Fill in the fields!");
                }

                artist.Name = model.Name;
                artist.Country = model.Country;
                artist.Description = model.Description;
                artist.LineUps = model.LineUps;

                artist.ImageLink = model.ImageLink;

                if (artist.ID == 0)
                    context.Artists.Add(artist);

                context.SaveChanges();



                List<Artist> list = context.Artists.ToList();

                return View("list", list);
            }
            catch (Exception ex)
            {
                //Error = ex.Message;
            }

            return View(model);
        }


        [RedirectFilterNotAdmin]
        [HttpGet]
        public ActionResult remove(Artist model)
        {
            List<Artist> list = context.Artists.ToList();

            try
            {
                Artist artist = model.ID != 0 ? context.Artists.FirstOrDefault(x => x.ID == model.ID) : null;

                if (artist != null)
                {
                    context.Artists.Remove(artist);

                    context.SaveChanges();

                    list = context.Artists.ToList();
                }


            }
            catch (Exception ex)
            {
                //Error = ex.Message;
            }

            return View("list", list);
        }
    }
}
