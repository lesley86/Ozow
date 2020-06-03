namespace Ozow.GameOfLife.Core
{
    public interface IGameOfLifeRule
    {
        LifeStatus LifeStatusForNextTick(DeadOrAliveNeighboursCount deadOrAliveNeighbourCounts, LifeStatus currentLifeStatusOfCell);
    }
}
