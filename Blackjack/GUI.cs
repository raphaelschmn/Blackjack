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
        public void GameScreen(Player player, Player dealer, int tick)
        {
            Console.Clear();
            if(tick == 4)
            {
                Console.WriteLine($"Dealer's cards (?):" + "{0, 30}", "Your current bet: " + player.Bet + "$");
            }else
            {
                Console.WriteLine($"Dealer's cards ({dealer.Points}):" + "{0, 30}", "Your current bet: " + player.Bet + "$");
            }
            DisplayCards(dealer, tick);
            tick++;
            Console.WriteLine($"\nYour card's ({player.Points}):");
            DisplayCards(player, tick);
            tick--;
        }

            public void DisplayCards(Player player, int tick)
        {
            string[] rows = { "", "", "", "", "" };

            bool backsideCard = false;

            for(int i = 0; i < player.CardsInHand; i++)
            {
                if (tick == 4 && backsideCard == false)
                {
                    rows[0] += " ___  ";
                    rows[1] += "|## | ";
                    rows[2] += "|###| ";
                    rows[3] += "|_##| ";
                    backsideCard = true;
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
