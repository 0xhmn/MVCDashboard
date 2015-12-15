using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSOM.STS.DataAccess;

namespace Dashboard.Models
{
    public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }

        public TestClass GetFromDb(CSOMContext dbContext)
        {
            var app = dbContext.APPLICATIONS.Find(8206847);

            Id = app.PROGRAM_ID;
            Name = app.PROGRAM.PROGRAM1;
            Term = app.TERM.TERM1;
            return this;
        }
    }
}