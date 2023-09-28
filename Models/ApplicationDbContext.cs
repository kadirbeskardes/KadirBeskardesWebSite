using System.Data.Entity;

namespace KadirBeskardes.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(string connectionString):base(connectionString) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetail> ProjectDetail { get; set; }
        public DbSet<IletisimFormModel> IletisimFormModels { get; set; }
    }
}
