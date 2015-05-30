
namespace DotCustomer.Domain
{
	using DotCustomer.Interfaces;

	class CustomerAddress : ICustomerAddress
	{
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string Province { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool SubscribedToNewsletter { get; set; }
	}
}
