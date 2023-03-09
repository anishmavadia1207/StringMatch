using Microsoft.AspNetCore.Mvc;
using StringMatch.Core.Services;

namespace StringMatch.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringIndexService _stringIndexService;

        public HomeController(IStringIndexService stringIndexService)
        {
            _stringIndexService = stringIndexService;
        }

        public IActionResult Landing()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<int>> Matches([FromQuery] string text, [FromQuery] string subText)
        {
            var matches = _stringIndexService.GetStringIndexMatches(text, subText);

            return Ok(matches);
        }
    }
}