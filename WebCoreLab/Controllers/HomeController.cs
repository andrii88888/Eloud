using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Models;
using WebCoreLab.Domain;
using System.Globalization;
using WebCoreLab.Data;

namespace WebCoreLab.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext _context) : base(_context) { }

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
