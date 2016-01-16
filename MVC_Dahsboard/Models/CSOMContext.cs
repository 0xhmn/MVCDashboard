using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Dahsboard.Models
{
    public class CSOMContext : DbContext
    {
        public CSOMContext() : base("DashboardContext")
        {
        }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Term> Terms { get; set; }

    }
}