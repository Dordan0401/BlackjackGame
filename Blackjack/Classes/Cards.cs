using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum Face { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public class Cards
    {
        public int Value { get; set; }
        public string Suit { get; set; }
        public Face Face { get; set; }

        public Cards(Face face, int value, string suitType)
        {
            Value = value;
            Suit = suitType;
            Face = face;
        }

        public Cards() { }
    }
}


//List containing 0-41 assigning each number & value to specific card
// to deal: random 0-41 to person A,  random 0-41 (loop to check if used) to person B,  repeat (duno who dealer)
//one dealer card is given to the player, the other isn't.  Player knows both their cards.
// player goes first with H (hit) S(stay) using a key read statement (card total kept track in a variable)
//once player stays, their total is kept as a variable.  Dealer must continue to hit cards till their total is > 16 or they bust
//values are compared to find winner
//Entire deck is used again for subsequent games.