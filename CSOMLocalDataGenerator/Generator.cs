using System;
using CSOMLocalDataProvider;

namespace CSOMLocalDataGenerator
{
    public class Generator
    {
        public static void Main(string[] args)
        {
            InsertProgram();
            // Console.Read();
        }

        public static void InsertProgram()
        {
            var test = new Program
            {
                ProgramTitle = "final another test here",
                ProgramDescription = "sample Description"
            };
            using (var context = new CSOMContext())
            {
                context.Programs.Add(test);
                context.SaveChanges();
            }
        }
    }
}
