using CapitecStock.Models.Stock;
using CapitecStock.Service.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CapitecStock.Service.shareService
{
	/// <summary>
	/// This class intergrates with alphavantage, to get market share prices
	/// </summary>
	public class AlphavantageStockLookup : ISharepricelookupService
	{
		private readonly IHttpClientWrapper<object> _httpclientWrapper;
		const string alphavantageApi = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE";
		public AlphavantageStockLookup(IHttpClientWrapper<object> httpclientWrapper)
		{
			_httpclientWrapper = httpclientWrapper;
		}

		/// <summary>
		/// get the share price for a particular symbol.
		/// </summary>
		/// <param name="Url"></param>
		/// <param name="symbol"></param>
		/// <param name="apiKey"></param>
		/// <returns></returns>

		public async Task<ShareViewModel> getSharePrice(AppSettings settings, double amount)
		{
			decimal sharePriceCents;
			var url = settings.AlphavantageApiUrl + $"&symbol={settings.Symbol}&apikey={settings.ApiKey}";
			var result = await _httpclientWrapper.Get(url);

			dynamic data = JObject.Parse(result.ToString());
			string value = data["Global Quote"]["05. price"].Value;
			sharePriceCents = Decimal.Parse(!string.IsNullOrEmpty(value) ? value.Substring(0, value.IndexOf('.')) : "0");
			double sharePriceRands = ((double)sharePriceCents * 1.0) / 100;
			return new ShareViewModel() { SharePrice = sharePriceRands, NumberOfShares = amount / (sharePriceRands * 1.0) };
		}
	}
}
