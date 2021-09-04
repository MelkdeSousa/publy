using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publy.Domain.Entities;

namespace Publy.Infra.Mappings
{
  public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
  {
    public void Configure(EntityTypeBuilder<Collaborator> builder)
    {
      builder.ToTable("collaborators");
      builder.HasKey(c => c.Id);

      builder.Property(c => c.Id)
        .HasColumnName("id")
        .HasColumnType("uuid")
        .HasDefaultValueSql("uuid_generate_v4()")
        .IsRequired();

      builder.Property(c => c.Name)
        .HasColumnName("name")
        .HasColumnType("text")
        .IsRequired();

      builder.Property(c => c.Email)
        .HasColumnName("email")
        .HasColumnType("text")
        .IsRequired();

      builder.Property(c => c.Password)
        .HasColumnName("password")
        .HasColumnType("text")
        .IsRequired();

      builder.Property(c => c.BirthDate)
        .HasColumnName("birth_date")
        .HasColumnType("date")
        .IsRequired();

      builder.Property(c => c.SocialNetworks)
        .HasColumnName("social_networks")
        .HasColumnType("text[]");

      builder.Property(c => c.DescriptionProfile)
        .HasColumnName("description_profile")
        .HasColumnType("text");
    }
  }
}
