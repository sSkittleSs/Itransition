using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new Game(args);
                game.Start();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
