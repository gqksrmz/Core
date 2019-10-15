using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloWorld.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            //电子交易产品研发
            dynamic obj = new System.Dynamic.ExpandoObject();
            obj.Id = 1;
            obj.Name = "Test";
            string json = JsonConvert.DeserializeObject<dynamic>(obj);
            Console.WriteLine(json);



            return View();
        }
    }
}