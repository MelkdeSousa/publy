using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publy.Domain.Entities;

namespace Publy.Infra.Mappings
{
  public class GroupMap : IEntityTypeConfiguration<Group>
  {
    public void Configure(EntityTypeBuilder<Group> builder)
    {
      builder.ToTable("groups");
      builder.HasKey(g => g.Id);

      builder.Property(g => g.Id)
        .HasColumnName("id")
        .HasColumnType("uuid")
        .HasDefaultValueSql("uuid_generate_v4()")
        .IsRequired();

      builder.Property(g => g.Name)
        .HasColumnName("name")
        .HasColumnType("text")
        .IsRequired();
    }
  }
}
