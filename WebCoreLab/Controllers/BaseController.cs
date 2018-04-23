using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using WebCoreLab.Data;

namespace WebCoreLab.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext context { get; set; }

        protected BaseController(ApplicationDbContext _context)
        {
            context = _context;
        }
    }
    
}