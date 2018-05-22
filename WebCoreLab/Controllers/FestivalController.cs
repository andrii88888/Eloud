using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreLab.Data;
using WebCoreLab.Domain;
using WebCoreLab.Models;

namespace WebCoreLab.Controllers
{
   
    public class FestivalController : BaseController
    {
        public FestivalController(ApplicationDbContext _context) : base(_context) { }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> list(string sortOrder, string searchString)
        {
            
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var fests = from s in context.Festivals
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                fests = fests.Where(s => s.Name.Contains(searchString)
                                       || s.Country.Contains(searchString)
                                       || s.City.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    fests = fests.OrderByDescending(s => s.Name);
                    break;
                default:
                    fests = fests.OrderBy(s => s.Name);
                    break;
            }

            return View(await fests.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            registerView(id);

            var festival = await context.Festivals.Include(s => s.LineUps).ThenInclude(a => a.Artist)
                .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);

            if (festival == null)
            {
                return NotFound();
            }

            return View(festival);
        }

        private void registerView(int? id)
        {

            context.ViewUserEvent.Add(new ViewUserEvent(User.Identity.Name, id, DateTime.Now));
           
            context.SaveChanges();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult edit(long? id)
        {
            Festival festival = id.HasValue ? context.Festivals.FirstOrDefault(x => x.Id == id.Value) :
                                              new Festival() { StartDate = DateTime.Now, EndDate = DateTime.Now };

            return View(festival);
        }

        //[HttpGet]
        //public IActionResult editLineUp(long? id)
        //{
        //    LineUp festival = id.HasValue ? context.LineUps.FirstOrDefault(x => x.LineUpID == id.Value) :
        //                                      new LineUp() {};

        //    return View(festival);
        //}

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult edit(Festival model)
        {
            try
            {
                Festival festival = model.Id != 0 ? context.Festivals.FirstOrDefault(x => x.Id == model.Id) : new Festival();

                if (festival.Id == 0)
                {
                    if (String.IsNullOrEmpty(model.Name))
                        throw new Exception("Fill in the fields!");
                }

                festival.Name = model.Name;
                festival.Country = model.Country;
                festival.City = model.City;
                festival.StartDate = model.StartDate;
                festival.EndDate = model.EndDate;
                festival.Description = model.Description;
                festival.ImageLink = model.ImageLink;

                if (festival.Id == 0)
                    context.Festivals.Add(festival);

                context.SaveChanges();

              

                List<Festival> list = context.Festivals.ToList();

                return View("list", list);
            }
            catch (Exception ex)
            {
                //Error = ex.Message;
            }

            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult remove(Festival model)
        {
            List<Festival> list = context.Festivals.ToList();

            try
            {
                Festival festival = model.Id != 0 ? context.Festivals.FirstOrDefault(x => x.Id == model.Id) : null;

                if (festival != null)
                {
                    context.Festivals.Remove(festival);

                    context.SaveChanges();

                    list = context.Festivals.ToList();
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