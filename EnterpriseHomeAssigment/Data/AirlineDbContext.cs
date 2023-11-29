using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data
{
    public class AirlineDbContext : DbContext  // db context is a inbuilt class that is inhereted from  Microsoft.EntityFrameworkCore;
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flights"); //Makes sure that the tabl name is Flights
                entity.HasKey(e => e.Id);  //Makes sure that the primary key is id
            });
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(e => e.Id);

                entity.HasOne<Flight>()
                    .WithMany()
                    .HasForeignKey(t => t.FlightIdFK);
            });
        }

    }
}

