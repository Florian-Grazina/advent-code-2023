using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_12
{
    public enum Strenght
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }

    internal class Hand
    {
        public readonly Dictionary<char, int> CardsValue = new() { { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'T', 10 }, { 'J', 1 }, { 'Q', 12 }, { 'K', 13 }, { 'A', 14 } };
        public string Cards { get; set; }
        public int Bids { get; set; }
        public Strenght Strenght { get; set; }
        public long Value {  get; set; }
        public int Rank { get; set; }


        public Hand(string cards, int bids)
        {
            Cards = cards;
            Bids = bids;
            Strenght = CheckStrenght();
            Joker();
            Value = GetValue();
        }


        private Strenght CheckStrenght()
        {
            int joker = 0;
            foreach (char card in Cards)
            {
                if (card == 'J')
                    joker++;
            }

            var groupedCards = Cards.Where(c => c != 'J').GroupBy(c => c).OrderBy(g => g.Count());

            if(Cards.All(c => c == Cards[0]))
                return Strenght.FiveOfAKind;

            if (groupedCards.Any(group => group.Count() == 5))
                return Strenght.FiveOfAKind;

            if (groupedCards.Any(group => group.Count() == 4))
                return Strenght.FourOfAKind;

            if (Cards.GroupBy(c => c).Count() == 2 && joker == 0)
                return Strenght.FullHouse;
            
            if (groupedCards.Any(group => group.Count() == 3))
                return Strenght.ThreeOfAKind;

            if (Cards.GroupBy(c => c).Count() == 3 && joker < 2)
                return Strenght.TwoPair;

            if (groupedCards.Any(group => group.Count() == 2))
                return Strenght.OnePair;

            return Strenght.HighCard;
        }

        private void Joker()
        {
            int joker = 0;
            foreach (char card in Cards)
            {
                if (card == 'J')
                    joker++;
            }

            if (Strenght == Strenght.HighCard)
            {
                Strenght = joker == 1 ? Strenght.OnePair : Strenght;
                Strenght = joker == 2 ? Strenght.ThreeOfAKind : Strenght;
                Strenght = joker == 3 ? Strenght.FourOfAKind : Strenght;
                Strenght = joker == 4 ? Strenght.FiveOfAKind : Strenght;
            }
            else if (Strenght == Strenght.OnePair)
            {
                Strenght = joker == 1 ? Strenght.ThreeOfAKind : Strenght;
                Strenght = joker == 2 ? Strenght.FourOfAKind : Strenght;
                Strenght = joker == 3 ? Strenght.FiveOfAKind : Strenght;
            }
            else if (Strenght == Strenght.TwoPair)
            {
                Strenght = joker == 1 ? Strenght.FullHouse : Strenght;
            }
            else if (Strenght == Strenght.ThreeOfAKind)
            {
                Strenght = joker == 1 ? Strenght.FourOfAKind : Strenght;
                Strenght = joker == 2 ? Strenght.FiveOfAKind : Strenght;
            }
            else if (Strenght == Strenght.FourOfAKind)
            {
                Strenght = joker == 1 ? Strenght.FiveOfAKind : Strenght;
            }
        }

        private long GetValue()
        {
            long toReturn = 0;

            for (int i = 0; i < Cards.Length; i++)
            {
                toReturn += CardsValue[Cards[i]] * (int)Math.Pow(10,(Cards.Length - 1 - i) * 2);
            }

            toReturn += (int)Strenght * (long)Math.Pow(10, 10);

            return toReturn;
        }
    }
}
