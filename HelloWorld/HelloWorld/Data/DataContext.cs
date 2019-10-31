using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
