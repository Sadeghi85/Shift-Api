using Lamar;
using Serilog;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using ILogger = Serilog.ILogger;
using Microsoft.AspNetCore.Http.Extensions;

namespace Leopard.Api {

	public class RemoveVersionFromParameter : IOperationFilter {
		public void Apply(OpenApiOperation operation, OperationFilterContext context) {
			var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "v");
			if (versionParameter != null) {
				operation.Parameters.Remove(versionParameter);
			}
		}
	}
	public class ReplaceVersionWithExactValueInPath : IDocumentFilter {
		public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context) {
			var paths = new OpenApiPaths();
			foreach (var path in swaggerDoc.Paths) {
				paths.Add(path.Key.Replace("v{v}", swaggerDoc.Info.Version), path.Value);
			}
			swaggerDoc.Paths = paths;
		}
	}

	public class LogRequestMiddleware {
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LogRequestMiddleware(RequestDelegate next, ILogger logger) {
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context) {
			var requestBodyStream = new MemoryStream();
			var originalRequestBody = context.Request.Body;
			await context.Request.Body.CopyToAsync(requestBodyStream);
			requestBodyStream.Seek(0L, SeekOrigin.Begin);
			var url = context.Request.GetDisplayUrl();
			var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
			_logger.Information(string.Format("\r\nREQUEST METHOD: {0}\r\nREQUEST BODY: {1}\r\nREQUEST URL: {2}\r\n", context.Request.Method, requestBodyText, url));
			requestBodyStream.Seek(0L, SeekOrigin.Begin);
			context.Request.Body = requestBodyStream;
			await _next(context);
			context.Request.Body = originalRequestBody;
		}
	}
	public class LogResponseMiddleware {
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LogResponseMiddleware(RequestDelegate next, ILogger logger) {
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context) {
			var bodyStream = context.Response.Body;
			var responseBodyStream = new MemoryStream();
			context.Response.Body = responseBodyStream;
			await _next(context);
			responseBodyStream.Seek(0, SeekOrigin.Begin);
			var responseBody = new StreamReader(responseBodyStream).ReadToEnd();
			_logger.Information(string.Format("\r\nRESPONSE LOG: {0}\r\n", responseBody));
			responseBodyStream.Seek(0, SeekOrigin.Begin);
			await responseBodyStream.CopyToAsync(bodyStream);
		}
	}


	public class ConfigServices {
		public static void ConfigSwagger(ServiceRegistry services) {
			services.AddSwaggerGen(options => {
				options.SwaggerDoc("v1", new OpenApiInfo {
					Title = "Yooshina API", Version = "v1", Contact = new OpenApiContact() {
						Url = new Uri("http://www.ysp24.ir"),
						Email = "info@ysp24.ir",
						Name = "Yalda Idea Processing"
					},
					Description = "Part of Yooshina Microservice Solution"
				});

				// To Enable authorization using Swagger (JWT)  
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement  {
					{
						  new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] {}
					}
				});

				//see: http://stackoverflow.com/questions/40929916
				// This call remove version from parameter, without it we will have version as parameter 
				// for all endpoints in swagger UI
				options.OperationFilter<RemoveVersionFromParameter>();
				// This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
				options.DocumentFilter<ReplaceVersionWithExactValueInPath>();


				//options.AddSecurityDefinition("Yalda Contracts Security Definition", new OpenApiSecurityScheme {
				//	Type = SecuritySchemeType.OAuth2,
				//	BearerFormat = "JWT",
				//	In = ParameterLocation.Header,
				//	OpenIdConnectUrl = new Uri($"http://localhost:5000/.well-known/openid-configuration"),
				//	Flows = new OpenApiOAuthFlows {
				//		ClientCredentials = new OpenApiOAuthFlow {
				//			AuthorizationUrl = new Uri($"http://localhost:5000/connnect/authorize"),
				//			TokenUrl = new Uri($"http://localhost:5000/connect/token"),
				//			Scopes = new Dictionary<string, string>
				//					{
				//		{ "yaldaContractsApi", "Yalda Contracts Api Rights" },
				//		{ "write", "the right to write" },
				//		{ "read", "the right to read" }
				//	}
				//		}
				//	}
				//});

				//var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "my-fancy-api.xml");

				//options.IncludeXmlComments(filePath);

			});
		}
	}
}
