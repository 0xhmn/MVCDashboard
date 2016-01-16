using System;
using System.Linq;

namespace CSOMLocalDataProvider
{
    public class Generator
    {
        public static void Main(string[] args)
        {
            // InsertTerm();
            GetAllPrograms();
        }

        public static void InsertTerm()
        {
            var newTerm = new Term
            {
                TermTitle = "Term #8",
                DateStart = new DateTime(2004, 2, 5),
                DateEnd = new DateTime(2006, 12, 1),
                TermIdNumber = 8,
                ProgramId = 3
            };
            using (var context = new CSOMContext())
            {
                context.Terms.Add(newTerm);
                context.SaveChanges();
            }
        }

        public static void GetAllPrograms()
        {
            using (var db = new CSOMContext())
            {
               var programList = db.Programs.Select(p => p.ProgramTitle).ToList();
                programList.ForEach(t => Console.WriteLine(t));
            }
            
        }
    }
}
