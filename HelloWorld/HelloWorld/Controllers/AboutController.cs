using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    //[Route("about")]
    [Route("[controller]")]
    public class AboutController
    {
        public AboutController()
        {

        }
        [Route("")]
        public string Phone()
        {
            return "+10086";
        }
        //[Route("country")]
        [Route("[action]")]
        public string Country()
        {
            return "中国";
        }
    }
}
