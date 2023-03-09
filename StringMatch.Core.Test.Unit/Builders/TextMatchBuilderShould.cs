using Bogus;
using Should;
using StringMatch.Core.Builders;
using System.Xml.Serialization;

namespace StringMatch.Core.Test.Unit.Helpers
{
    public class TextMatchBuilderShould
    {
        public static object[][] TestData()
        {
            var baseText = "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?";
            return new object[][]
            {
                new object[]
                {
                    baseText,
                    "How",
                    new [] { 1 }
                },
                new object[]
                {
                    baseText,
                    "wood",
                    new [] { 10, 23, 45, 67 }
                },
                new object[]
                {
                    baseText,
                    "Wood",
                    new [] { 10, 23, 45, 67 }
                },
                new object[]
                {
                    baseText,
                    "oo",
                    new [] { 11, 24, 46, 68 }
                },
                new object[]
                {
                    baseText,
                    "oO",
                    new [] { 11, 24, 46, 68 }
                },
                new object[]
                {
                    baseText,
                    "?",
                    new [] { 71 }
                },
                new object[]
                {
                    baseText,
                    "wooden",
                    Array.Empty<int>()
                },
                new object[]
                {
                    baseText,
                    "x",
                    Array.Empty<int>()
                },
            };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ReturnIndexesForMatches_WhenMatchesAreFound(
            string text,
            string subText,
            int[] expectedIndexes)
        {
            var matches = new TextMatchBuilder()
                .WithText(text)
                .WithSubText(subText)
                .FindSubTextMatches();

            expectedIndexes.All(e => matches.Contains(e)).ShouldBeTrue();
        }

        [Fact]
        public void SetTextCorrectly_WhenWithTextIsCalled()
        {
            var builder = new TextMatchBuilder();
            var word = new Faker().Lorem.Word();

            builder.WithText(word);

            builder._text.ShouldEqual(word);
        }
        [Fact]
        public void SetSubTextCorrectly_WhenWithTextIsCalled()
        {
            var builder = new TextMatchBuilder();
            var word = new Faker().Lorem.Word();

            builder.WithSubText(word);

            builder._subText.ShouldEqual(word);
        }

    }
}