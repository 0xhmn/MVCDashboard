using System.Data.Entity;
using CSOMLocalDataProvider;

namespace CSOMLocalDataProvider
{
    public class CSOMContext : DbContext
    {
        public CSOMContext() : base("Database")
        {
        }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Term> Terms { get; set; }
    }
}