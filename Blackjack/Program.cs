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
            gui.StartingScreen();
            
            do //Gameloop
            {

            } while (true);
        }
    }
}
