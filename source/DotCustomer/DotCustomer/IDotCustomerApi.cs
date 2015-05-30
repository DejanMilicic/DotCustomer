namespace DotCustomer
{
	using DotCustomer.Interfaces;

	public interface IDotCustomerApi
	{
		ICustomer CreateUser(string email);
	}
}