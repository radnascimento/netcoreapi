using Microsoft.EntityFrameworkCore;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using System.Reflection;

namespace POC_GITHUB_06012022.v1.Context
{
    public class POCContext : DbContext
    {

        public POCContext(DbContextOptions<POCContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        //History
        public DbSet<CustomerHistory> CustomerHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //The code below will not work due to the project is using EFCore Database in memory

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Customer
            modelBuilder.Entity<Customer>().HasKey(p => p.IdCustomer);
            modelBuilder.Entity<Customer>().Property(p => p.NameCustomer).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(p => p.EmailCustomer).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Customer>().Property(p => p.DateOperation).IsRequired();



            //CustomerAddress
            modelBuilder.Entity<CustomerAddress>().HasKey(p => p.IdCustomerAddress);
            modelBuilder.Entity<CustomerAddress>().Property(p => p.IdCustomer).IsRequired();
            modelBuilder.Entity<CustomerAddress>().Property(p => p.StreetName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CustomerAddress>().Property(p => p.CityName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CustomerAddress>().Property(p => p.StateName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CustomerAddress>().Property(p => p.ZipCode).IsRequired();
            modelBuilder.Entity<CustomerAddress>().Property(p => p.IdStateCustomerAddress).IsRequired();
            modelBuilder.Entity<CustomerAddress>().Property(p => p.DateOperation).IsRequired();


            //modelBuilder.Entity<CustomerAddress>()
            //    .HasOne(p => p.Customer)
            //    .WithMany(b => b.CustomerAddress)
            //    .HasForeignKey("CustomerAddressCustomerFK");


        }

    }
}
