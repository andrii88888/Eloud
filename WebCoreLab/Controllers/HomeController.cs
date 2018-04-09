using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Models;
using WebCoreLab.Domain.Context;
using Microsoft.EntityFrameworkCore;
using WebCoreLab.Domain;
using System.Globalization;

namespace WebCoreLab.Controllers
{
    public class HomeController : BaseController
    {
        private MyContext context { get; set; }

        public HomeController(MyContext _context)
        {
            context = _context;
        }

        public IActionResult Index(int? SelectedYear, string SelectedMonth)
        {
            List<Festival> list = context.Festivals.ToList();

            if (SelectedYear.HasValue)
            {
                list = list.Where(x => x.StartDate.Year == SelectedYear.Value).ToList();
            }

            if (!String.IsNullOrEmpty(SelectedMonth))
            {
                DateTimeFormatInfo dfi = new DateTimeFormatInfo();

                int month = dfi.MonthNames.ToList().IndexOf(SelectedMonth) + 1;

                list = list.Where(x => x.StartDate.Month == month).ToList();
            }

            FestivalListModel model = new FestivalListModel(list);

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Artist()
        {
            ViewData["Message"] = "Artists";

            return View(context.Artists.ToList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult login()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult logout()
        {
            CurUser = null;

            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult login(LoginModel model)
        {
            if (!String.IsNullOrEmpty(model.Email) && !String.IsNullOrEmpty(model.Password))
            {
                Domain.User user = context.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == model.Email);

                if (user != null && user.Password == model.Password)
                {
                    CurUser = user;

                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
