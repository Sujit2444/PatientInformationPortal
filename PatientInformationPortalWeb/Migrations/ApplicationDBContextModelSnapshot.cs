﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInformationPortalWeb.Data;

#nullable disable

namespace PatientInformationPortalWeb.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientInformationPortalWeb.Models.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesID"));

                    b.Property<string>("AllergiesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergiesID");

                    b.ToTable("Allergies");

                    b.HasData(
                        new
                        {
                            AllergiesID = 1,
                            AllergiesName = "Drugs - Penicillin"
                        },
                        new
                        {
                            AllergiesID = 2,
                            AllergiesName = "Drugs - Others"
                        },
                        new
                        {
                            AllergiesID = 3,
                            AllergiesName = "Animals"
                        },
                        new
                        {
                            AllergiesID = 4,
                            AllergiesName = "Food"
                        },
                        new
                        {
                            AllergiesID = 5,
                            AllergiesName = "Oniments"
                        },
                        new
                        {
                            AllergiesID = 6,
                            AllergiesName = "Plant"
                        },
                        new
                        {
                            AllergiesID = 7,
                            AllergiesName = "Sprays"
                        },
                        new
                        {
                            AllergiesID = 8,
                            AllergiesName = "Others"
                        },
                        new
                        {
                            AllergiesID = 9,
                            AllergiesName = "No Allergies"
                        });
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.AllergiesDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AllergiesID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AllergiesID");

                    b.HasIndex("PatientID");

                    b.ToTable("Allergies_Details");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.DiseaseInformation", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"));

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("DiseaseInformation");

                    b.HasData(
                        new
                        {
                            DiseaseID = 1,
                            DiseaseName = "Hepatitis A"
                        },
                        new
                        {
                            DiseaseID = 2,
                            DiseaseName = "Influenza (Flu)"
                        },
                        new
                        {
                            DiseaseID = 3,
                            DiseaseName = "COVID-19"
                        },
                        new
                        {
                            DiseaseID = 4,
                            DiseaseName = "Common Cold"
                        });
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"));

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NCDID");

                    b.ToTable("NCDs");

                    b.HasData(
                        new
                        {
                            NCDID = 1,
                            NCDName = "Asthma"
                        },
                        new
                        {
                            NCDID = 2,
                            NCDName = "Cancer"
                        },
                        new
                        {
                            NCDID = 3,
                            NCDName = "Disorders of ear"
                        },
                        new
                        {
                            NCDID = 4,
                            NCDName = "Disorders of eye"
                        },
                        new
                        {
                            NCDID = 5,
                            NCDName = "Mental illness"
                        },
                        new
                        {
                            NCDID = 6,
                            NCDName = "Our health problems"
                        });
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.NCDDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("NCDID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NCDID");

                    b.HasIndex("PatientID");

                    b.ToTable("NCD_Details");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.PatientInformation", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<int>("DiseaseID")
                        .HasColumnType("int");

                    b.Property<int>("EpilepsyStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("PatientsInformation");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.AllergiesDetail", b =>
                {
                    b.HasOne("PatientInformationPortalWeb.Models.Allergies", "Allergies")
                        .WithMany()
                        .HasForeignKey("AllergiesID");

                    b.HasOne("PatientInformationPortalWeb.Models.PatientInformation", "Patient")
                        .WithMany("Allergies")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergies");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.NCDDetail", b =>
                {
                    b.HasOne("PatientInformationPortalWeb.Models.NCD", "NCD")
                        .WithMany()
                        .HasForeignKey("NCDID");

                    b.HasOne("PatientInformationPortalWeb.Models.PatientInformation", "Patient")
                        .WithMany("NCDs")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.PatientInformation", b =>
                {
                    b.HasOne("PatientInformationPortalWeb.Models.DiseaseInformation", "DiseaseInformation")
                        .WithMany("Patients")
                        .HasForeignKey("DiseaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiseaseInformation");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.DiseaseInformation", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PatientInformationPortalWeb.Models.PatientInformation", b =>
                {
                    b.Navigation("Allergies");

                    b.Navigation("NCDs");
                });
#pragma warning restore 612, 618
        }
    }
}
