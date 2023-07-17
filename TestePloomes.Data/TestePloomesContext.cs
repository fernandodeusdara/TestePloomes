using Microsoft.EntityFrameworkCore;
using TestePloomes.Data.Entidades;

namespace TestePloomes.Data {
    public partial class TestePloomesContext : DbContext
    {
        public TestePloomesContext()
        {
        }

        public TestePloomesContext(DbContextOptions<TestePloomesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}