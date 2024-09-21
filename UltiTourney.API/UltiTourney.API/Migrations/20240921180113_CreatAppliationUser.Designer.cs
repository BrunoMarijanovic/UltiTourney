﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltiTourney.API.Data;

#nullable disable

namespace UltiTourney.API.Migrations
{
    [DbContext(typeof(UltiTourneyDbContext))]
    [Migration("20240921180113_CreatAppliationUser")]
    partial class CreatAppliationUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cb2c87a7-b88c-444e-b7af-deb960a2fa28",
                            ConcurrencyStamp = "cb2c87a7-b88c-444e-b7af-deb960a2fa28",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "786fb16d-f678-471e-9a8b-2b3080a191e2",
                            ConcurrencyStamp = "786fb16d-f678-471e-9a8b-2b3080a191e2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "624c654c-e381-4ec4-b0a6-1ccaee97d7eb",
                            ConcurrencyStamp = "624c654c-e381-4ec4-b0a6-1ccaee97d7eb",
                            Name = "Scoreboard",
                            NormalizedName = "SCOREBOARD"
                        },
                        new
                        {
                            Id = "4fec49cc-7ed1-4ab1-bda1-22761e282721",
                            ConcurrencyStamp = "4fec49cc-7ed1-4ab1-bda1-22761e282721",
                            Name = "MatchManager",
                            NormalizedName = "MATCHMANAGER"
                        },
                        new
                        {
                            Id = "61a89ae0-f14e-45ea-be76-c417afd10201",
                            ConcurrencyStamp = "61a89ae0-f14e-45ea-be76-c417afd10201",
                            Name = "Spirit",
                            NormalizedName = "SPIRIT"
                        },
                        new
                        {
                            Id = "282d6b15-fe08-4b35-8226-544691018d2b",
                            ConcurrencyStamp = "282d6b15-fe08-4b35-8226-544691018d2b",
                            Name = "Reader",
                            NormalizedName = "READER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCountry")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b73fa7d-ffdf-4fa1-8f77-bd6459c9e91e"),
                            IdCountry = new Guid("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"),
                            Name = "Girona"
                        },
                        new
                        {
                            Id = new Guid("39bc8a6d-87e4-45b7-8f27-7b7487e3b0e3"),
                            IdCountry = new Guid("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"),
                            Name = "Madrid"
                        },
                        new
                        {
                            Id = new Guid("e60c7b5e-b72b-4f85-a1c3-eadc8a9d89b3"),
                            IdCountry = new Guid("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"),
                            Name = "Paris"
                        },
                        new
                        {
                            Id = new Guid("8c8c08d3-665c-40d5-a96a-44eb76e89bb1"),
                            IdCountry = new Guid("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"),
                            Name = "Lyon"
                        },
                        new
                        {
                            Id = new Guid("fea6d774-33df-49d3-bc3f-e1c582a7dc0c"),
                            IdCountry = new Guid("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"),
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = new Guid("74e29a0c-7d0d-4b4b-b88a-1d68a7e7b028"),
                            IdCountry = new Guid("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"),
                            Name = "Munich"
                        },
                        new
                        {
                            Id = new Guid("26c2a2da-7b14-4901-9447-19f5cfa42e15"),
                            IdCountry = new Guid("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"),
                            Name = "New York"
                        },
                        new
                        {
                            Id = new Guid("aa3e69d9-b7e3-4b64-bc5e-6cb8c6f52a15"),
                            IdCountry = new Guid("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"),
                            Name = "Los Angeles"
                        });
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"),
                            Name = "España"
                        },
                        new
                        {
                            Id = new Guid("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"),
                            Name = "France"
                        },
                        new
                        {
                            Id = new Guid("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"),
                            Name = "Germany"
                        },
                        new
                        {
                            Id = new Guid("b793f8a7-7be2-4634-80da-b0d10db6b0d3"),
                            Name = "Italy"
                        },
                        new
                        {
                            Id = new Guid("88d9d635-e31a-4979-91f7-ef70f69c41db"),
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("9d64f83c-682c-4cd7-84e6-6db3c0a2d45a"),
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = new Guid("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"),
                            Name = "United States"
                        },
                        new
                        {
                            Id = new Guid("a8f65470-1d95-4f2e-bca0-e3b6144762aa"),
                            Name = "Canada"
                        },
                        new
                        {
                            Id = new Guid("7e96d6d1-ea9a-4f83-a9d9-dedb9f6dbe59"),
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = new Guid("bc5a9391-13c0-4679-8bc7-60d6600ff621"),
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = new Guid("5ed14b71-76f2-4d3a-8614-cf4ec2f526f2"),
                            Name = "Australia"
                        },
                        new
                        {
                            Id = new Guid("d196f2c8-0fc3-4965-b19c-f44e2a042dda"),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("68cb11c9-f00b-4665-bb7d-d9e1a0a6de27"),
                            Name = "China"
                        },
                        new
                        {
                            Id = new Guid("778c9814-c905-4f86-8401-8dcb9a6fbd53"),
                            Name = "India"
                        },
                        new
                        {
                            Id = new Guid("b7e3776f-c0f3-46ad-83b1-631b97f7fc4a"),
                            Name = "South Africa"
                        },
                        new
                        {
                            Id = new Guid("16d6b93f-06e5-4703-83c7-1c3e1b4c74f3"),
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = new Guid("1184ffed-d8c9-4544-898e-97c1e4d08f7e"),
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = new Guid("cd16c2b9-82bb-4c18-8574-8127c5a028ec"),
                            Name = "Russia"
                        },
                        new
                        {
                            Id = new Guid("a7dff340-8df9-4a4c-bf49-7a70f2ef0b4e"),
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("21f20f48-4e37-4b0f-b845-7d3d14a0c8b2"),
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = new Guid("9a5b5d3d-4e63-4f2e-b409-3fdbb8eaa5b9"),
                            Name = "Saudi Arabia"
                        },
                        new
                        {
                            Id = new Guid("b5b65a27-02ea-4c9c-9e48-1c5f5a3763d8"),
                            Name = "South Korea"
                        },
                        new
                        {
                            Id = new Guid("4d0fb601-e682-4fb9-b0e1-1ddac8cdb74e"),
                            Name = "Indonesia"
                        },
                        new
                        {
                            Id = new Guid("1198e8bb-2c49-4cb4-8cc7-7c2b9a3c4033"),
                            Name = "Thailand"
                        },
                        new
                        {
                            Id = new Guid("9fcbad7d-dc1a-4920-8a24-cb2b5b5cfa56"),
                            Name = "Malaysia"
                        },
                        new
                        {
                            Id = new Guid("4ed1d5fa-3b0d-4b82-8fd3-48235c56a22c"),
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = new Guid("d28c5d96-23da-46fd-b59f-5eebc284fdc5"),
                            Name = "Vietnam"
                        },
                        new
                        {
                            Id = new Guid("da6d27f3-6213-43f2-9a5c-d6b9a324c4d3"),
                            Name = "New Zealand"
                        },
                        new
                        {
                            Id = new Guid("7f46b9f7-7cc5-490d-b0e1-2ef708c42e39"),
                            Name = "Chile"
                        },
                        new
                        {
                            Id = new Guid("27d9cbb9-c4c5-4323-83c7-fbb29a4d6c4e"),
                            Name = "Colombia"
                        },
                        new
                        {
                            Id = new Guid("18a9ff9b-c4ab-4074-8751-65c3e4d08f8f"),
                            Name = "Peru"
                        },
                        new
                        {
                            Id = new Guid("cf16c3c9-73cc-4c1f-96f5-1c7e5a0a9e4c"),
                            Name = "Venezuela"
                        });
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.Tourney", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<Guid>("IdCity")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdImage")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("UrlGoogleMaps")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCity");

                    b.HasIndex("IdImage");

                    b.ToTable("Tourneys");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.UserTourney", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("TourneyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "TourneyId");

                    b.HasIndex("TourneyId");

                    b.ToTable("UserTourney");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UltiTourney.API.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UltiTourney.API.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltiTourney.API.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UltiTourney.API.Models.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.City", b =>
                {
                    b.HasOne("UltiTourney.API.Models.Domain.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.Tourney", b =>
                {
                    b.HasOne("UltiTourney.API.Models.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("IdCity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltiTourney.API.Models.Domain.Image", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage");

                    b.Navigation("City");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.UserTourney", b =>
                {
                    b.HasOne("UltiTourney.API.Models.Domain.Tourney", "Tourney")
                        .WithMany("UserTourneys")
                        .HasForeignKey("TourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltiTourney.API.Models.Domain.ApplicationUser", "User")
                        .WithMany("UserTourneys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tourney");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.ApplicationUser", b =>
                {
                    b.Navigation("UserTourneys");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("UltiTourney.API.Models.Domain.Tourney", b =>
                {
                    b.Navigation("UserTourneys");
                });
#pragma warning restore 612, 618
        }
    }
}
