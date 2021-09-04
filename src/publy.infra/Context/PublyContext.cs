using Microsoft.EntityFrameworkCore;
using Publy.Domain.Entities;
using Publy.Infra.Mappings;

namespace Publy.Infra.Context
{
  public class PublyContext : DbContext
  {
    public PublyContext()
    { }

    public PublyContext(DbContextOptions<PublyContext> options) : base(options)
    {
    }

    public virtual DbSet<Collaborator> Collaborators { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<CollaboratorDepartment> CollaboratorsDepartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5430;Database=publy;User Id=@melkdesousa;Password=238901;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasPostgresExtension("uuid-ossp");

      modelBuilder.ApplyConfiguration(new CollaboratorMap());
      modelBuilder.ApplyConfiguration(new DepartmentMap());
      modelBuilder.ApplyConfiguration(new CollaboratorDepartmentMap());
    }
  }
}
