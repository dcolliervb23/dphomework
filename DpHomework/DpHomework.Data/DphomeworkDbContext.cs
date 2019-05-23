using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace DpHomework.Data
{
    public partial class DphomeworkDbContext : DbContext
    {
        public DphomeworkDbContext()
        {
        }

        public DphomeworkDbContext(DbContextOptions<DphomeworkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Individual> Individual { get; set; }

        public virtual DbQuery<IndividualsAndAddresses> IndividualsAndAddresseses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).HasMaxLength(10);

                entity.Property(e => e.AddressLine2).HasMaxLength(10);

                entity.Property(e => e.City).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(10);

                entity.Property(e => e.Zip).HasMaxLength(10);

                entity.HasOne(d => d.Individual)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.IndividualId)
                    .HasConstraintName("FK_Address_ToIndividual");
            });

            modelBuilder.Entity<Individual>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Query<IndividualsAndAddresses>().ToView("IndividualsAndAddresses");
                

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}