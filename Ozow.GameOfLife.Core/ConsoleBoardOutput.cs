using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Core
{
    public class ConsoleBoardOutput 
    {
        public void Output(LifeStatus[,] lifeStatusBoard)
        {
            var result = new StringBuilder();
            for (var rowIndex = 0; rowIndex < lifeStatusBoard.GetLength(0); rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < lifeStatusBoard.GetLength(1); columnIndex++)
                {
                    switch (lifeStatusBoard[rowIndex, columnIndex])
                    {
                        case LifeStatus.Dead:
                            result.Append('D');
                            break;
                        case LifeStatus.Alive:
                            result.Append('A');
                            break;
                        default:
                            result.Append('D');
                            break;
                    }

                }
                result.AppendLine();
            }

            Console.WriteLine(result);
        }
    }
}
