using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    public class HomeController
    {
        public HomeController()
        {

        }
        public string Index()
        {
            return "你好，世界! 此消息来自 HomeController...";
        }
    }
}
