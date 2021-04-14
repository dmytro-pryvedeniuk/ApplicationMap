using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;

namespace aisql
{
	public class DummyService : IHostedService
	{
		const string connectionString1 = "Data Source=localhost;Initial Catalog=tf_accumulator;Persist Security Info=True;User ID=tf_user;Password=1234;MultipleActiveResultSets=True";
		const string connectionString2 = "Data Source=localhost;Initial Catalog=tf_cluster;Persist Security Info=True;User ID=tf_user;Password=1234;MultipleActiveResultSets=True";

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await TouchDb(connectionString1);
			await TouchDb(connectionString2);
		}

		static async Task TouchDb(string connectionString)
		{
			await using var connection = new SqlConnection(connectionString);
			await connection.QueryAsync("SELECT 1");
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
