using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportWebApi.Domain.Entities;
using ReportWebApi.Domain.Identity;
using ReportWebApi.Persistence.Configurations.Entities;
using ReportWebApi.Persistence.Configurations.Identity;
using System.Reflection;

namespace ReportWebApi.Persistence.Contexts
{
    public class ReportWebApiIdentityContext : IdentityDbContext<Person, Role, Guid>
    {
        public override DbSet<Person> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPerson> ProductPersons { get; set; }






        public ReportWebApiIdentityContext(DbContextOptions<ReportWebApiIdentityContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration()); 
            modelBuilder.ApplyConfiguration(new ProductPersonConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        
            base.OnModelCreating(modelBuilder);

        }


    }
}
