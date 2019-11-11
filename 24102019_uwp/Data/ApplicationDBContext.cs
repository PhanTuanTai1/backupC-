using _24102019_uwp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Data
{
    public class ApplicationDBContext : DbContext
    {
        private static bool _created = false;

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Disk> Disks { get; set; }
        public virtual DbSet<Rentail_Detail> Rentail_Detail { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Models.Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDBContext()
        {
            if (!_created)
            {
                _created = true;
                /*Database.EnsureDeleted();
                Database.EnsureCreated();*/
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DSDB.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rentail_Detail>().HasKey(c => new { c.RentalID, c.DiskID });
        }
    }
}
