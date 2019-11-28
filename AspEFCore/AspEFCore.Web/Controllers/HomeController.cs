using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspEFCore.Web.Models;
using AspEFCore.Domain;
using AspEFCore.Data;

namespace AspEFCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var provinces = _context.Provinces.Where(x => x.Name == "北京").ToList();
            Console.WriteLine("Hello world!");
            Console.WriteLine("Hello world!");
            string s = null;
            char str = ' ';
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            Task ta = new TaskFactory().StartNew(() => { });
            return View();
        }

        public IActionResult Privacy()
        {
            Console.WriteLine("aaa");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
