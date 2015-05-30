
namespace DotCustomer.Interfaces
{
	public interface ICustomer
	{
		string Email { get; }
		string Password { get; }
		string FirstName { get; }
		string LastName { get; }
		ICustomerAddress ShippingAddress { get; }
		ICustomerAddress BillingAddress { get; }
	}
}
