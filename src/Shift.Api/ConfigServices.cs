
using Lamar;
using Serilog;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using ILogger = Serilog.ILogger;
using Microsoft.AspNetCore.Http.Extensions;
using Cheetah.ApiHelpers.Filters;

namespace Shift.Api {
	

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
