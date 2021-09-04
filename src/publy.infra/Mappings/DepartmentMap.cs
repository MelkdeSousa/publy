using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publy.Domain.Entities;

namespace Publy.Infra.Mappings
{
  public class DepartmentMap : IEntityTypeConfiguration<Department>
  {
    public void Configure(EntityTypeBuilder<Department> builder)
    {
      builder.ToTable("departments");
      builder.HasKey(d => d.Id);

      builder.Property(d => d.Id)
        .HasColumnName("id")
        .HasColumnType("uuid")
        .HasDefaultValueSql("uuid_generate_v4()")
        .IsRequired();

      builder.Property(d => d.Name)
        .HasColumnName("name")
        .HasColumnType("text")
        .IsRequired();
    }
  }
}
