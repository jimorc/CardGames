﻿using System;
using Xunit;
using PlayingCards;

namespace CardLibUnitTests
{
    public class CardRankTests
    {
        // test CardRank.ToString()
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

        // test CardRank constructor with invalid input.
        [Fact]
        public void TestConstructorInvalidValue()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(()
    => new CardRank((CardRank.RankNames)(-1)));

            bool invalidRank = ex.Message.Contains(
                "The rank value is invalid");

            Assert.True(invalidRank);

        }

        // test CardRank.Equals() with null input.
        [Fact]
        public void TestEqualsNull()
        {
            var ace = new CardRank(CardRank.RankNames.Ace);

            bool equals = ace.Equals(null);

            Assert.False(equals);
        }

        // tests CardRank.Equals against same object.
        [Fact]
        public void TestEqualsSelf()
        {
            var ace = new CardRank(CardRank.RankNames.Ace);

            bool equals = ace.Equals(ace);

            Assert.True(equals);
        }

        // test CardRank.Equals with value that is not a CardRank.
        [Fact]
        public void TestEqualsNotCardRank()
        {
            var ace = new CardRank(CardRank.RankNames.Ace);
            var str = "A String";

            bool equals = ace.Equals(str);

            Assert.False(equals);
        }

        // test CardRank.Equals with value that has same rank
        [Fact]
        public void TestEqualsSameRank()
        {
            var ace = new CardRank(CardRank.RankNames.Ace);
            var ace2 = new CardRank(CardRank.RankNames.Ace);

            bool equals = ace.Equals(ace2);

            Assert.True(equals);
        }

        // test CardRank.Equals against CardRank object that does not have same rank.
        [Fact]
        public void TestEqualsNotEquals()
        {
            var ace = new CardRank(CardRank.RankNames.Ace);
            var king = new CardRank(CardRank.RankNames.King);

            bool equals = ace.Equals(king);

            Assert.False(equals);
        }

        // test CardRank.GetHashCode with two CardRank objects with same rank.
        // Note: cannot test not equals because there is no guarantee that
        // GetHashCode will return different values for different CardRank objects.
        [Fact]
        public void TestGetHashCodeEqualRanks()
        {
            var ace = new CardRank(CardRank.RankNames.Ace);
            var ace2 = new CardRank(CardRank.RankNames.Ace);

            bool equals = (ace.GetHashCode() == ace2.GetHashCode());

            Assert.True(equals);
        }

        // test CardRank.CompareTo with CardRank object of same value
        [Fact]
        public void TestCompareToSameValue()
        {
            var six = new CardRank(CardRank.RankNames.Six);
            var six2 = new CardRank(CardRank.RankNames.Six);

            var comp = six.CompareTo(six2);

            Assert.True(comp == 0);
        }

        // test CardRank.CompareTo with CardRank object of less value
        [Fact]
        public void TestCompareToLess()
        {
            var six = new CardRank(CardRank.RankNames.Six);
            var three = new CardRank(CardRank.RankNames.Three);

            var comp = six.CompareTo(three);

            Assert.True(comp > 0);
        }

        // test CardRank.CompareTo with CardRank object of greater value
        [Fact]
        public void TestCompareToGreater()
        {
            var six = new CardRank(CardRank.RankNames.Six);
            var seven = new CardRank(CardRank.RankNames.Seven);

            var comp = six.CompareTo(seven);

            Assert.True(comp < 0);
        }

        // test CardRank.CompareTo with same object
        [Fact]
        public void TestCompareToSameObject()
        {
            var six = new CardRank(CardRank.RankNames.Six);

            var comp = six.CompareTo(six);

            Assert.True(comp == 0);
        }
    }
}
