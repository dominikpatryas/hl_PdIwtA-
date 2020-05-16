﻿using HelpLocally.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HelpLocally.Infrastructure
{
    public class HelpLocallyContext : DbContext
    {
        public HelpLocallyContext(DbContextOptions<HelpLocallyContext> contextOptions) : base(contextOptions) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Role> Roles { get; set; }

        public static readonly ILoggerFactory DbLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(DbLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}