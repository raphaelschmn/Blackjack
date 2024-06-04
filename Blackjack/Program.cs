using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Output Encoding für Unicode Symbole
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GUI gui = new GUI();
            gui.DisplayStartingScreen();

            Card c1 = new Card(1, 10,"backside");
            Card c2 = new Card(2, 12,"");
            Card c3 = new Card(4, 10,"");

            Card[] cards = {c1, c2, c3 };

            gui.DisplayCards(cards);

            Console.ReadKey();
            /*
            do //Gameloop
            {

            } while (true);
            */
        }
    }
}
