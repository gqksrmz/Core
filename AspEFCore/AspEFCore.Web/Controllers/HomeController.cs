using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var province = new Province
            {
                Name = "天津",
                Population = 10000000
            };
            var company = new Company
            {
                Name = "TaiDa",
                EstablishDate = new DateTime(1998, 1, 1),
                LegalPerson = "Secret Man"
            };
            // _context.Provinces.Add(province);
            // _context.Provinces.AddRange(province, province1, province2);
            //_context.Provinces.AddRange(new List<Province>
            //{
            //    province,province1,province2
            //});
            _context.AddRange(province, company);
            _context.SaveChanges();
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

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
