using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLWebApplication.DbContexts;
using GraphQLWebApplication.GraphQL;
using GraphQLWebApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWebApplication
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
			//SQL Server
//			services.AddDbContext<GraphQLTestContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContextPool<GraphQLTestContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

			//これを元にやってきたが無理でした。シングルトンに変更する。
			//https://www.c-sharpcorner.com/article/graphql-in-net-core-web-api-with-entity-framework-core-part-one/
			//services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			////GraphQL configuration  
			//services.AddScoped<IServiceProvider>(s => new EmployeeQuery(s.GetRequiredService(EmployeeType));
			//services.AddScoped<EmployeeSchema>();
			//services.AddGraphQL(o => { o.ExposeExceptions = false; })
			// .AddGraphTypes(ServiceLifetime.Scoped);

			//			services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
			//↓
			//https://stackoverflow.com/questions/59328439/error-while-validating-the-service-descriptor-servicetype-inewsrepository-life
			//services.AddTransient<IEmployeeRepository, EmployeeRepository>();
			//services.AddSingleton<EmployeeQuery>();
			//↓
			services.AddTransient<EmployeeQuery>();
			//services.AddSingleton<EmployeeType>();
			//services.AddSingleton<EmployeeSchema>();
			services.AddSingleton<EmployeeSchema>();
			services.AddGraphQL(o => {
				
			})
			.AddGraphTypes(ServiceLifetime.Scoped);


			//諦めました。。。

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLWebApplication", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLWebApplication v1"));
			}

			//			app.UseGraphiQLServer();
			app.UseGraphQL<EmployeeSchema>();
			app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
