
namespace DotCustomer.Domain
{
	using DotCustomer.Interfaces;

	class Customer : ICustomer
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICustomerAddress ShippingAddress
		{
			get
			{
				return _shippingAddress;
			}
		}
		public CustomerAddress _shippingAddress { get; set; }

		public ICustomerAddress BillingAddress
		{
			get
			{
				return _billingAddress;
			}
		}

		public CustomerAddress _billingAddress { get; set; }
	}
}
