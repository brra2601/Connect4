using System;

namespace Connect4
{
    public class Player
    {
        public ulong Bitboard { get; private set; }
        private const short rows = 6;
        private const short cols = 7;

        public Player()
        {
            Bitboard = 0x0;
        }

        public Player(ulong startBoard)
        {
            Bitboard = startBoard;
        }

        public ulong GetColumn(short index)
        {
            if(index >= cols || index < 0)
            {
                throw new Exception("Column index is out of bounds");
            }
            ulong columnMask = 0x810204081; // Full column.
            columnMask = columnMask << index;
            return Bitboard & columnMask;
        }

        public void OccupyLocation(int rowIndex, int colIndex)
        {
            // Handle bad requests.
            if (colIndex >= cols || colIndex < 0)
            {
                throw new Exception("Column index is out of bounds");
            }
            if (rowIndex >= rows || rowIndex < 0)
            {
                throw new Exception("Row index is out of bounds");
            }
                
            // Check to see if the position is already occupied.
            int shiftAmount = 7 * rowIndex + colIndex;
            ulong location = (Bitboard >> shiftAmount) & 0x1;
            if (location == 0x1)
            {
                // If the location is already occupued, the game engine has failed its duty.
                throw new Exception("The location is already occupied, check game engine logic");
            }

            // Change the bit to 1 so it is occupied.
            location = (ulong)0x1 << shiftAmount;
            Bitboard = Bitboard | location;
        }

        public bool CheckForWin()
        {
            bool didWin = false;
            didWin = didWin | CheckForRowWin();
            didWin = didWin | CheckForColWin();
            return didWin;
        }

        private bool CheckForRowWin()
        {
            ulong didWin;
            ulong pos1, pos2, pos3, pos4;
            ulong horizontal4mask = 0xF;

            for(short i = 0; i < rows; i++)
            {
                pos1 = (Bitboard >> (7 * i)) & horizontal4mask;           // 1 1 1 1 0 0 0
                pos2 = (Bitboard >> (1 + (7 * i))) & horizontal4mask;     // 0 1 1 1 1 0 0
                pos3 = (Bitboard >> (2 + (7 * i))) & horizontal4mask;     // 0 0 1 1 1 1 0
                pos4 = (Bitboard >> (3 + (7 * i))) & horizontal4mask;     // 0 0 0 1 1 1 1

                // Comparison generates 0 if there is a win in any of the positions.
                didWin = ~(~horizontal4mask | pos1) &
                         ~(~horizontal4mask | pos2) &
                         ~(~horizontal4mask | pos3) &
                         ~(~horizontal4mask | pos4);

                if (didWin == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckForColWin()
        {
            ulong column;
            ulong didWin;
            ulong columnWinMask = 0x204081;

            for (short i = 0; i < 3; i++)
            {
                for (short j = 0; j < cols; j++)
                {
                    column = Bitboard & columnWinMask;
                    didWin = ~(~columnWinMask | column);
                    if (didWin == 0)
                    {
                        return true;
                    }
                    columnWinMask = columnWinMask << 1;
                }
            }
            return false;
        }
    }
}
