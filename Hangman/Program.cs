using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rernary operator ?:
            int hits = 2;
            Console.WriteLine("you have hit the ball {0} {1}.",
                hits,
                (hits == 1) ? "time" : "times");
            //hits ==1 - condition -> time or times

            //the same with if-else
            string t;

            if (hits==1)
            {
                t = "time";
            }
            else
            {
                t = "times";
            }

            Console.WriteLine("you have hit the ball {0} {1}.", hits, t);

            Console.ReadKey();
        }
    }
}
