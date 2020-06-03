using System;

namespace Ozow.GameOfLife.Core
{
    public class GameOfLifeRules : IGameOfLifeRule
    {
        public LifeStatus LifeStatusForNextTick(DeadOrAliveNeighboursCount deadOrAliveNeighbourCounts, LifeStatus currentLifeStatusOfCell)
        {
            if (currentLifeStatusOfCell == LifeStatus.Dead && deadOrAliveNeighbourCounts.AliveNeighbourCount > 3)
            {
                return LifeStatus.Alive;
            }

            if (currentLifeStatusOfCell == LifeStatus.Alive &&
                (deadOrAliveNeighbourCounts.AliveNeighbourCount == 2 ||
                deadOrAliveNeighbourCounts.AliveNeighbourCount == 3))
            {
                return LifeStatus.Alive;
            }

            return LifeStatus.Dead;
        }  
    }
}
