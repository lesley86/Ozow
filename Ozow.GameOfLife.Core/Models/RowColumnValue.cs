namespace Ozow.GameOfLife.Core
{
    public class RowColumnLifeStatus
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public LifeStatus LifeStatus { get; private set; }

        public RowColumnLifeStatus(int row, int column, LifeStatus lifeStatus)
        {
            Row = row;
            Column = column;
            LifeStatus = lifeStatus;
        }
    }
}
