using System.Threading.Tasks;

namespace CapitecStock.Service.Utils
{
	public interface IHttpClientWrapper<T> where T : class
	{
	  Task<T> Get(string url);
	}
}
