using Cheetah.ApiHelpers;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Shift.Api;
using Shift.Bussiness;
using Shift.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;

var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
				.Build();

var serilogLogger = new LoggerConfiguration()
		.ReadFrom.Configuration(configuration)
		.CreateLogger();
var builder = WebApplication.CreateBuilder(args);
var corsAllowedUrls = configuration.GetSection("AllowedCorsUrls").Get<List<string>>();

builder.Services.AddCors(options => {
	options.AddPolicy("TemporaryCorsPolicy",
		policyBuilder => {
			policyBuilder.WithOrigins(corsAllowedUrls.ToArray())
								.AllowAnyHeader()
								.AllowAnyMethod()
								.AllowCredentials();
		});
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);


builder.Host.UseSerilog(serilogLogger, true);
// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Host.UseLamar((context, registry) => {




	registry.AddApiVersioning(options => {
		options.ReportApiVersions = true;
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.DefaultApiVersion = new ApiVersion(1, 0);
	});

	ConfigServices.ConfigSwagger(registry);
	var oAuthServerUrl = configuration.GetSection("OAuthServer").Get<string>();

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
				ValidateAudience = false,
				ValidateIssuer = false,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
		});




	registry.AddDbContext<ShiftDbContext>(options => {
		options.UseSqlServer(configuration.GetConnectionString(@"DefaultConnection"));
		options.UseLazyLoadingProxies();
	});



	registry.IncludeRegistry<LamarServiceRegistry>();

	// register services using Lamar

	//registry.AddScoped<IGenericRepository<>, TheRepository<>>();
	//registry.AddTransient(typeof(IGenericRepository<>), typeof(TheRepository<>));

	// Add your own Lamar ServiceRegistry collections
	// of registrations
	//registry.AddTransient(typeof(ISamtCQRS));

	// discover MVC controllers -- this was problematic
	// inside of the UseLamar() method, but is "fixed" in
	// Lamar V8
	registry.AddControllers();

	registry.AddControllersWithViews().ConfigureApiBehaviorOptions(options => {
		//https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0#disable-automatic-400-response
		// so we can manage error messages by our own hands
		options.SuppressConsumesConstraintForFormFileParameters = true;
		//options.SuppressInferBindingSourcesForParameters = true;
		options.SuppressModelStateInvalidFilter = true;
		options.SuppressMapClientErrors = true;
		options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
			"https://httpstatuses.com/404";
	});

	//registry.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
	//.AddNewtonsoftJson(opt => {
	//	opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
	//});

	registry.AddMvc().AddJsonOptions(options => {
		options.JsonSerializerOptions.Converters.Add(new TrimStringConverter());
	});

});



var app = builder.Build();

if (app.Environment.IsDevelopment())
	app.MapControllers().AllowAnonymous();
else
	app.MapControllers();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
}

app.UseSwagger();

app.UseSwaggerUI();
app.UseStaticFiles();

if (app.Environment.IsDevelopment()) {
	app.UseMiddleware<LogResponseMiddleware>();
	app.UseMiddleware<LogRequestMiddleware>();
}


app.UseRouting();
app.UseCors("TemporaryCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
