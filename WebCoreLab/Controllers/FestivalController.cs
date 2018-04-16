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
    
    public class FestivalController : BaseController
    {
        private MyContext context { get; set; }

        public FestivalController(MyContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult list()
        {
            List<Festival> list = context.Festivals.ToList();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Message"] = "list";
            if (id == null)
            {
                return NotFound();
            }

            var festival = await context.Festivals.Include(s => s.LineUps).AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);

            if (festival == null)
            {
                return NotFound();
            }

            return View(festival);
        }

        [RedirectFilterNotAdmin]
        [HttpGet]
        public IActionResult edit(long? id)
        {
            Festival festival = id.HasValue ? context.Festivals.FirstOrDefault(x => x.Id == id.Value) :
                                              new Festival() { StartDate = DateTime.Now, EndDate = DateTime.Now };

            return View(festival);
        }

        [RedirectFilterNotAdmin]
        [HttpPost]
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


        [RedirectFilterNotAdmin]
        [HttpGet]
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