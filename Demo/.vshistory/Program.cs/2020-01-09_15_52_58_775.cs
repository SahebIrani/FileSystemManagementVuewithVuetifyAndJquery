using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Demo
{
	public class Program
	{
		public static Task Main(string[] args) => CreateHostBuilder(args).Build().RunAsync();

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder
						//.UseContentRoot(Directory.GetCurrentDirectory())
						//.UseKestrel()
						//.UseIISIntegration()
						.UseStartup<Startup>()
					;
				});
	}
}
