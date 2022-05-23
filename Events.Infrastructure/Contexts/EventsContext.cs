using Events.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Infrastructure.Contexts
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventFile> Events { get; set; }
        public DbSet<Event> EventFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //the line below is used for migrations
            //optionsBuilder.UseSqlServer("Server=.\\MSSQL2019;Database=dbEvents;User Id=sa;Password=P@ssw0rd;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //event configuration
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("tbl_Events");
                entity.HasKey(e => e.RfId);
                entity.Property(e => e.EventDate).HasColumnName("EVT_EventDate");
                entity.Property(e => e.CreationDate).HasColumnName("EVT_CreationDate");
            });
            //eventfile configurations
            modelBuilder.Entity<EventFile>(entity =>
            {
                entity.ToTable("tbl_EventFiles");
                entity.HasKey(e => e.RfId);
                entity.Property(e => e.Name).HasColumnName("EVF_Name");
                entity.Property(e => e.Type).HasColumnName("EVF_Type");
                entity.Property(e => e.EventRfId).HasColumnName("EVF_EVT_RFID");
            });
            //relation between event and eventfile
            modelBuilder.Entity<EventFile>()
                .HasOne<Event>()
                .WithMany(g => g.Files)
                .HasForeignKey(s => s.EventRfId);

        }
    }
}
