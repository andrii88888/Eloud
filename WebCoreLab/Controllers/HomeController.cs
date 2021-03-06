﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Models;
using WebCoreLab.Domain;
using System.Globalization;
using WebCoreLab.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebCoreLab.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext _context) : base(_context) { }

        public async Task<IActionResult> Index(int? SelectedYear, string SelectedMonth, string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CountrySortParm"] = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "country";
            ViewData["CurrentFilter"] = searchString;
            var list = from s in context.Festivals
                          select s;
            //List<Festival> list = context.Festivals.ToList();
           
            if (SelectedYear.HasValue)
            {
                list = list.Where(x => x.StartDate.Year == SelectedYear.Value);//.ToList();
            }

            if (!String.IsNullOrEmpty(SelectedMonth))
            {
                DateTimeFormatInfo dfi = new DateTimeFormatInfo();

                int month = dfi.MonthNames.ToList().IndexOf(SelectedMonth) + 1;

                list = list.Where(x => x.StartDate.Month == month);//.ToList();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Name.Contains(searchString)
                                       || s.Country.Contains(searchString)
                                       || s.City.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    list = list.OrderByDescending(s => s.StartDate);
                    break;
                case "country_desc":
                    list = list.OrderByDescending(s => s.Country);
                    break;
                case "country":
                    list = list.OrderBy(s => s.Country);
                    break;
                case "date_desc":
                    list = list.OrderBy(s => s.StartDate);
                    break;
                default:
                    list = list.OrderBy(s => s.Name);
                    break;
            }
            FestivalListModel model = new FestivalListModel(list.ToList());

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
