﻿using System;
using System.Collections.Generic;

namespace PlayingCards
{
    public class CardRank : IComparable<CardRank>
    {
        public enum RankNames
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        static CardRank()
        {
            ranks.Add(RankNames.Two, "2");
            ranks.Add(RankNames.Three, "3");
            ranks.Add(RankNames.Four, "4");
            ranks.Add(RankNames.Five, "5");
            ranks.Add(RankNames.Six, "6");
            ranks.Add(RankNames.Seven, "7");
            ranks.Add(RankNames.Eight, "8");
            ranks.Add(RankNames.Nine, "9");
            ranks.Add(RankNames.Ten, "10");
            ranks.Add(RankNames.Jack, "J");
            ranks.Add(RankNames.Queen, "Q");
            ranks.Add(RankNames.King, "K");
            ranks.Add(RankNames.Ace, "A");
        }

        public CardRank(RankNames rank)
        {
            var hasKey = ranks.ContainsKey(rank);
            if (hasKey)
            {
                this.rank = rank;
            }
            else
            { 
                throw new ArgumentOutOfRangeException("rank", rank,
                    "The rank value is invalid.");
            }
        }

        public override string ToString()
        {
            return Rank;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(CardRank))
            {
                return false;
            }
            CardRank rank = (CardRank)obj;
            if (rank == this)
            {
                return true;
            }
            if (rank.Rank.Equals(this.Rank))
            {
                return true;
            }
            return false;
            ;
        }

        public override int GetHashCode()
        {
            return rank.GetHashCode();
        }

        public int CompareTo(CardRank cRank)
        {
            return this.rank.CompareTo(cRank.rank);
        }

        public string Rank
        {
            get => ranks[rank];
        }

        private readonly RankNames rank;

        static Dictionary<CardRank.RankNames, string> ranks =
            new Dictionary<CardRank.RankNames, string>();
    }
}