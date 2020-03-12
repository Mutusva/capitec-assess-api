using CapitecStock.Service.shareService;
using CapitecStock.Service.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitecStock.Api.Extensions
{
	public static class DIServiceExtension
	{
		public static void AddDIServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpClientWrapper<object>, HttpClientWrapper<object>>();
			services.AddSingleton<ISharepricelookupService, AlphavantageStockLookup>();
		}
	}
}
