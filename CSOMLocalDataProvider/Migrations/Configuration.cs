using System.Collections.Generic;
using System.Data.Odbc;

namespace CSOMLocalDataProvider.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CSOMLocalDataProvider.CSOMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CSOMLocalDataProvider.CSOMContext";
        }

        protected override void Seed(CSOMLocalDataProvider.CSOMContext context)
        {            
            
            // creating programs
            var defPrograms = new List<Program>
            {
                new Program
                {
                    ProgramTitle = "Executive MBA",
                    ProgramDescription = "Executive MBA Description",
                },
                new Program
                {
                    ProgramTitle = "Part-Time MBA",
                    ProgramDescription = "PART TIME PROGRAM DESCRIPTION",
                },
                new Program
                {
                    ProgramTitle = "Full-Time MBA",
                    ProgramDescription = "Full-Time MBA Description",
                }
            };

            // submiting the programs
            defPrograms.ForEach(p => context.Programs.AddOrUpdate(p));
            context.SaveChanges();

            var defTerms = new List<Term>
            {
                new Term
                {
                    TermTitle = "Term #1 Summer",
                    DateStart = new DateTime(2009, 1,1),
                    DateEnd = new DateTime(2010, 1, 1),
                    TermIdNumber = 1,
                    ProgramId = 1
                },
                new Term
                {
                    TermTitle = "Term #1 Spring",
                    DateStart = new DateTime(2009, 1,1),
                    DateEnd = new DateTime(2010, 1, 1),
                    TermIdNumber = 1,
                    ProgramId = 1
                },
                new Term
                {
                    TermTitle = "Term #2",
                    DateStart = new DateTime(1999, 1,1),
                    DateEnd = new DateTime(2000, 1, 1),
                    TermIdNumber = 2,
                    ProgramId = 1
                },
                new Term
                {
                    TermTitle = "Term #3",
                    DateStart = new DateTime(2006, 2, 4),
                    DateEnd = new DateTime(2008, 10, 19),
                    TermIdNumber = 3,
                    ProgramId = 1
                },
                new Term
                {
                    TermTitle = "Term #4",
                    DateStart = new DateTime(2003, 3, 3),
                    DateEnd = new DateTime(2005, 2,4),
                    TermIdNumber = 4,
                    ProgramId = 1
                },
                new Term
                {
                    TermTitle = "Term #5",
                    DateStart = new DateTime(2016, 2,2),
                    DateEnd = new DateTime(2018, 2,1),
                    TermIdNumber = 5,
                    ProgramId = 3
                },
                new Term
                {
                    TermTitle = "Term #6",
                    DateStart = new DateTime(2004, 2, 5),
                    DateEnd = new DateTime(2006, 12,1),
                    TermIdNumber = 6,
                    ProgramId = 2
                },
                new Term
                {
                    TermTitle = "Term #7",
                    DateStart = new DateTime(2005, 2, 4),
                    DateEnd = new DateTime(2009, 2, 3),
                    TermIdNumber = 7,
                    ProgramId = 2
                },
            };

            // defining terms
            defTerms.ForEach(t => context.Terms.AddOrUpdate(t));
            context.SaveChanges();
        }
    }
}
