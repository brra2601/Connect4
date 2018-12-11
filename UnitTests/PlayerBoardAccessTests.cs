using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect4;
using System;

namespace UnitTests
{
    [TestClass]
    public class PlayerBoardAccessTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AccessColumn_ThrowsException_High()
        {
            var player = new Player();
            player.GetColumn(12);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AccessColumn_ThrowsException_Low()
        {
            var player = new Player();
            player.GetColumn(-1);
        }

        [TestMethod]
        public void AccessColumn_Successful_First()
        {
            ulong column = 0x1;             // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = (column << 7) + 0x1;   // |1| (top of column)

            var player = new Player(column);
            Assert.AreEqual(column, player.GetColumn(0));
        }

        [TestMethod]
        public void AccessColumn_Successful_Middle()
        {
            ulong column = 0x1;             // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = (column << 7) + 0x1;   // |1| (top of column)

            column = column << 3;

            var player = new Player(column);
            Assert.AreEqual(column, player.GetColumn(3));
        }

        [TestMethod]
        public void AccessColumn_Successful_Last()
        {
            ulong column = 0x1;             // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = (column << 7) + 0x1;   // |1| (top of column)

            column = column << 6;

            var player = new Player(column);
            Assert.AreEqual(column, player.GetColumn(6));
        }

        [TestMethod]
        public void AccessColumn_Fail_OutOfBounds_WithNeighbor()
        {
            ulong column = 0x1;             // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = column << 7;           // |0|
            column = (column << 7) + 0x1;   // |1|
            column = (column << 7) + 0x1;   // |1| (top of column)

            column = column << 7;
            column = column + 0x11;

            var player = new Player(column);
            Assert.AreEqual((ulong)0x0, player.GetColumn(6));
        }
    }
}
