using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Core
{
    internal class GameDispatcher
    {
        #region Properties
        public string[][] CombinationResults { private set; get; }

        public HelpTable HelpTable { private set; get; }
        #endregion

        #region Constructors
        public GameDispatcher(string[] moves)
        {
            FillCombinationResultsTable(moves);
            HelpTable = new HelpTable(moves, CombinationResults);
        }
        #endregion

        #region Methods
        private void FillCombinationResultsTable(string[] moves)
        {
            CombinationResults = new string[moves.Length][];
            for (int i = 0; i < CombinationResults.Length; i++)
            {
                CombinationResults[i] = new string[moves.Length];
                CombinationResults[i][i] = "DRAW";
                for (int j = (i + 1) % CombinationResults[i].Length, winCounter = moves.Length / 2; j != i; j = (j + 1) % CombinationResults[i].Length, winCounter--)
                    CombinationResults[i][j] = winCounter > 0 ? "WIN" : "LOSE";
            }
        }

        public string CheckGameResult(int userMove, int computerMove) => CombinationResults[userMove][computerMove];
        #endregion
    }
}
