
using Leopard.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Lamar;
using System.IdentityModel.Tokens.Jwt;
using Leopard.Bussiness;
using Leopard.Api;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.IdentityModel.Logging;

try {

	var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
				.Build();

	var serilogLogger = new LoggerConfiguration()
		.ReadFrom.Configuration(configuration)
		.CreateLogger();

	var builder = WebApplication.CreateBuilder(args);

	IdentityModelEventSource.ShowPII = true;

	builder.Host.UseSerilog(serilogLogger, true);

	// use Lamar as DI.
	builder.Host.UseLamar((context, registry) => {
		// register services using Lamar
		//registry.For<ITest>().Use<MyTest>();

		// Add your own Lamar ServiceRegistry collections
		// of registrations
		//registry.IncludeRegistry<MyRegistry>();

		//////
		var corsAllowedUrls = configuration.GetSection("AllowedCorsUrls").Get<List<string>>();

		registry.AddCors(options => {
			options.AddPolicy("TemporaryCorsPolicy",
				policyBuilder => {
					policyBuilder.WithOrigins(corsAllowedUrls.ToArray())
										.AllowAnyHeader()
										.AllowAnyMethod();
				});
		});

		registry.AddApiVersioning(options => {
			options.ReportApiVersions = true;
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.DefaultApiVersion = new ApiVersion(1, 0);
		});

		ConfigServices.ConfigSwagger(registry);



		var oAuthServerUrl = configuration.GetSection("OAuthServer").Get<string>();

		//https://stackoverflow.com/questions/57998262
		JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

		registry.AddAuthentication(options => {
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
		});

		// accepts any access token issued by identity server
		registry.AddAuthentication("Bearer")
			.AddJwtBearer("Bearer", options => {
				options.Authority = oAuthServerUrl;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidateAudience = false
				};
			});

		registry.AddDbContext<LeopardDbContext>(options => {
			options.UseSqlServer(configuration.GetConnectionString(@"DefaultConnection"));
			options.UseLazyLoadingProxies();
		});

		registry.IncludeRegistry<LamarServiceRegistry>();
		registry.IncludeRegistry<LamarStoreRegistry>();

		

		registry.AddMemoryCache();
		////////

		// discover MVC controllers -- this was problematic
		// inside of the UseLamar() method, but is "fixed" in
		// Lamar V8
		//registry.AddControllers();
		registry.AddControllersWithViews()
			.AddJsonOptions(jsonOptions => {
				// null to leave property names unchanged
				jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
				//jsonOptions.JsonSerializerOptions.Converters.Add(UnixTimeStampDateConverter)
			})
			//.AddFluentValidation()
			//https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/web-api/index.md
			.ConfigureApiBehaviorOptions(options => {
				//https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0#disable-automatic-400-response
				// so we can manage error messages by our own hands
				options.SuppressConsumesConstraintForFormFileParameters = true;
				options.SuppressInferBindingSourcesForParameters = true;
				options.SuppressModelStateInvalidFilter = true;
				options.SuppressMapClientErrors = true;
				options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
					"https://httpstatuses.com/404";
			});

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		registry.AddEndpointsApiExplorer();
		registry.AddSwaggerGen();
	});


	var app = builder.Build();

	
	
	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment()) {
		//app.UseSwagger();
		//app.UseSwaggerUI();

		//app.UseDeveloperExceptionPage();
	}

	app.UseStaticFiles();


	var swaggerEndPointUrl = configuration.GetSection("SwaggerEndPointUrl").Get<string>();
	var swaggerEndPointName = configuration.GetSection("SwaggerEndPointName").Get<string>();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerEndPointUrl, swaggerEndPointName));
	if (app.Environment.IsDevelopment()) {
		app.UseMiddleware<LogResponseMiddleware>();
		app.UseMiddleware<LogRequestMiddleware>();
	}

	app.UseCors("TemporaryCorsPolicy");
	
	app.UseRouting();

	app.UseAuthentication();
	app.UseAuthorization();

	//https://stackoverflow.com/questions/57684093
	app.UseEndpoints(endpoints => {
		endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
	});
	//app.MapControllers();

	app.Run();

} catch (Exception ex) {
	Log.Fatal(ex, "Application start-up failed");
} finally {
	Log.CloseAndFlush();

}



