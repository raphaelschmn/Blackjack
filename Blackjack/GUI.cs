using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class GUI
    {
        public void GetPlayerInformation(Player p)
        {
            Console.Write("Please enter your name: ");
            p.Name = Console.ReadLine();
        }
        public void DisplayRules()
        {
            Console.WriteLine("Here are the rules:\n" +
                "Try to get as close to 21 without going over.\n" +
                "Kings, Queens and Jacks are worth 10 points.\n" +
                "Aces are worth 1 or 11 points.\n" +
                "Cards 2 to 10 are worth their face value.\n" +
                "(H)it to take another card.\n" +
                "(S)tand to stop taking cards.\n" +
                "On your first play, you can (D)ouble down to increase your bet\n" +
                "but you must hit exactly one more time before standing.\n" +
                "In case of a tie, the bet is returned to you.\n" +
                "The dealer stops hitting at 17.");
        }
        public void DisplayStartingScreen(Player p)
        {
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine();

            GetPlayerInformation(p);

            Console.Clear();
            Console.WriteLine($"Hello {p.Name}!");

            DisplayRules();

            Console.WriteLine();

            Console.WriteLine("To start the gambling press any key and have fun!");

            Console.ReadKey();
            Console.Clear();
        }
        public void GameScreen(Player player, Player dealer, bool dealerTurn)
        {
            bool backside = false;
            Console.Clear();
            if(dealer.CardsInHand == 2 && dealer.Points != 21 && !dealerTurn)
            {
                Console.WriteLine($"Dealer's cards (?):" + "{0, 30}", "Your current bet: " + player.Bet + "$");
                backside = true;
            }else
            {
                Console.WriteLine($"Dealer's cards ({dealer.Points}):" + "{0, 30}", "Your current bet: " + player.Bet + "$");
                backside = false;
            }
            DisplayCards(dealer, backside);
            Console.WriteLine($"\nYour card's ({player.Points}):");
            backside = false;
            DisplayCards(player, backside);
        }

            public void DisplayCards(Player player, bool backsideCard)
        {
            string[] rows = { "", "", "", "", "" };

            for(int i = 0; i < player.CardsInHand; i++)
            {
                if (backsideCard)
                {
                    rows[0] += " ___  ";
                    rows[1] += "|## | ";
                    rows[2] += "|###| ";
                    rows[3] += "|_##| ";
                    backsideCard = false;
                } else
                {
                    rows[0] += " ___  ";
                    rows[1] += string.Format("|{0, -2} | ", player.Hand[i].ValueShown);
                    rows[2] += string.Format("| {0, -1} | ", player.Hand[i].Suit);
                    rows[3] += string.Format("|_{0, 2}| ", player.Hand[i].ValueShown);
                }
            }

            foreach (string row in rows)
            {
                Console.WriteLine(row);
            }
        }
    }
}
