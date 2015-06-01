
namespace DotCustomer
{
	using System;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;

	using AutoMapper;

	using DotCustomer.Domain;
	using DotCustomer.Infrastructure;
	using DotCustomer.Infrastructure.EntityFramework;
	using DotCustomer.Infrastructure.EntityFramework.Entities;
	using DotCustomer.Interfaces;

	public class DotCustomerApi : IDotCustomerApi
	{
		public DotCustomerApi()
		{
			AutomapperBootstrapper.Configure();
		}

		public ICustomer CreateUser(string email)
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = new EfCustomer(email);
				db.Customers.Add(efCustomer);
				db.SaveChanges();

				return Mapper.Map<Customer>(efCustomer);
			}
		}

		public ICustomer GetByEmail(string email)
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = db.Customers.SingleOrDefault(x => x.Email == email);
				if (efCustomer == null)
				{
					return null;
				}
				else
				{
					return Mapper.Map<Customer>(efCustomer);
				}
			}
		}

		private string Hash(string password)
		{
			HMACSHA1 hash = new HMACSHA1();
			hash.Key = Encoding.Unicode.GetBytes(password);

			string encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
			return encodedPassword;
		}

		public void SetPassword(string email, string password)
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = db.Customers.SingleOrDefault(x => x.Email == email);
				if (efCustomer == null)
				{
					throw new ArgumentException();
				}
				else
				{
					efCustomer.Password = Hash(password);
					db.SaveChanges();
				}
			}			
		}

		public bool IsValidLogin(string email, string password)
		{
			using (Db db = new Db())
			{
				string hashedPassword = Hash(password);
				EfCustomer efCustomer = db.Customers.SingleOrDefault(x => x.Email == email && x.Password == hashedPassword);
				return efCustomer != null;
			}
		}

		public ICustomer UpdateNewsletterSubscription(string email, bool subscribed)
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = db.Customers.SingleOrDefault(x => x.Email == email);
				if (efCustomer == null)
				{
					throw new ArgumentException();
				}
				else
				{
					efCustomer.SubscribedToNewsletter = subscribed;
					db.SaveChanges();
					return Mapper.Map<Customer>(efCustomer);
				}				
			}
		}

		public ICustomer UpdateDisabledStatu(string email, bool disabled)
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = db.Customers.SingleOrDefault(x => x.Email == email);
				if (efCustomer == null)
				{
					throw new ArgumentException();
				}
				else
				{
					efCustomer.Disabled = disabled;
					db.SaveChanges();
					return Mapper.Map<Customer>(efCustomer);
				}				
			}			
		}

		public ICustomer Update(string email,
			string title = "", string firstName = "", string lastName = "", string company = "",
			string street = "", string streetNumber = "", string city = "", string zip = "", string country ="",
			string state = "", string province = "", string phone = "")
		{
			using (Db db = new Db())
			{
				EfCustomer efCustomer = db.Customers.SingleOrDefault(x => x.Email == email);
				if (efCustomer == null)
				{
					throw new ArgumentException();
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(title)) efCustomer.Title = title;
					if (!string.IsNullOrWhiteSpace(firstName)) efCustomer.FirstName = firstName;
					if (!string.IsNullOrWhiteSpace(lastName)) efCustomer.LastName = lastName;
					if (!string.IsNullOrWhiteSpace(company)) efCustomer.Company = company;
					if (!string.IsNullOrWhiteSpace(street)) efCustomer.Street = street;
					if (!string.IsNullOrWhiteSpace(streetNumber)) efCustomer.StreetNumber = streetNumber;
					if (!string.IsNullOrWhiteSpace(city)) efCustomer.City = city;
					if (!string.IsNullOrWhiteSpace(zip)) efCustomer.Zip = zip;
					if (!string.IsNullOrWhiteSpace(country)) efCustomer.Country = country;
					if (!string.IsNullOrWhiteSpace(state)) efCustomer.State = state;
					if (!string.IsNullOrWhiteSpace(province)) efCustomer.Province = province;
					if (!string.IsNullOrWhiteSpace(phone)) efCustomer.Phone = phone;

					db.SaveChanges();
					return Mapper.Map<Customer>(efCustomer);
				}
			}	
		}
	}
}
