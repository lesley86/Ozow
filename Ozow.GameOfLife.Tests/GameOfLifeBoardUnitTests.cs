using Moq;
using NUnit.Framework;
using Ozow.GameOfLife.Core;
using Ozow.GameOfLife.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Ozow.GameOfLife.Tests
{
    public class GameOfLifeBoardUnitTests
    {
        private Mock<IGameOfLifeRule> gameOfLifeRuleMock;

        [SetUp]
        public void Setup()
        {
            gameOfLifeRuleMock = new Mock<IGameOfLifeRule>();
        }

        [Test]
        public void ShouldThrowErrorForInvalidSeedValues()
        {
            gameOfLifeRuleMock.Setup(x => x.LifeStatusForNextTick(It.IsAny<DeadOrAliveNeighboursCount>(), It.IsAny<LifeStatus>())).Returns(LifeStatus.Alive);
            var gol = new GameOfLifeBoard(gameOfLifeRuleMock.Object);

            gol.CreateNewBoard(4, 4);
            Assert.Throws<InvalidSeedException>(() => gol.Seed(new List<RowColumnLifeStatus>() { new RowColumnLifeStatus(-4,4, LifeStatus.Alive) }));
       
        }

        [Test]
        public void ShouldThrowIfPlayIsCalledBeforeBoardCreated()
        {
            gameOfLifeRuleMock.Setup(x => x.LifeStatusForNextTick(It.IsAny<DeadOrAliveNeighboursCount>(), It.IsAny<LifeStatus>())).Returns(LifeStatus.Alive);

            var gol = new GameOfLifeBoard(gameOfLifeRuleMock.Object);
            Assert.Throws<BoardNotCreatedException>(() => gol.PlayGame(1, It.IsAny<Action<LifeStatus[,]>>()));

        }

        [Test]
        public void ShouldThrowIfSeedIsCalledBeforeBoardCreated()
        {
            gameOfLifeRuleMock.Setup(x => x.LifeStatusForNextTick(It.IsAny<DeadOrAliveNeighboursCount>(), It.IsAny<LifeStatus>())).Returns(LifeStatus.Alive);

            var gol = new GameOfLifeBoard(gameOfLifeRuleMock.Object);
            Assert.Throws<BoardNotCreatedException>(() => gol.Seed(new List<RowColumnLifeStatus>() { new RowColumnLifeStatus(-4, 4, LifeStatus.Alive) }));

        }

        [Test]
        public void ShouldThrowIfBoardIsBelowMinimumSize()
        {
            gameOfLifeRuleMock.Setup(x => x.LifeStatusForNextTick(It.IsAny<DeadOrAliveNeighboursCount>(), It.IsAny<LifeStatus>())).Returns(LifeStatus.Alive);
            var gol = new GameOfLifeBoard(gameOfLifeRuleMock.Object);
            Assert.Throws<InvalidBoardSizeException>(() => gol.CreateNewBoard(2, 2));
        }
    }
}