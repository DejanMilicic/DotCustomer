
namespace DotCustomer.Infrastructure.EntityFramework
{
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;

	using DotCustomer.Infrastructure.EntityFramework.Entities;

	class Db : DbContext
	{
		public Db() : base("DotCustomer")
		{
			// Turn off lazy loading for performance increase, use eager loading - .Include()
			this.Configuration.LazyLoadingEnabled = false;
			this.Configuration.ProxyCreationEnabled = false;

			this.Database.Initialize(false);
		}

		public DbSet<EfCustomer> Customers { get; set; }
		public DbSet<EfCustomerAddress> CustomerAddresses { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}
	}
}
