using BikersX.Entities.DbSet;
using BikersX.Entities.DbSet.Relationship;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BillUpdateHistory>().HasKey(x => new
            {
                x.UpdateHistoryId, x.BillId
            });
            builder.Entity<BillUpdateHistory>()
                .HasOne(x => x.Bill)
                .WithMany(x => x.BillUpdateHistories)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<BillUpdateHistory>()
                .HasOne(x => x.UpdateHistory)
                .WithMany(x => x.BillUpdateHistories)
                .HasForeignKey(x => x.UpdateHistoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<UpdateHistory> UpdateHistories { get; set; }
        public DbSet<BillUpdateHistory> BillUpdateHistories { get; set; }
    }
}
