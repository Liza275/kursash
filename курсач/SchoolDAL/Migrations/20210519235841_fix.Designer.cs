﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolDAL;

namespace SchoolDAL.Migrations
{
    [DbContext(typeof(SchoolDataBase))]
    [Migration("20210519235841_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SchoolDAL.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SchoolDAL.Models.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("SchoolDAL.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SchoolDAL.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("LessonCount")
                        .HasColumnType("integer");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SchoolDAL.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("LessonId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SchoolDAL.Models.Society", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AgeLimit")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SocietyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("SchoolDAL.Models.SocietyCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("AdditionalCosts")
                        .HasColumnType("numeric");

                    b.Property<int>("CostId")
                        .HasColumnType("integer");

                    b.Property<int>("SocietyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CostId");

                    b.HasIndex("SocietyId");

                    b.ToTable("SocietyCosts");
                });

            modelBuilder.Entity("SchoolDAL.Models.SocietyLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int>("SocietyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("SocietyId");

                    b.ToTable("SocietyLessons");
                });

            modelBuilder.Entity("SchoolDAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SchoolDAL.Models.Client", b =>
                {
                    b.HasOne("SchoolDAL.Models.User", "User")
                        .WithOne("Client")
                        .HasForeignKey("SchoolDAL.Models.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolDAL.Models.Cost", b =>
                {
                    b.HasOne("SchoolDAL.Models.Employee", "Employee")
                        .WithMany("Costs")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SchoolDAL.Models.Employee", b =>
                {
                    b.HasOne("SchoolDAL.Models.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("SchoolDAL.Models.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolDAL.Models.Lesson", b =>
                {
                    b.HasOne("SchoolDAL.Models.Employee", "Employee")
                        .WithMany("Lessons")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SchoolDAL.Models.Payment", b =>
                {
                    b.HasOne("SchoolDAL.Models.Client", "Client")
                        .WithMany("Payments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDAL.Models.Lesson", "Lesson")
                        .WithMany("Payments")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("SchoolDAL.Models.Society", b =>
                {
                    b.HasOne("SchoolDAL.Models.Client", "Client")
                        .WithMany("Societies")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SchoolDAL.Models.SocietyCost", b =>
                {
                    b.HasOne("SchoolDAL.Models.Cost", "Cost")
                        .WithMany("Societies")
                        .HasForeignKey("CostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDAL.Models.Society", "Society")
                        .WithMany("SocietyCosts")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cost");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("SchoolDAL.Models.SocietyLesson", b =>
                {
                    b.HasOne("SchoolDAL.Models.Lesson", "Lesson")
                        .WithMany("SocietyLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDAL.Models.Society", "Society")
                        .WithMany("SocietyLessons")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("SchoolDAL.Models.Client", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Societies");
                });

            modelBuilder.Entity("SchoolDAL.Models.Cost", b =>
                {
                    b.Navigation("Societies");
                });

            modelBuilder.Entity("SchoolDAL.Models.Employee", b =>
                {
                    b.Navigation("Costs");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("SchoolDAL.Models.Lesson", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("SocietyLessons");
                });

            modelBuilder.Entity("SchoolDAL.Models.Society", b =>
                {
                    b.Navigation("SocietyCosts");

                    b.Navigation("SocietyLessons");
                });

            modelBuilder.Entity("SchoolDAL.Models.User", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
