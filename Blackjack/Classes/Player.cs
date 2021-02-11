using Blackjack.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        public List<Cards> _hand = new List<Cards>();
        public Cards _card = new Cards();

        public List<Cards> GetUserHand(List<Cards> gameDeck, Random randCard)
        {
            _card = gameDeck[randCard.Next(0, 52)];
            _hand.Add(_card);
            Cards cardCheck = gameDeck[randCard.Next(0, 52)];
            do
            {
                cardCheck = gameDeck[randCard.Next(0, 52)];
            } while (cardCheck == _card);
            _card = cardCheck;
            _hand.Add(_card);
            return _hand;
        }
        public List<Cards> GetDealerHand(List<Cards> gameDeck, Random randCard2)
        {
            _card = gameDeck[randCard2.Next(0, 52)];
            _hand.Add(_card);
            Cards cardCheck = gameDeck[randCard2.Next(0, 52)];
            do
            {
                cardCheck = gameDeck[randCard2.Next(0, 52)];
            } while (cardCheck == _card);
            _card = cardCheck;
            _hand.Add(_card);
            return _hand;
        }
        public void DrawCard(List<Cards> gameDeck)
        {
            Random drawCard = new Random();
            _card = gameDeck[drawCard.Next(0, 52)];
            if (!gameDeck.Contains(_card))
            {
                _hand.Add(_card);
            }
            else
            {
                _hand.Add(gameDeck[drawCard.Next(0, 52)]);
            }
        }
        public int GetCardTotal(List<Cards> hand)
        {
            int cardTotal = 0;
            int cardTotalCheck = 0;
            foreach (Cards card in hand)
            {
                if (card.Face == Face.Ace && cardTotal <= 10)
                {
                    card.Value = 11;
                }
                else if (card.Face == Face.Ace && cardTotal > 10)
                {
                    card.Value = 1;
                }
                cardTotalCheck += card.Value;
            }
            if (cardTotalCheck > 21)
            {
                foreach (Cards cardCheck in hand)
                {
                    if (cardCheck.Face == Face.Ace)
                    {
                        cardCheck.Value = 1;
                    }
                    cardTotal += cardCheck.Value;
                }
            }
            else
            {
                cardTotal = cardTotalCheck;
            }
            return cardTotal;
        }
    }
}
