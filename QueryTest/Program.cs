using System;
using System.Linq;
using CSOMLocalDataProvider;

namespace QueryTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // InsertTerm();
            GetAllPrograms();
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
