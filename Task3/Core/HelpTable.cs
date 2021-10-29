using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Core
{
    internal class HelpTable
    {
        #region Properties
        public ConsoleTable Table { private set; get; }
        #endregion

        #region Constructors
        public HelpTable(string[] moves, string[][] combinationResults) => FillHelpTable(moves, combinationResults);
        #endregion

        #region Methods
        private void FillHelpTable(string[] moves, string[][] combinationResults)
        {
            var header = new string[1 + moves.Length];
            header[0] = "PC \\ User";
            Array.Copy(moves, 0, header, 1, moves.Length);
            Table = new ConsoleTable(header);
            for (int i = 0; i < moves.Length; i++)
            {
                var row = new string[1 + moves.Length];
                row[0] = moves[i];
                Array.Copy(combinationResults[i], 0, row, 1, combinationResults[i].Length);
                Table.AddRow(row);
            }
        }

        public void PrintHelpTable() => Table.Write(Format.Alternative);
        #endregion
    }
}
