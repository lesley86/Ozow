using Ozow.GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozow.GameOfLife.ConsoleHost
{
    public class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            random = new Random();
            var gol = new GameOfLifeBoard(new GameOfLifeRules());
            string[] rowsAndColumnsArray = GetRowsAndColumnsFromConsole();
            int tickGenerations = GeTickGenerations();
            List<RowColumnLifeStatus> seedList = GetSeed(RowFrom(rowsAndColumnsArray), ColumnFrom(rowsAndColumnsArray));
            SetupAndPlayGameOfLife(gol, RowFrom(rowsAndColumnsArray), ColumnFrom(rowsAndColumnsArray), tickGenerations, seedList);
        }

        private static void SetupAndPlayGameOfLife(GameOfLifeBoard gol, int rows, int columns, int tickGenerations, List<RowColumnLifeStatus> seedList)
        {
            var boardVisualizer = new ConsoleBoardOutput();
            gol.CreateNewBoard(rows, columns);
            if (seedList.Any())
            {
                gol.Seed(seedList);
            }

            gol.PlayGame(tickGenerations, boardVisualizer.Output);
        }

        private static List<RowColumnLifeStatus> GetSeed(int rows, int columns)
        {
            var amountofSeedsToCreate = random.Next(1, HalfTheAreaOfTheBoard(rows, columns));
            var seedList = new List<RowColumnLifeStatus>();
            for (var index = 0; index <= amountofSeedsToCreate; index++)
            {
                seedList.Add(new RowColumnLifeStatus(
                    random.Next(1, rows - 1),
                    random.Next(1, columns - 1),
                    (LifeStatus)random.Next(1, 2)));
            }

            return seedList;
        }

        private static int HalfTheAreaOfTheBoard(int rows, int columns)
        {
            return rows * columns / 2;
        }

        private static int RowFrom(string[] rowsAndColumnsArray)
        {
            return int.Parse(rowsAndColumnsArray[1]);
        }

        private static int ColumnFrom(string[] rowsAndColumnsArray)
        {
            return int.Parse(rowsAndColumnsArray[0]);
        }

        private static int GeTickGenerations()
        {
            Console.WriteLine("Please enter tick iterations");
            var tickGenerations = int.Parse(Console.ReadLine());
            return tickGenerations;
        }

        private static string[] GetRowsAndColumnsFromConsole()
        {
            Console.WriteLine("Please enter amount of rows and columns for board separated by a pipe e.g. row|column = 5|6");
            var rowsAndColumns = Console.ReadLine();
            var rowsAndColumnsArray = rowsAndColumns.Split('|');
            return rowsAndColumnsArray;
        }
    }
}
