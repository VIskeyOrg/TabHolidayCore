using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace TabHolidayCore.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Int64>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
               .Property(a => a.ActualName).HasColumnType("VARCHAR(200)");

            builder.Entity<Country>()
                .Property(c => c.Name).HasColumnType("VARCHAR(50)");
            builder.Entity<Country>()
                .Property(c => c.Extention).HasColumnType("VARCHAR(10)");

            builder.Entity<AgencyTierLevel>()
               .Property(a => a.Name).HasColumnType("VARCHAR(30)");

            builder.Entity<Agency>()
                .Property(a => a.Name).HasColumnType("VARCHAR(200)");
            builder.Entity<Agency>()
                .Property(a => a.Address).HasColumnType("VARCHAR(300)");
            builder.Entity<Agency>()
                .Property(a => a.TaxId).HasColumnType("VARCHAR(50)");

            builder.Entity<State>()
                .Property(a => a.Name).HasColumnType("VARCHAR(250)");

            builder.Entity<BankAccountType>()
                .Property(a => a.Name).HasColumnType("VARCHAR(50)");

            builder.Entity<BankDetail>()
                .Property(a => a.Name).HasColumnType("VARCHAR(50)");
            builder.Entity<BankDetail>()
                .Property(a => a.BranchName).HasColumnType("VARCHAR(100)");
            builder.Entity<BankDetail>()
                .Property(a => a.AccountHolderName).HasColumnType("VARCHAR(100)");
            builder.Entity<BankDetail>()
               .Property(a => a.AccountNumber).HasColumnType("VARCHAR(20)");
            builder.Entity<BankDetail>()
               .Property(a => a.SwiftCode).HasColumnType("VARCHAR(20)");
            builder.Entity<BankDetail>()
               .Property(a => a.RoutingNumber).HasColumnType("VARCHAR(20)");
            builder.Entity<BankDetail>()
              .Property(a => a.IFSCCode).HasColumnType("VARCHAR(20)");
            builder.Entity<BankDetail>()
             .Property(a => a.IBANCode).HasColumnType("VARCHAR(20)");
            builder.Entity<BankDetail>()
             .Property(a => a.MICRNumber).HasColumnType("VARCHAR(20)");

            builder.Entity<BankDetail>()
                .HasOne(b => b.BankAccountType);

            builder.Entity<DMCOfficialType>()
            .Property(a => a.Name).HasColumnType("VARCHAR(20)");

            builder.Entity<DMCOfficial>()
           .Property(a => a.Name).HasColumnType("VARCHAR(100)");
            builder.Entity<DMCOfficial>()
           .Property(a => a.EmailId).HasColumnType("VARCHAR(200)");

            builder.Entity<DMCOfficial>()
                .HasOne(b => b.DMCOfficialType);


            builder.Entity<DMC>()
           .Property(a => a.Name).HasColumnType("VARCHAR(100)");
            builder.Entity<DMC>()
           .Property(a => a.Address).HasColumnType("VARCHAR(300)");
            builder.Entity<DMC>()
           .Property(a => a.FaxNumber).HasColumnType("VARCHAR(20)");
            builder.Entity<DMC>()
           .Property(a => a.OfficeNumber).HasColumnType("VARCHAR(200)");
            builder.Entity<DMC>()
           .Property(a => a.TaxNumber).HasColumnType("VARCHAR(30)");

            builder.Entity<DMC>()
                .HasMany(d => d.BankDetails);

            builder.Entity<DMC>()
               .HasMany(d => d.DMCOfficials);

            builder.Entity<DMC>()
                .HasOne(d => d.Country);

            builder.Entity<StarRating>()
            .Property(a => a.Name).HasColumnType("VARCHAR(20)");

            builder.Entity<Hotel>()
          .Property(a => a.Name).HasColumnType("VARCHAR(100)");
            builder.Entity<Hotel>()
           .Property(a => a.TaggedLocation).HasColumnType("VARCHAR(100)");
            builder.Entity<Hotel>()
           .Property(a => a.DetailedLocation).HasColumnType("VARCHAR(200)");
            builder.Entity<Hotel>()
           .Property(a => a.Lattitude).HasColumnType("VARCHAR(200)");
            builder.Entity<Hotel>()
           .Property(a => a.Longitude).HasColumnType("VARCHAR(200)");
            builder.Entity<Hotel>()
           .Property(a => a.EmailId).HasColumnType("VARCHAR(200)");
            builder.Entity<Hotel>()
           .Property(a => a.PhoneNumber).HasColumnType("VARCHAR(100)");

            builder.Entity<Hotel>()
                .HasOne(b => b.StarRating);

            builder.Entity<Facility>()
            .Property(a => a.Name).HasColumnType("VARCHAR(100)");
            builder.Entity<Facility>()
            .Property(a => a.Class).HasColumnType("VARCHAR(100)");

            builder.Entity<Meal>()
            .Property(a => a.Name).HasColumnType("VARCHAR(100)");

            builder.Entity<SightSeeing>()
           .Property(a => a.Name).HasColumnType("VARCHAR(100)");
            builder.Entity<SightSeeing>()
           .Property(a => a.TaggedLocation).HasColumnType("VARCHAR(100)");
            builder.Entity<SightSeeing>()
           .Property(a => a.DetailedLocation).HasColumnType("VARCHAR(100)");
            builder.Entity<SightSeeing>()
           .Property(a => a.Lattitude).HasColumnType("VARCHAR(50)");
            builder.Entity<SightSeeing>()
           .Property(a => a.Longitude).HasColumnType("VARCHAR(50)");

            builder.Entity<SightSeeing>()
               .HasOne(b => b.StarRating);

            builder.Entity<SightSeeing>()
              .HasOne(b => b.SightSeeingCategory);

            builder.Entity<SightSeeingCategory>()
           .Property(a => a.Name).HasColumnType("VARCHAR(50)");

            builder.Entity<Inclusion>()
           .Property(a => a.Inclusions).HasColumnType("VARCHAR(1000)");

            builder.Entity<InclusionType>()
            .Property(a => a.Name).HasColumnType("VARCHAR(50)");

            builder.Entity<Transfer>()
            .Property(a => a.City).HasColumnType("VARCHAR(50)");

            builder.Entity<Transfer>()
           .Property(a => a.ShortDescription).HasColumnType("VARCHAR(200)");

            builder.Entity<Transfer>()
           .Property(a => a.FromLocation).HasColumnType("VARCHAR(50)");

            builder.Entity<Transfer>()
           .Property(a => a.ToLocation).HasColumnType("VARCHAR(50)");

            builder.Entity<Transfer>()
               .HasOne(b => b.TransferType);

            builder.Entity<Transfer>()
              .HasOne(b => b.TransferCategory);

            builder.Entity<TransferType>()
               .Property(a => a.Name).HasColumnType("VARCHAR(50)");

            builder.Entity<TransferCategory>()
               .Property(a => a.Name).HasColumnType("VARCHAR(50)");

            builder.Entity<VehicleType>()
              .Property(a => a.VehicleTypes).HasColumnType("VARCHAR(50)");
            

            builder.Entity<Agency>()
                .HasMany(a => a.ApplicationUsers)
                .WithOne(b => b.Agency)
                .HasForeignKey(a => a.AgencyId);
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<AgencyTierLevel> AgencyTierLevels { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }
        public DbSet<DMCOfficialType> DMCOfficialTypes { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<DMCOfficial> DMCOfficial { get; set; }
        public DbSet<DMC> DMCs { get; set; }
        public DbSet<StarRating> StarRatings { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<HotelFacility> HotelFacilities { get; set; }
        public DbSet<HotelMeal> HotelMeals { get; set; }
<<<<<<< HEAD
        public DbSet<SightSeeingCategory> SightSeeingCategories { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<InclusionType> InclusionTypes { get; set; }
        public DbSet<Inclusion> Inclusions { get; set; }
        public DbSet<SightSeeing> SightSeeings { get; set; }
        public DbSet<TransferType> TransferTypes { get; set; }
        public DbSet<TransferCategory> TransferCategories { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<BlackOut> BlackOuts { get; set; }
        public DbSet<Transfer> Transfers { get; set; }






=======
>>>>>>> refs/remotes/origin/anjali
    }
}
