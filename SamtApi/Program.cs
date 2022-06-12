using Lamar.Microsoft.DependencyInjection;
using Leopard.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Leopard.Bussiness;
using Serilog;
using Serilog.Extensions;
using Microsoft.AspNetCore.Mvc;
using SamtApi;

var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
				.Build();

var serilogLogger = new LoggerConfiguration()
		.ReadFrom.Configuration(configuration)
		.CreateLogger();
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(serilogLogger, true);
// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Host.UseLamar((context, registry) => {


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


	registry.AddDbContext<LeopardDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

	registry.IncludeRegistry<LamarServiceRegistry>();
	registry.IncludeRegistry<LamarStoreRegistry>();
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

	registry.AddControllersWithViews();
	registry.AddSwaggerGen();

	registry.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
	.AddNewtonsoftJson(opt => {
		opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
	});

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
