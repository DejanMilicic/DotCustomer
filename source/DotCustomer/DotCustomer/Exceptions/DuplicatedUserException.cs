
namespace DotCustomer.Exceptions
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Exception thrown at the attempt of duplicating user
	/// </summary>
	public class DuplicatedUserException : Exception
	{
		/// <summary>
		/// Just create the exception
		/// </summary>
		public DuplicatedUserException()
			: base()
		{
		}

		/// <summary>
		/// Create the exception with description
		/// </summary>
		/// <param name="message">Exception description</param>
		public DuplicatedUserException(String message)
			: base(message)
		{
		}

		/// <summary>
		/// Create the exception with description and inner cause
		/// </summary>
		/// <param name="message">Exception description</param>
		/// <param name="innerException">Exception inner cause</param>
		public DuplicatedUserException(String message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Create the exception from serialized data.
		/// Usual scenario is when exception is occured somewhere on the remote workstation
		/// and we have to re-create/re-throw the exception on the local machine
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Serialization context</param>
		protected DuplicatedUserException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
