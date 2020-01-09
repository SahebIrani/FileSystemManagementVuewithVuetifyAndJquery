using Demo.SinjulMSBH.Repository;
using Demo.SinjulMSBH.Service;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.Configure<IISOptions>(config => config.AutomaticAuthentication = false);

			services.AddSingleton<IFileSystemService, DefaultFileSystemService>();
			services.AddSingleton<IFileSystemRepository, FileSystemRepository>();

			IMvcBuilder builder = services.AddRazorPages();

			services.AddRazorPages()
				.AddJsonOptions(configure =>
				{
					configure.JsonSerializerOptions.IgnoreNullValues = true;
					configure.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				})
				.AddRazorRuntimeCompilation()
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

			app.UseCookiePolicy();

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
