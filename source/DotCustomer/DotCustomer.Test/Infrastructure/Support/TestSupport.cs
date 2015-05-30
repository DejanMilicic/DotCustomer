
namespace DotCustomer.Test.Infrastructure.Support
{
	using Respawn;

	public static class TestSupport
	{
		public static void ResetDatabase()
		{
			Checkpoint checkpoint = new Checkpoint
			{
				TablesToIgnore = new[]
										{
											"__MigrationHistory"
										}
			};

			checkpoint.Reset(@"Server=.\SQLEXPRESS;Database=DotCustomer;Integrated Security=SSPI");
		}
	}
}
