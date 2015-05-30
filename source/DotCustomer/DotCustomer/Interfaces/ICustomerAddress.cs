
namespace DotCustomer.Interfaces
{
	public interface ICustomerAddress
	{
		string Title { get; }
		string FirstName { get; }
		string LastName { get; }
		string Company { get; }
		string Street { get; }
		string StreetNumber { get; }
		string City { get; }
		string Zip { get; }
		string Country { get; }
		string State { get; }
		string Province { get; }
		string Email { get; }
		string Phone { get; }
		bool SubscribedToNewsletter { get; }
	}
}
