namespace DotCustomer
{
	using DotCustomer.Interfaces;

	public interface IDotCustomerApi
	{
		ICustomer CreateUser(string email);
		ICustomer GetByEmail(string email);
		void SetPassword(string email, string password);
		bool IsValidLogin(string email, string password);
		ICustomer UpdateNewsletterSubscription(string email, bool subscribed);
		ICustomer UpdateDisabledStatu(string email, bool disabled);
		ICustomer Update(string email,
			string title = "", string firstName = "", string lastName = "", string company = "",
			string street = "", string streetNumber = "", string city = "", string zip = "", string country ="",
			string state = "", string province = "", string phone = "");

		bool UserExists(string email);
	}
}