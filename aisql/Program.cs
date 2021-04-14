using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Twinfield.Framework.Logging;

namespace aisql
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			 Host.CreateDefaultBuilder(args)
				 .ConfigureServices((context, collection) =>
				 {
					 collection.AddDefaultLogging("aisql16", context.GetLoggingOptions());
				 })
				  .ConfigureWebHostDefaults(webBuilder =>
				  {
					  webBuilder.UseStartup<Startup>();
				  });
	}
}
