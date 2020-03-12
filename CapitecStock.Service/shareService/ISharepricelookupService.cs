using CapitecStock.Models.Stock;
using System.Threading.Tasks;

namespace CapitecStock.Service.shareService
{
	public interface ISharepricelookupService
	{
		Task<ShareViewModel> getSharePrice(AppSettings settings , double amount);
	}
}
