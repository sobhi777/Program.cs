using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InsuranceMVC.Models
{
    public class InsuranceEntities : DbContext
    {
        public InsuranceEntities(DbContextOptions<InsuranceEntities> options) : base(options) { }

        public DbSet<Insuree> Insurees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Insuree>().ToTable("Insurees");
        }
    }
}
