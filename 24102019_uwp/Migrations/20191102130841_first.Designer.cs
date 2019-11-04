using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using _24102019_uwp.Data;

namespace _24102019_uwp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20191102130841_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3");

            modelBuilder.Entity("_24102019_uwp.Models.Customer", b =>
                {
                    b.Property<int>("CusID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CusID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Disk", b =>
                {
                    b.Property<int>("DiskID");

                    b.Property<short>("ChkOutStatus");

                    b.Property<bool>("Deleted");

                    b.Property<int>("TitleID");

                    b.HasKey("DiskID");

                    b.HasIndex("TitleID");

                    b.ToTable("Disks");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Rentail_Detail", b =>
                {
                    b.Property<int>("RentalID");

                    b.Property<int>("DiskID");

                    b.Property<DateTime?>("DueDate");

                    b.Property<decimal?>("OwnedMoney")
                        .HasColumnType("money");

                    b.Property<DateTime?>("ReturnDate");

                    b.HasKey("RentalID", "DiskID");

                    b.HasIndex("DiskID");

                    b.HasIndex("RentalID");

                    b.ToTable("Rentail_Detail");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Rental", b =>
                {
                    b.Property<int>("RentalID");

                    b.Property<int>("CusID");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("StartRentDate");

                    b.Property<short>("Status");

                    b.HasKey("RentalID");

                    b.HasIndex("CusID");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Reservation", b =>
                {
                    b.Property<int>("ResID");

                    b.Property<int>("CusID");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("IsAvailable");

                    b.Property<short>("Status");

                    b.Property<int>("TitleID");

                    b.HasKey("ResID");

                    b.HasIndex("CusID");

                    b.HasIndex("TitleID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Title", b =>
                {
                    b.Property<int>("TitleID");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<decimal>("RentCharge")
                        .HasColumnType("money");

                    b.Property<short>("RentPeriod");

                    b.Property<int>("TypeID");

                    b.HasKey("TitleID");

                    b.HasIndex("TypeID");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Type", b =>
                {
                    b.Property<int>("TypeID");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TypeID");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("_24102019_uwp.Models.User", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_24102019_uwp.Models.Disk", b =>
                {
                    b.HasOne("_24102019_uwp.Models.Title", "Title")
                        .WithMany("Disks")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_24102019_uwp.Models.Rentail_Detail", b =>
                {
                    b.HasOne("_24102019_uwp.Models.Disk", "Disk")
                        .WithMany("Rentail_Detail")
                        .HasForeignKey("DiskID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_24102019_uwp.Models.Rental", "Rental")
                        .WithMany("Rentail_Detail")
                        .HasForeignKey("RentalID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_24102019_uwp.Models.Rental", b =>
                {
                    b.HasOne("_24102019_uwp.Models.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_24102019_uwp.Models.Reservation", b =>
                {
                    b.HasOne("_24102019_uwp.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_24102019_uwp.Models.Title", "Title")
                        .WithMany("Reservations")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_24102019_uwp.Models.Title", b =>
                {
                    b.HasOne("_24102019_uwp.Models.Type", "Type")
                        .WithMany("Titles")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
