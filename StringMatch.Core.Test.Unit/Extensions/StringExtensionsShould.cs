using Should;
using StringMatch.Core.Extensions;

namespace StringMatch.Core.Test.Unit.Extensions
{
    public class StringExtensionsShould
    {
        [Fact]
        public void CreateLowerCaseCharArray_WhenMethodIsCalled()
        {
            var baseString = "Test AbC 123 !?";

            var expectedCharArray = new char[]
            {
                't',
                'e',
                's',
                't',
                ' ',
                'a',
                'b',
                'c',
                ' ',
                '1',
                '2',
                '3',
                ' ',
                '!',
                '?'
            };

            baseString.ToLowerCaseCharArray().ShouldEqual(expectedCharArray);
        }
    }
}
