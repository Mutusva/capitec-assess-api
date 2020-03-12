using System;
using System.Collections.Generic;
using System.Text;

namespace CapitecStock.Models.Stock
{
	public class AppSettings
	{
		public string Symbol { get; set; }
		public string AlphavantageApiUrl { get; set; }
		public string ApiKey { get; set; }
	}
}
