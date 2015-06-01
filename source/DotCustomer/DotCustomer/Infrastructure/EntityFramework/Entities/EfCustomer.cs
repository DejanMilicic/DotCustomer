
namespace DotCustomer.Infrastructure.EntityFramework.Entities
{
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("DotCustomerCustomer")]
	class EfCustomer
	{
		public EfCustomer()
		{
			
		}

		public EfCustomer(string email)
		{
			this.Email = email;
		}

		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

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
		public string Phone { get; set; }
		public bool SubscribedToNewsletter { get; set; }
		public bool Disabled { get; set; }
	}
}
