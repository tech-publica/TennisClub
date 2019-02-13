using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using TennisClubModel;

namespace EF_DBLayer
{
    public class TennisClubContext : DbContext
    {
        public DbSet<Court> Courts { get; set; }
        public DbSet<TennisCourt> TennisCourts { get; set; }
        public DbSet<PadelCourt> PadelCourts { get; set; }


        public TennisClubContext(DbContextOptions<TennisClubContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Court>().ToTable("Courts")
                .HasDiscriminator<int>("CourtType")
                .HasValue<TennisCourt>((int)CourtType.Tennis)
                .HasValue<PadelCourt>((int)CourtType.Padel);
        }

        public static TennisClubContext CreateContext(string connectionString
            = "Server = (localdb)\\MSSQLLocalDB; Database = TennisClub; Trusted_Connection = True; MultipleActiveResultSets = true")
        {
            var optionBuilder = new DbContextOptionsBuilder<TennisClubContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new TennisClubContext(optionBuilder.Options);
        }


    }


    public class TennisClubContextFactory : IDesignTimeDbContextFactory<TennisClubContext>
    {
        public TennisClubContext CreateDbContext(string[] args)
        { 

            var optionsBuilder = new DbContextOptionsBuilder<TennisClubContext>();
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = TennisClub; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new TennisClubContext(optionsBuilder.Options);
        }
    }


}
