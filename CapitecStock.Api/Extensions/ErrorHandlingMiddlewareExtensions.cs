using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CapitecStock.Api.Extensions
{
	public static class ErrorHandlingMiddlewareExtensions
	{
		public static void ErrorHandler(this IApplicationBuilder appBuilder)
		{
			// 1. Invoke UserExceptionHandler() method and pass IApplicationBuilder to it.
			appBuilder.UseExceptionHandler((error) =>
			{
				// 2. Invoke the Run() method. This method accepts RequestDelegate parameter 
				error.Run(async ctx => {
					// 3. send the status code based on the error occured
					ctx.Response.StatusCode = ctx.Response.StatusCode;
					ctx.Response.ContentType = "application/json";

					// 4. Get the error thrown while processing request

					string errorMessage = ctx.Features.Get<IExceptionHandlerFeature>()
									.Error.GetBaseException().Message;


					// 5. Create the response message. This will contain error message 
					string ResponseMessage = JsonConvert.SerializeObject(new ErrorClass()
					{
						ErrorCode = ctx.Response.StatusCode,
						ErrorMessage = errorMessage
					});
					// 6. Write the response message
					await ctx.Response.WriteAsync(ResponseMessage);
				});
			});
		}
	}

	public class ErrorClass
	{
		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }
	}
}
