using CapitecStock.Models.Stock;
using CapitecStock.Service.shareService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CapitecStock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SharepriceController : ControllerBase
    {
        private readonly ISharepricelookupService _sharepricelookupService;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _configurationSection;
        public SharepriceController(ISharepricelookupService sharepricelookupService, IConfiguration configuration)
        {
            _sharepricelookupService = sharepricelookupService;
            _configuration = configuration;
            _configurationSection = _configuration.GetSection("CapiConfig");
        }

        [HttpGet("{amount}")]
        public async Task<IActionResult> Get(double amount = 0)
        {
            var settings = _configurationSection.Get<AppSettings>();
            var result = await _sharepricelookupService.getSharePrice(settings, amount);
            return Ok(result);
        }
    }
}