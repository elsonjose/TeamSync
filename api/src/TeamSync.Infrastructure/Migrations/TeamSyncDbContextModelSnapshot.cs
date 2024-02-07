﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Linq;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamSync.Infrastructure.Implementation.Database;

#nullable disable

namespace TeamSync.Infrastructure.Migrations
{
    [DbContext(typeof(TeamSyncDbContext))]
    partial class TeamSyncDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgcrypto");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TeamSync.Domain.Entities.Organisation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AdminUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("admin_user_id");

                    b.Property<bool>("EnforceDomainCheck")
                        .HasColumnType("boolean")
                        .HasColumnName("enforce_domain_check");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<JObject>("Metadata")
                        .HasColumnType("jsonb")
                        .HasColumnName("metadata");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<Guid>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("organisation_id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.HasKey("Id")
                        .HasName("pk_organisations");

                    b.HasIndex("AdminUserId")
                        .IsUnique()
                        .HasDatabaseName("ix_organisations_admin_user_id");

                    b.HasIndex("OrganisationId")
                        .IsUnique()
                        .HasDatabaseName("ix_organisations_organisation_id");

                    b.ToTable("organisations", (string)null);
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.TimeLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClockedInTime")
                        .HasColumnType("bigint")
                        .HasColumnName("clocked_in_time");

                    b.Property<long>("ClockedOutTime")
                        .HasColumnType("bigint")
                        .HasColumnName("clocked_out_time");

                    b.Property<long>("CreatedOn")
                        .HasColumnType("bigint")
                        .HasColumnName("created_on");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_time_logs");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_time_logs_user_id");

                    b.ToTable("time_logs", (string)null);
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<byte[]>("HashSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("hash_salt");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<bool>("IsAdminUser")
                        .HasColumnType("boolean")
                        .HasColumnName("is_admin_user");

                    b.Property<bool>("IsClockedIn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_clocked_in");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<JObject>("Metadata")
                        .HasColumnType("jsonb")
                        .HasColumnName("metadata");

                    b.Property<long>("OrganisationId")
                        .HasColumnType("bigint")
                        .HasColumnName("organisation_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasAlternateKey("UserId")
                        .HasName("ak_users_user_id");

                    b.HasIndex("OrganisationId")
                        .HasDatabaseName("ix_users_organisation_id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_users_user_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.Organisation", b =>
                {
                    b.HasOne("TeamSync.Domain.Entities.User", "AdminUser")
                        .WithOne()
                        .HasForeignKey("TeamSync.Domain.Entities.Organisation", "AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_organisations_users_admin_user_id");

                    b.Navigation("AdminUser");
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.TimeLog", b =>
                {
                    b.HasOne("TeamSync.Domain.Entities.User", "User")
                        .WithMany("TimeLogs")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_time_logs_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.User", b =>
                {
                    b.HasOne("TeamSync.Domain.Entities.Organisation", "Organisation")
                        .WithMany("Users")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_organisations_organisation_id");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.Organisation", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TeamSync.Domain.Entities.User", b =>
                {
                    b.Navigation("TimeLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
