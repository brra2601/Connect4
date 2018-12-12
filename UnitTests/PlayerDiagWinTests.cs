using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect4;

namespace UnitTests
{
    [TestClass]
    public class PlayerDiagWinTests
    {
        [TestMethod]
        public void DiagWin_ShouldWin_FirstPosition()
        {
            var player = new Player();
            player.OccupyLocation(0, 3);
            player.OccupyLocation(1, 2);
            player.OccupyLocation(2, 1);
            player.OccupyLocation(3, 0);

            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void DiagWin_ShouldWin_LastPosition()
        {
            var player = new Player();
            player.OccupyLocation(2, 6);
            player.OccupyLocation(3, 5);
            player.OccupyLocation(4, 4);
            player.OccupyLocation(5, 3);

            Assert.IsTrue(player.CheckForWin());
        }

        [TestMethod]
        public void DiagWin_ShouldNotWin_MissingMiddle()
        {
            var player = new Player();
            //player.OccupyLocation(2, 6);
            //player.OccupyLocation(3, 5);
            //player.OccupyLocation(4, 4);
            player.OccupyLocation(5, 3);
            //Console.Write("{0:x}", player.Bitboard);

            Assert.IsFalse(player.CheckForWin());
        }

        [TestMethod]
        public void DiagWin_ShouldNotWin_NoPieces()
        {
            var player = new Player();
            Assert.IsFalse(player.CheckForWin());
        }
    }
}
