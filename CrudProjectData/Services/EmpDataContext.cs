using CrudProjectData.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProjectData.Services
{
    public class EmpDataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
