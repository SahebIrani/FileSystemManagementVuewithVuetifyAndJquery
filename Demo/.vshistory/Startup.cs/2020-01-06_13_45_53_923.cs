using Demo.SinjulMSBH.Repository;
using Demo.SinjulMSBH.Service;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<IISOptions>(config => config.AutomaticAuthentication = false);

			services.AddSingleton<IFileSystemService, DefaultFileSystemService>();
			services.AddSingleton<IFileSystemRepository, FileSystemRepository>();

			services.AddRazorPages()
				.AddJsonOptions(configure =>
				{
					configure.JsonSerializerOptions.IgnoreNullValues = true;
					configure.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				})
			;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});
		}
	}
}
