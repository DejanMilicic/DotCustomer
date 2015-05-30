
namespace DotCustomer.Test
{
	using DotCustomer.Interfaces;
	using DotCustomer.Test.Infrastructure.Support;

	public class DotCustomerApiTests
	{
		private readonly IDotCustomerApi dc;

		public DotCustomerApiTests()
		{
			TestSupport.ResetDatabase();
			dc = new DotCustomerApi();
		}

		public void CreateNewCustomer()
		{
			ICustomer newCustomer = dc.CreateUser("user@company.com");
		}
	}
}
