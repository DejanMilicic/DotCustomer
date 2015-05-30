
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
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public EfCustomerAddress ShippingAddress { get; set; }
		public EfCustomerAddress BillingAddress { get; set; }
	}
}
