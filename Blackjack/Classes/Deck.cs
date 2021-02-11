using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Classes
{
    public class Deck
    {
        public List<Cards> _deck;

        public Deck() { }

        public List<Cards> GetDeck()
        {
            _deck = new List<Cards>();

            for (int suitVal = 1; suitVal <= 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    if (suitVal == 1)
                    {
                        Cards card = new Cards((Face)rankVal, rankVal, "Diamonds");
                        _deck.Add(card);
                    }
                    else if (suitVal == 2)
                    {
                        Cards card = new Cards((Face)rankVal, rankVal, "Spades");
                        _deck.Add(card);
                    }
                    else if (suitVal == 3)
                    {
                        Cards card = new Cards((Face)rankVal, rankVal, "Hearts");
                        _deck.Add(card);
                    }
                    else
                    {
                        Cards card = new Cards((Face)rankVal, rankVal, "Clubs");
                        _deck.Add(card);
                    }
                }
            }
            foreach(Cards card in _deck)
            {
                if (card.Face == Face.Jack || card.Face == Face.Queen || card.Face == Face.King)
                {
                    card.Value = 10;
                }
            }
            return _deck;
        }
    }
}
