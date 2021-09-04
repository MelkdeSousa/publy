using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publy.Domain.Entities;

namespace Publy.Infra.Mappings
{
  public class CollaboratorDepartmentMap : IEntityTypeConfiguration<CollaboratorDepartment>
  {
    public void Configure(EntityTypeBuilder<CollaboratorDepartment> builder)
    {
      builder.ToTable("collaborators_departments");
      builder.HasKey(cd => new { cd.CollaboratorId, cd.DepartmentId });

      builder.Property(cd => cd.CollaboratorId)
        .HasColumnName("collaborator_id")
        .HasColumnType("uuid")
        .IsRequired();

      builder.Property(cd => cd.DepartmentId)
        .HasColumnName("department_id")
        .HasColumnType("uuid")
        .IsRequired();

      builder.HasOne(cd => cd.Collaborator)
        .WithMany(c => c.Departments)
        .HasForeignKey(cd => cd.CollaboratorId);

      builder.HasOne(cd => cd.Department)
        .WithMany(d => d.Collaborators)
        .HasForeignKey(cd => cd.DepartmentId);
    }
  }
}
