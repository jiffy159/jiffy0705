using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jiffy0705.Data;
using Microsoft.EntityFrameworkCore;

namespace jiffy0705.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: 电影
        public async Task<IActionResult> Index()
        {
            return View(await _context.电影.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "下.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "为.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
