using System;
using Xunit;
using PlayingCards;

namespace CardLibUnitTests
{
    public class CardSuitTests
    {
        [Theory]
        [InlineData(CardSuit.SuitNames.Clubs, "♣")]
        [InlineData(CardSuit.SuitNames.Diamonds, "♦")]
        [InlineData(CardSuit.SuitNames.Hearts, "♥")]
        [InlineData(CardSuit.SuitNames.Spades, "♠")]
        public void CardSuitToStringTest(CardSuit.SuitNames suit, string suitString)
        {
            var cardSuit = new CardSuit(suit);

            var card = String.Format("{0}", cardSuit);

            Assert.Equal(suitString, card);
        }

        [Fact]
        public void CardSuit3ConstructorInvalidValueTest()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => new CardSuit((CardSuit.SuitNames)(-1)));

            bool invalidSuit = ex.Message.Contains(
                "The suit value must be one of Clubs, Diamonds, Hearts, Spades.");

            Assert.True(invalidSuit);
        }
    }
}