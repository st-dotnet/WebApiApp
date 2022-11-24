using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using WebApiApp.Context;
using WebApiApp.RepositoryLayer.Employee;
using WebApiApp.ServiceLayer.Employee;

namespace WebApiApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddDbContext<TestDbContext>(option =>
				option.UseSqlServer(Configuration.GetConnectionString("DB_Conn"),
					sqlServerOptionsAction: sqlOptions =>
					{
						sqlOptions.EnableRetryOnFailure();
					}));
			services.AddTransient<IEmployeeSL, EmployeeSL>();
			services.AddTransient<IEmployeeRL, EmployeeRL>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();
			app.UseCors();
			app.UseCors(builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "App V1");				
			});
		}
	}
}
