// <auto-generated />
using System;
using Events.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Events.Infrastructure.Migrations
{
    [DbContext(typeof(EventsContext))]
    partial class EventsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Events.Model.Models.Event", b =>
                {
                    b.Property<Guid>("RfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EVT_CreationDate");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EVT_EventDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RfId");

                    b.ToTable("tbl_Events", (string)null);
                });

            modelBuilder.Entity("Events.Model.Models.EventFile", b =>
                {
                    b.Property<Guid>("RfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventRfId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EVF_EVT_RFID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EVF_Name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("EVF_Type");

                    b.HasKey("RfId");

                    b.HasIndex("EventRfId");

                    b.ToTable("tbl_EventFiles", (string)null);
                });

            modelBuilder.Entity("Events.Model.Models.EventFile", b =>
                {
                    b.HasOne("Events.Model.Models.Event", "Event")
                        .WithMany("Files")
                        .HasForeignKey("EventRfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Events.Model.Models.Event", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
