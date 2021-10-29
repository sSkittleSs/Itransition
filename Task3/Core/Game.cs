using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ConsoleTables;

namespace Task3.Core
{
    internal class Game
    {
        #region Fields
        private int computerMove;
        private readonly GameDispatcher gameDispatcher;
        private readonly GameMenu gameMenu;
        #endregion

        #region Properties
        public byte[] HMAC { private set; get; }
        
        public byte[] Key { private set; get; }

        public string UserMove { private set; get; }
        #endregion

        #region Constructors
        public Game(string[] moves)
        {
            gameDispatcher = new GameDispatcher(moves);
            gameMenu = new GameMenu(moves);
        }
        #endregion

        #region Methods
        private void MakeComputerMove()
        {
            Key = HMACSHA256Generator.GetKey();
            computerMove = HMACSHA256Generator.GetByte() % gameMenu.Moves.Length;
            HMAC = HMACSHA256Generator.GetHMAC(Key, Encoding.Default.GetBytes(gameMenu.ConvertMoveToString(computerMove)));
        }

        private void DoUserMove(string userMove)
        {
            if (userMove == "?")
            {
                PrintHelpTable();
            }
            else if (int.TryParse(userMove, out int move))
            {
                if (move == 0)
                {
                    Console.WriteLine("Your move: exit\nGood bye!");
                    return;
                }

                UserMove = gameMenu.ConvertMoveToString(Convert.ToInt32(move - 1));
                Console.WriteLine("Your move: " + UserMove);
                Console.WriteLine("Computer move: " + gameMenu.ConvertMoveToString(computerMove));
                Console.WriteLine($"Result of your game: {gameDispatcher.CheckGameResult(Convert.ToInt32(move - 1), computerMove)} !");
                Console.WriteLine("Key: " + BitConverter.ToString(Key).Replace("-", string.Empty));
            }
        }

        public void PrintHelpTable()
        {
            Console.WriteLine("\n\tHelp table");
            gameDispatcher.HelpTable.PrintHelpTable();
            Console.WriteLine("Reopen the app to start the game.");
        }

        public void Start()
        {
            MakeComputerMove();
            Console.WriteLine("HMAC: " + BitConverter.ToString(HMAC).Replace("-", string.Empty));
            gameMenu.PrintMenu();
            DoUserMove(gameMenu.GetUserMove());
        }

        public override string ToString() => 
            $"Moves: {string.Join(" ", gameMenu.Moves)}" +
            $"\nHMAC: {BitConverter.ToString(HMAC).Replace("-", string.Empty)}" +
            $"\nKey: {BitConverter.ToString(Key).Replace("-", string.Empty)}" +
            $"\nComputer move: {gameMenu.ConvertMoveToString(computerMove)}";
        #endregion
    }
}
