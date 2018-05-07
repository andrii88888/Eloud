using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreLab.Data;
using WebCoreLab.Domain;
using Microsoft.AspNetCore.Identity;
using WebCoreLab.Models;

namespace WebCoreLab.Controllers
{

    public class ArtistController : BaseController
    {
        public ArtistController(ApplicationDbContext _context) : base(_context) {}

        [HttpGet]
        public async Task<IActionResult> ArtistsVariety(string searchString)
        {
            ViewData["Message"] = "ArtistsVariety";
            ViewData["CurrentFilter"] = searchString;
            var artists = from s in context.Artists
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(s => s.Name.Contains(searchString)
                                       || s.Country.Contains(searchString));
            }

            List<Artist> list = await artists.AsNoTracking().ToListAsync();
            //return View(list);
            //List<Artist> list = context.Artists.ToList();
            return View("ArtistsVariety", list);
        }

        
        [HttpGet]
        public async Task<IActionResult> List(string searchString)
        {
            ViewData["Message"] = "Artists";
            ViewData["CurrentFilter"] = searchString;

            var artists = from s in context.Artists
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(s => s.Name.Contains(searchString)
                || s.Country.Contains(searchString));
            }
            //List<Artist> list = context.Artists.ToList();
            List<Artist> list = await artists.AsNoTracking().ToListAsync();
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

       


        [HttpGet]
        public IActionResult Subscribe(int? id)

        {
            ViewData["Message"] = "Details";
            if (id == null)
            {
                return NotFound();
            }
            //var currArtist = new Artist(id, );

            var subscription = new Subscribtion(User.Identity.Name, (int)id);
            context.Subscribers.Add(subscription);
            context.SaveChanges();

            //var sub = await context.Subscribers.Include(s=>s.UserEmail).AsNoTracking().SingleOrDefaultAsync(m => m.ArtistID == id);
            // var sub = context.Subscribers.Where(s => s.Id == id).ToList();

            //if (sub == null)
            //{
            //    return NotFound();
            //}

            //View("ArtistSubs",sub);
            //return View("Details");
            return RedirectToPage("Home/Index");
        }

        [HttpGet]
        public ActionResult Unfollow(Subscribtion model)
        {
            if(context.Subscribers.Contains(model))
            {
                context.Subscribers.Remove(model);

                context.SaveChanges();
            }
            // list = context.Artists.ToList();

            return View("list");
        }

        [HttpGet]
        public IActionResult edit(long? id)
        {
            ViewData["Message"] = "List";
            Artist artist = id.HasValue ? context.Artists.FirstOrDefault(x => x.ID == id.Value) :
                                              new Artist() { };

            return View(artist);
        }

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
