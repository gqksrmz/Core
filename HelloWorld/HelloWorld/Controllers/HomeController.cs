using HelloWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ViewResult Index()
        {

            var model = new Employee {ID = 1, Name = "张飞"};

            List<string> fruits = new List<string>
            {
                "apple", "passionfruit", "banana", "mango",
                "orange", "blueberry", "grape", "strawberry"
            };
            // List<string> query = fruits.Where(fruit => fruit.Length < 6).ToList();
            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);
            IEnumerable<string> query2 = from item in fruits
                where item.Length > 6
                select item;
            Console.WriteLine("hello world");
            Console.WriteLine("hello world");
            return View(model);
        }
        [Authorize]
        public IActionResult TestResult()
        {
            return Content("HELLO ");
        }
    }
}
