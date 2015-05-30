
namespace DotCustomer.Infrastructure
{
	using AutoMapper;
	using DotCustomer.Domain;
	using DotCustomer.Infrastructure.EntityFramework.Entities;

	static class AutomapperBootstrapper
	{
		public static void Configure()
		{
			Mapper.CreateMap<EfCustomer, Customer>();
			Mapper.CreateMap<EfCustomerAddress, CustomerAddress>();

			Mapper.AssertConfigurationIsValid();
		}
	}
}
