using Ozow.GameOfLife.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Ozow.GameOfLife.Core
{
    public class GameOfLifeBoard
    {
        private LifeStatus[,] nextViewOfTheBoard;
        private LifeStatus[,] currentViewOfTheBoard;
        private readonly IGameOfLifeRule gameOfLifeRule;

        public GameOfLifeBoard(
            IGameOfLifeRule gameOfLifeRule)
        {
            this.gameOfLifeRule = gameOfLifeRule;
        }

        public void Seed(List<RowColumnLifeStatus> rowColumnValues)
        {
            CheckIfBoardIsCreated();
            ValidateSeedValues(rowColumnValues);
            foreach (var rowColumnValue in rowColumnValues)
            {
                currentViewOfTheBoard[rowColumnValue.Row, rowColumnValue.Column] = rowColumnValue.LifeStatus;
            }
        }

        public void CreateNewBoard(int boardRows, int boardColumns)
        {
            ValidateMinimumBoardSize(boardRows, boardColumns);
            nextViewOfTheBoard = new LifeStatus[boardRows, boardColumns];
            currentViewOfTheBoard = new LifeStatus[boardRows, boardColumns];
        }

        private static void ValidateMinimumBoardSize(int boardRows, int boardColumns)
        {
            if (boardRows < 3 || boardColumns < 3)
            {
                throw new InvalidBoardSizeException("The board needs to be at least 3 by 3 to have 8 neighbours");
            }
        }

        public void PlayGame(int iterations, Action<LifeStatus[,]> boardStateHandlerAction)
        {
            CheckIfBoardIsCreated();
            boardStateHandlerAction?.Invoke(currentViewOfTheBoard);
            for (int amountOfGenerationsIndex = 1; amountOfGenerationsIndex <= iterations; amountOfGenerationsIndex++)
            {
                // one tick
                for (var rowIndex = 0; rowIndex < currentViewOfTheBoard.GetLength(0); rowIndex++)
                {
                    for (var columnIndex = 0; columnIndex < currentViewOfTheBoard.GetLength(1); columnIndex++)
                    {
                        var aliveAndDeadNeighbourCounts = DeadAndAliveNeighboursCountFor(currentViewOfTheBoard, rowIndex, columnIndex);
                        var currentCellValue = CellValueFor(currentViewOfTheBoard, rowIndex, columnIndex);
                        var lifeStatusForNextTick = gameOfLifeRule.LifeStatusForNextTick(aliveAndDeadNeighbourCounts, currentCellValue);
                        setCellValueFor(nextViewOfTheBoard, rowIndex, columnIndex, lifeStatusForNextTick);
                    }
                }

                currentViewOfTheBoard = nextViewOfTheBoard;
                boardStateHandlerAction?.Invoke(currentViewOfTheBoard);
            }
        }

        private void ValidateSeedValues(List<RowColumnLifeStatus> rowColumnValues)
        {
            foreach (var rowColumnValue in rowColumnValues)
            {
                if (rowColumnValue.Row < 0 || rowColumnValue.Row > currentViewOfTheBoard.GetLength(0))
                {
                    throw new InvalidSeedException($"The row value {rowColumnValue.Row} is less than zero or exceeds the board size of {currentViewOfTheBoard.GetLength(0)}");
                }

                if (rowColumnValue.Row < 0 || rowColumnValue.Row > currentViewOfTheBoard.GetLength(1))
                {
                    throw new InvalidSeedException($"The column value {rowColumnValue.Row} is less than zero or exceeds the board size of {currentViewOfTheBoard.GetLength(1)}");
                }
            }
        }

        private void CheckIfBoardIsCreated()
        {
            if (currentViewOfTheBoard == null)
            {
                throw new BoardNotCreatedException("Please Create A Board Before trying to play");
            }
        }

        private static void setCellValueFor(LifeStatus[,] nextViewOfTheBoard, int rowIndex, int columnIndex, LifeStatus aliveOrDeadOnNextTick)
        {
            nextViewOfTheBoard[rowIndex, columnIndex] = aliveOrDeadOnNextTick;
        }

        private static DeadOrAliveNeighboursCount DeadAndAliveNeighboursCountFor(LifeStatus[,] previousViewOfTheBoard, int currentRowLoop, int currentColumnLoop)
        {
            var aliveNeighbours = 0;
            var deadNeighbours = 0;

            //Top Row
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, -1, -1, ref aliveNeighbours, ref deadNeighbours);
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, -1, 0, ref aliveNeighbours, ref deadNeighbours);
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, -1, 1, ref aliveNeighbours, ref deadNeighbours);

            // Same Row As Cell
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, 0, -1, ref aliveNeighbours, ref deadNeighbours);
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, 0, 1, ref aliveNeighbours, ref deadNeighbours);

            // Bottom Row
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, 1, -1, ref aliveNeighbours, ref deadNeighbours);
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, 1, 0, ref aliveNeighbours, ref deadNeighbours);
            IncrementNeighbourType(previousViewOfTheBoard, currentRowLoop, currentColumnLoop, 1, 1, ref aliveNeighbours, ref deadNeighbours);

            return new DeadOrAliveNeighboursCount { AliveNeighbourCount = aliveNeighbours, DeadNeighbourCount = deadNeighbours };
        }

        private static void IncrementNeighbourType(LifeStatus[,] previousViewOfTheBoard, int currentRowLoop, int currentColumnLoop, int rowIndexforNeighbour, int columnIndexForNeighbour, ref int aliveNeighbours, ref int deadNeighbours)
        {
            try
            {
                if (previousViewOfTheBoard[currentRowLoop + rowIndexforNeighbour, currentColumnLoop + columnIndexForNeighbour] == LifeStatus.Dead)
                {
                    deadNeighbours = deadNeighbours + 1;
                    return;
                }

                aliveNeighbours = aliveNeighbours + 1;
            }
            catch (IndexOutOfRangeException e)
            {
                deadNeighbours = deadNeighbours + 1;
            }
        }

        private static LifeStatus CellValueFor(LifeStatus[,] boardOfCells, int rowIndex, int columnIndex)
        {
            return boardOfCells[rowIndex, columnIndex];
        }
    }
}
