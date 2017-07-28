using System;
using Xunit;
using PlayingCards;

namespace CardLibUnitTests
{
    public class CardRankTests
    {
        [Theory]
        [InlineData(CardRank.RankNames.Two, "2")]
        [InlineData(CardRank.RankNames.Three, "3")]
        [InlineData(CardRank.RankNames.Four, "4")]
        [InlineData(CardRank.RankNames.Five, "5")]
        [InlineData(CardRank.RankNames.Six, "6")]
        [InlineData(CardRank.RankNames.Seven, "7")]
        [InlineData(CardRank.RankNames.Eight, "8")]
        [InlineData(CardRank.RankNames.Nine, "9")]
        [InlineData(CardRank.RankNames.Ten, "10")]
        [InlineData(CardRank.RankNames.Jack, "J")]
        [InlineData(CardRank.RankNames.Queen, "Q")]
        [InlineData(CardRank.RankNames.King, "K")]
        [InlineData(CardRank.RankNames.Ace, "A")]
        public void TestToString(CardRank.RankNames testRank, string value)
        {
            var cardRank = new CardRank(testRank);

            var rankString = string.Format("{0}", cardRank);

            Assert.Equal(value, rankString);
        }
    }
}
