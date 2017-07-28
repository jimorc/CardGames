using System;
using Xunit;
using PlayingCards;

namespace CardLibUnitTests
{
    // tests for the CardSuit class
    public class CardSuitTests
    {
        // test CardSuit.ToString()
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

        // test CardSuit constructor with invalid input value
        [Fact]
        public void CardSuit3ConstructorInvalidValueTest()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => new CardSuit((CardSuit.SuitNames)(-1)));

            bool invalidSuit = ex.Message.Contains(
                "The suit value must be one of Clubs, Diamonds, Hearts, Spades.");

            Assert.True(invalidSuit);
        }

        // test CardSuit.Equals with null value
        [Fact]
        public void TestEqualsNull()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Clubs);

            bool equals = cardSuit.Equals(null);

            Assert.False(equals);
        }

        // test CardSuit.Equals against self
        [Fact]
        public void TestEqualsSelf()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Diamonds);

            bool equals = cardSuit.Equals(cardSuit);

            Assert.True(equals);
        }

        // test CardSuit.Equals with value that is not a CardSuit object
        [Fact]
        public void TestEqualsNotCardSuit()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Diamonds);
            var str = "A string";

            bool equals = cardSuit.Equals(str);

            Assert.False(equals);
        }

        // test CardSuitEquals with CardSuit object that contains same suit.
        [Fact]
        public void TestEqualsSame()
        {
            var hearts = new CardSuit(CardSuit.SuitNames.Hearts);
            var hearts2 = new CardSuit(CardSuit.SuitNames.Hearts);

            bool equals = hearts.Equals(hearts2);

            Assert.True(equals);
        }

        // test CardSuit.Equals with CardSuit object that is not same suit.
        [Fact]
        public void TestEqualsNotEquals()
        {
            var hearts = new CardSuit(CardSuit.SuitNames.Hearts);
            var spades = new CardSuit(CardSuit.SuitNames.Spades);

            bool equals = hearts.Equals(spades);

            Assert.False(equals);
        }

        // test CardSuit.GetHashCode() with equal CardSuit objects
        [Fact]
        public void TestGetHashCodeEqualCardSuits()
        {
            var hearts = new CardSuit(CardSuit.SuitNames.Hearts);
            var hearts2 = new CardSuit(CardSuit.SuitNames.Hearts);

            bool equals = (hearts.GetHashCode() == hearts2.GetHashCode());

            Assert.True(equals);
        }
    }
}