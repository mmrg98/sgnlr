using Microsoft.EntityFrameworkCore;
using SgnlrServer.Models;
using System;

namespace SgnlrServer.Data
{
    public class TravelDemoContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TravelDemoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TravelCon"));
        } 
        public DbSet<Customer> Customers { get; set; } = null;
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
