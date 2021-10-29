using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Core
{
    internal class GameMenu
    {
        #region Properties
        public string[] Moves { private set; get; }
        #endregion

        #region Constructors
        public GameMenu(string[] moves)
        {
            if (moves is null)
                throw new ArgumentNullException(nameof(moves));
            if (moves.Length < 3 || moves.Length % 2 != 1)
                throw new ArgumentException($"The length of the {nameof(moves)} argument must not be <3 or have an even number of possible moves. Example: 'rock' 'paper' 'scissors'.");
            if (moves.GroupBy(v => v).Any(g => g.Count() > 1))
                throw new ArgumentException($"Move variations must not be repeated.");
            Moves = moves;
        }
        #endregion

        #region Methods
        public string GetUserMove()
        {
            Console.Write("Enter your move: ");
            var move = Console.ReadLine();
            if (!CheckUserMoveCorrectness(move))
                throw new IndexOutOfRangeException($"Your move must be in the range 0 to {Moves.Length} or be a '?'.");
            return move;
        }

        private bool CheckUserMoveCorrectness(string userMove) => (int.TryParse(userMove, out int move) && (move >= 0 && move <= Moves.Length)) || userMove == "?";

        public void PrintMenu()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < Moves.Length; i++)
                Console.WriteLine(i + 1 + " - " + Moves[i]);
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public string ConvertMoveToString(int move) => Moves[move % Moves.Length];
        #endregion
    }
}
