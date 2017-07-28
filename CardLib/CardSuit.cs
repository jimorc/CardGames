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

        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != typeof(CardSuit))
            {
                return false;
            }
            CardSuit cSuit = (CardSuit)obj;
            if(cSuit == this)
            {
                return true;
            }
            if(cSuit.ToString().Equals(this.ToString()))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return suitString.GetHashCode();
        }

        private readonly string suitString;
    }

}