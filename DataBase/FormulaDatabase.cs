using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fromulaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace fromulaApi.DataBase
{
    public class FormulaDatabase : DbContext
    {
        public FormulaDatabase(DbContextOptions<FormulaDatabase> options) : base(options)
        {
            
        }

        public DbSet<Driver> Drivers { get; set; }
    }
}