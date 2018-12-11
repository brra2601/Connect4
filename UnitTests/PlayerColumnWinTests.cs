using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect4;

namespace UnitTests
{
    [TestClass]
    public class PlayerColumnWinTests
    {
        [TestMethod]
        public void ColWin_ShouldWin_FirstLocation()
        {
            ulong winningBoard = 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;

            var player = new Player(winningBoard);
            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void ColWin_ShouldWin_MiddleLocation()
        {
            ulong winningBoard = 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;

            winningBoard = winningBoard << 9;

            var player = new Player(winningBoard);
            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void ColWin_ShouldWin_LastLocation()
        {
            ulong winningBoard = 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;

            winningBoard = winningBoard << 20;

            var player = new Player(winningBoard);
            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void ColWin_ShouldNotWin_OutOfBoundsUpper()
        {
            ulong winningBoard = 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;

            winningBoard = winningBoard << 21;

            var player = new Player(winningBoard);
            Assert.IsFalse(player.CheckForWin());
        }

        [TestMethod]
        public void ColWin_ShouldNotWin_OutOfBoundsLower()
        {
            ulong winningBoard = 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;
            winningBoard = (winningBoard << 7) + 0x1;

            winningBoard = winningBoard >> 1;

            var player = new Player(winningBoard);
            Assert.IsFalse(player.CheckForWin());
        }
    }
}
