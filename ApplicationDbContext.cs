using MedicalTrackingSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalTrackingSystem
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<MedicineTracker> medicineTrackers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<MedicineTracker>();
            //.ToTable("MedicineTracker");
            base.OnModelCreating(builder);
        }

        //public override int SaveChanges()
        //{
        //    ChangeTracker.DetectChanges();
        //    return base.SaveChanges();
        //}
        
    }
}
