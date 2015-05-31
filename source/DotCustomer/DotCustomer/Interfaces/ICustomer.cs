
namespace DotCustomer.Interfaces
{
	public interface ICustomer
	{
		string Email { get; }
		string Password { get; }

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
		string Phone { get; }
		bool SubscribedToNewsletter { get; }
	}
}
