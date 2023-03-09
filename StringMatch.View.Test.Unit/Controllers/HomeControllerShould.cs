using Microsoft.AspNetCore.Mvc;
using Moq;
using Should;
using StringMatch.Core.Services;
using StringMatch.View.Controllers;

namespace StringMatch.View.Test.Unit.Controllers
{
    public class HomeControllerShould
    {
        [Fact]
        public void CallMatchService_WhenRetrievingMatches()
        {
            var matchService = new Mock<IStringIndexService>();
            var controller = new HomeController(matchService.Object);

            var text = "abc";
            var subText = "cde";

            controller.Matches(text, subText);

            matchService.Verify(c => c.GetStringIndexMatches(text, subText), Times.Once);
        }

        [Fact]
        public void ReturnOk_WhenRetrievingMatches()
        {
            var matchService = new Mock<IStringIndexService>();
            var controller = new HomeController(matchService.Object);

            var text = "abc";
            var subText = "cde";

            var result = controller.Matches(text, subText);

            result.Result.ShouldBeType<OkObjectResult>();
        }
    }
}
