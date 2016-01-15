namespace CSOMLocalDataProvider
{
    public class Generator
    {
        public static void Main(string[] args)
        {
            var program = new Program
            {
                ProgramTitle = "sample title",
                ProgramDescription = "sample description"
            };

            using (var context = new CSOMContext())
            {
                context.Programs.Add(program);
                context.SaveChanges();
            }
        }
    }
}
