using StringMatch.Core.Builders;

namespace StringMatch.Core.Services
{
    public class StringIndexService : IStringIndexService
    {
        public IEnumerable<int> GetStringIndexMatches(string text, string subText)
        {
           return new TextMatchBuilder()
                .WithText(text)
                .WithSubText(subText)
                .FindSubTextMatches();
        }
    }

    public interface IStringIndexService
    {
        IEnumerable<int> GetStringIndexMatches(string text, string subText);
    }
}
