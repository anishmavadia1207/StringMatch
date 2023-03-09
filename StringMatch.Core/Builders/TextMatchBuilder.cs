using StringMatch.Core.Extensions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("StringMatch.Core.Test.Unit")]
namespace StringMatch.Core.Builders
{
    public class TextMatchBuilder
    {
        internal string _text;
        internal string _subText;

        public TextMatchBuilder WithText(string text)
        {
            _text = text;

            return this;
        }

        public TextMatchBuilder WithSubText(string subText)
        {
            _subText = subText;

            return this;
        }

        public IEnumerable<int> FindSubTextMatches()
        {
            var matchedCharacterPositions = new List<int>();
          
            var textCharArray = _text.ToLowerCaseCharArray();
            var subTextCharArray = _subText.ToLowerCaseCharArray();
            for (var i = 0; i <= textCharArray.Length - subTextCharArray.Length; i++)
            {
                var isMatch = true;
                for (var j = 0; j < subTextCharArray.Length; j++)
                {
                    if (isMatch && textCharArray[i + j] != subTextCharArray[j])
                    {
                        isMatch = false;
                    }
                }

                if (isMatch)
                {
                    matchedCharacterPositions.Add(i + 1);
                }
            }

            return matchedCharacterPositions;
        }
    }
}