using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandApi : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post(Contracts.ClassifiedAds.V1.Create request)
        {
            return Ok();
        }
    }
}
