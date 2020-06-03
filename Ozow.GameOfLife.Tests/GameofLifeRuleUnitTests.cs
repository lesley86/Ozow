using NUnit.Framework;
using Ozow.GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Tests
{
    public class GameofLifeRuleUnitTests
    {
        [Test]
        public void ShouldReturnDeadIfDeadAndNot4OrMoreAliveNeighbours()
        {
            var gameOfLifeRule = new GameOfLifeRules();
            var deadOrAliveNeighbourCount = new DeadOrAliveNeighboursCount { AliveNeighbourCount = 3 };
            var result = gameOfLifeRule.LifeStatusForNextTick(deadOrAliveNeighbourCount, LifeStatus.Dead);
            Assert.AreEqual(LifeStatus.Dead, result);
        }

        [Test]
        public void ShouldNotReturnAliveIfAliveAnd2AliveNeighbours()
        {
            var gameOfLifeRule = new GameOfLifeRules();
            var deadOrAliveNeighbourCount = new DeadOrAliveNeighboursCount { AliveNeighbourCount = 2 };
            var result = gameOfLifeRule.LifeStatusForNextTick(deadOrAliveNeighbourCount, LifeStatus.Alive);
            Assert.AreEqual(LifeStatus.Alive, result);
        }

        [Test]
        public void ShouldReturnAliveIfAliveAnd3AliveNeighbours()
        {
            var gameOfLifeRule = new GameOfLifeRules();
            var deadOrAliveNeighbourCount = new DeadOrAliveNeighboursCount { AliveNeighbourCount = 3 };
            var result = gameOfLifeRule.LifeStatusForNextTick(deadOrAliveNeighbourCount, LifeStatus.Alive);
            Assert.AreEqual(LifeStatus.Alive, result);
        }

        [Test]
        public void ShouldReturnAliveIfDeadAnd4OrMoreAliveNeighbours()
        {
            var gameOfLifeRule = new GameOfLifeRules();
            var deadOrAliveNeighbourCount = new DeadOrAliveNeighboursCount { AliveNeighbourCount = 4 };
            var result = gameOfLifeRule.LifeStatusForNextTick(deadOrAliveNeighbourCount, LifeStatus.Dead);
            Assert.AreEqual(LifeStatus.Alive, result);
        }

        [Test]
        public void ShouldReturnDeadIfAliveAnd4OrMoreAliveNeighbours()
        {
            var gameOfLifeRule = new GameOfLifeRules();
            var deadOrAliveNeighbourCount = new DeadOrAliveNeighboursCount { AliveNeighbourCount = 4 };
            var result = gameOfLifeRule.LifeStatusForNextTick(deadOrAliveNeighbourCount, LifeStatus.Alive);
            Assert.AreEqual(LifeStatus.Dead, result);
        }
    }
}
