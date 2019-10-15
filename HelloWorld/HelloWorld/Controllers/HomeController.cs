using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    public class HomeController:Controller
    {
        public HomeController()
        {
            
        }
      public ViewResult Index()
        {
            var model = new Employee { ID = 1, Name = "张飞" };
            return View(model);
        }
    }
    public class SQLEmployeeData
    {
        private HelloWorldDBContext _context { get; set; }
        public SQLEmployeeData(HelloWorldDBContext context)
        {
            _context = context;
        }
        public void Add(Employee emp)
        {
            _context.Add(emp);
            _context.SaveChanges();
        }
        public Employee Get(int ID)
        {
            return _context.Employees.FirstOrDefault(e => e.ID == ID);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList<Employee>();
        }

    }
    public class HomePageViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
