using System;

namespace PlayingCards
{
    public class CardSuit
    {
        public enum SuitNames
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public CardSuit(SuitNames suit)
        {
            switch (suit)
            {
                case SuitNames.Clubs:
                    suitString = "♣";
                    break;
                case SuitNames.Diamonds:
                    suitString = "♦";
                    break;
                case SuitNames.Hearts:
                    suitString = "♥";
                    break;
                case SuitNames.Spades:
                    suitString = "♠";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("suit", suit, 
                        "The suit value must be one of Clubs, Diamonds, Hearts, Spades.");
            }
        }

        public override string ToString()
        {
            return suitString;
        }

        private readonly string suitString;
    }

}