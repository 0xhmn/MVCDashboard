using System.Data.Entity;

namespace CSOMDataProvider
{
    class CSOMContext : DbContext
    {
        public DbSet<Program> Programs { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TermApplyActive> ActiveTerms { get; set; }
    }
}
