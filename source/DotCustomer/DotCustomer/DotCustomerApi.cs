
namespace DotCustomer
{
	using AutoMapper;

	using DotCustomer.Domain;
	using DotCustomer.Infrastructure;
	using DotCustomer.Infrastructure.EntityFramework;
	using DotCustomer.Infrastructure.EntityFramework.Entities;
	using DotCustomer.Interfaces;

	public class DotCustomerApi : IDotCustomerApi
	{
		public DotCustomerApi()
		{
			AutomapperBootstrapper.Configure();
		}

		public ICustomer CreateUser(string email)
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = new EfCustomer(email);
				db.Customers.Add(efCustomer);
				db.SaveChanges();

				return Mapper.Map<Customer>(efCustomer);
			}
		}
	}
}
