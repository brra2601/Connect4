using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect4;

namespace UnitTests
{
    [TestClass]
    public class PlayerRowWinTests
    {
        [TestMethod]
        public void RowWin_ShouldWin()
        {
            var player = new Player((ulong)0xF << 3);
            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void RowWin_ShouldNotWin_RowContinuation()
        {
            var player = new Player((ulong)0xF << 4);
            Assert.IsFalse(player.CheckForWin());
        }

        [TestMethod]
        public void RowWin_ShouldWin_LastPossibleLocation()
        {
            var player = new Player((ulong)0xF << 38);
            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void RowWin_ShouldNotWin_OutOfBounds_AndRowOverlap()
        {
            var player = new Player((ulong)0xF << 39);
            Assert.IsFalse(player.CheckForWin());
        }

        [TestMethod]
        public void RowWin_ShouldNotWin_OutOfBoundsUpper()
        {
            var player = new Player((ulong)0xF << 42);
            Assert.IsFalse(player.CheckForWin());
        }

        [TestMethod]
        public void RowWin_ShouldNotWin_OutOfBoundsLower()
        {
            var player = new Player((ulong)0xF >> 1);
            Assert.IsFalse(player.CheckForWin());
        }
    }
}
