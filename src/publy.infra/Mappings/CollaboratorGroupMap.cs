using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publy.Domain.Entities;

namespace Publy.Infra.Mappings
{
  public class CollaboratorGroupMap : IEntityTypeConfiguration<CollaboratorGroup>
  {
    public void Configure(EntityTypeBuilder<CollaboratorGroup> builder)
    {
      builder.ToTable("collaborators_groups");
      builder.HasKey(cg => new { cg.CollaboratorId, cg.GroupId });

      builder.Property(cg => cg.CollaboratorId)
        .HasColumnName("collaborator_id")
        .HasColumnType("uuid")
        .IsRequired();

      builder.Property(cg => cg.GroupId)
        .HasColumnName("group_id")
        .HasColumnType("uuid")
        .IsRequired();

      builder.HasOne(cg => cg.Collaborator)
        .WithMany(c => c.Groups)
        .HasForeignKey(cg => cg.CollaboratorId);

      builder.HasOne(cg => cg.Group)
        .WithMany(g => g.Collaborators)
        .HasForeignKey(cg => cg.GroupId);
    }
  }
}
