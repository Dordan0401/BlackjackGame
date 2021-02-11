using Blackjack.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class ProgramUI
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Welcome to a game of Blackjack! \n"
                + "It's just you against the dealer \n"
                + "Press any key to continue \n");
            Console.ReadKey();

            Deck deck = new Deck();
            List<Cards> gameDeck = deck.GetDeck();
            Player dealer = new Player();
            Player user = new Player();
            List<Cards> dealerHand;
            List<Cards> userHand;



            Console.Clear();
            Random randCard = new Random();
            dealerHand = dealer.GetDealerHand(gameDeck, randCard);
            userHand = user.GetUserHand(gameDeck, randCard);
            WriteDealerHand();

            WritePlayerHand();

            CheckForBlackjack();


            void CheckForBlackjack()
            {
                if (user.GetCardTotal(userHand) == 21 && dealer.GetCardTotal(dealerHand) != 21)
                {
                    Console.WriteLine("Blackjack! You win!\n" + "Press any key to replay!");
                    Console.ReadKey();
                    this.Run();
                }
                else if (dealer.GetCardTotal(dealerHand) == 21 && user.GetCardTotal(userHand) != 21)
                {
                    Console.WriteLine("The Dealer has blackjack, you lose :(\n" + "Press any key to replay!");
                    Console.ReadKey();
                    this.Run();
                }
                else if (dealer.GetCardTotal(dealerHand) == 21 && user.GetCardTotal(userHand) == 21)
                {
                    Console.WriteLine("You both have blackjack!? What a tie!\n" +
                        "Press any key to replay!");
                    Run();
                }
            }

            HitOrStay();




            //creates keyreader to figure out hit/stay

            void HitOrStay()
            {
                Console.WriteLine("Would you like to (H)it or (S)tay?");
                ConsoleKeyInfo playerOption = Console.ReadKey(true);

                while (playerOption.Key != ConsoleKey.H && playerOption.Key != ConsoleKey.S)
                {
                    Console.WriteLine("Please press a valid key. You can (H)it, or (S)tay");
                    playerOption = Console.ReadKey(true);
                }




                switch (playerOption.Key)
                {
                    case ConsoleKey.H:
                        Console.Clear();
                        Console.WriteLine("You draw a card\n");

                        user.DrawCard(gameDeck);

                        WriteDealerHand();
                        WritePlayerHand();

                        CheckForBlackjack();
                        CheckForBust();
                        HitOrStay();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.S:
                        Console.Clear();
                        Console.WriteLine("You stay\n");
                        while (dealer.GetCardTotal(dealerHand) <= 16)
                        {
                            dealer.DrawCard(gameDeck);
                        }
                        Console.WriteLine("The dealer's hand contains");
                        foreach (Cards card in dealerHand)
                        {
                            Console.WriteLine($"{card.Face} of {card.Suit}");
                        }
                        Console.WriteLine($"Total: {dealer.GetCardTotal(dealerHand)}\n");
                        WritePlayerHand();

                        CheckForBust();
                        CheckForBlackjack();
                        WhoWins();

                        break;

                }
            }

            //while loop to decide which to do. If neither option is selected it asks again



            void WritePlayerHand()
            {
                Console.WriteLine("Your hand contains");
                foreach (Cards card in userHand)
                {
                    Console.WriteLine($"{card.Face} of {card.Suit}");
                }
                Console.WriteLine($"Total: {user.GetCardTotal(userHand)}\n");
            }

            void WriteDealerHand()
            {
                Console.WriteLine("The dealer's hand contains");
                foreach (Cards card in dealerHand)
                {
                    if (card == dealerHand[0])
                    {
                        Console.WriteLine($"{card.Face} of {card.Suit}");
                    }
                    else
                    {
                        Console.WriteLine("[Hole Card]\n");
                    }
                }
            }

            void WhoWins()
            {

                if (user.GetCardTotal(userHand) != 21 && dealer.GetCardTotal(dealerHand) != 21)
                {

                    if (user.GetCardTotal(userHand) > dealer.GetCardTotal(dealerHand))
                    {
                        Console.WriteLine("Congratulations! \n" + "You win! \n" +
                            "Press any key to play again!");
                        Console.ReadKey();
                        Run();
                    }
                    else if (dealer.GetCardTotal(dealerHand) > user.GetCardTotal(userHand))
                    {
                        Console.WriteLine("The dealer wins! \n" +
                            "Press any key to play again!");
                        Console.ReadKey();
                        Run();
                    }
                    else if (user.GetCardTotal(userHand) == dealer.GetCardTotal(dealerHand))
                    {
                        Console.WriteLine("You tied \n" +
                            "Press any key to play again!");
                        Console.ReadKey();
                        Run();
                    }
                }




            }

            void CheckForBust()
            {
                if (user.GetCardTotal(userHand) > 21)
                {
                    Console.WriteLine("You bust!\n" +
                        "Press any key to play again!");
                    Console.ReadKey();
                    Run();
                }
                else if (dealer.GetCardTotal(dealerHand) > 21)
                {
                    Console.WriteLine("The dealer busts. You win!\n" +
                        "Press any key to play again!");
                    Console.ReadKey();
                    Run();
                }
            }

        }


    }
}
