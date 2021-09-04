﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Publy.Infra.Context;

namespace publy.infra.Migrations
{
    [DbContext(typeof(PublyContext))]
    [Migration("20210904163212_CreateCollaboratorAndDepartmentEntitiesAndRelationship")]
    partial class CreateCollaboratorAndDepartmentEntitiesAndRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Publy.Domain.Entities.Collaborator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("DescriptionProfile")
                        .HasColumnType("text")
                        .HasColumnName("description_profile");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<List<string>>("SocialNetworks")
                        .HasColumnType("text[]")
                        .HasColumnName("social_networks");

                    b.HasKey("Id");

                    b.ToTable("collaborators");
                });

            modelBuilder.Entity("Publy.Domain.Entities.CollaboratorDepartment", b =>
                {
                    b.Property<Guid>("CollaboratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("collaborator_id");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.HasKey("CollaboratorId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("collaborators_departments");
                });

            modelBuilder.Entity("Publy.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Publy.Domain.Entities.CollaboratorDepartment", b =>
                {
                    b.HasOne("Publy.Domain.Entities.Collaborator", "Collaborator")
                        .WithMany("Departments")
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Publy.Domain.Entities.Department", "Department")
                        .WithMany("Collaborators")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborator");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Publy.Domain.Entities.Collaborator", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Publy.Domain.Entities.Department", b =>
                {
                    b.Navigation("Collaborators");
                });
#pragma warning restore 612, 618
        }
    }
}
