using System;

namespace Connect4
{
    public class Player
    {
        public ulong Bitboard { get; private set; }

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
            const short cols = Connect4Constants.Dimensions.cols;
            if(index >= cols || index < 0)
            {
                throw new Exception("Column index is out of bounds");
            }
            ulong columnMask = Connect4Constants.Masks.fullColumn;
            columnMask = columnMask << index;
            return Bitboard & columnMask;
        }

        public void OccupyLocation(int rowIndex, int colIndex)
        {
            const short cols = Connect4Constants.Dimensions.cols;
            const short rows = Connect4Constants.Dimensions.rows;

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
            if (CheckForRowWin() == true)
            {
                return true;
            }
            if (CheckForColWin() == true)
            {
                return true;
            }
            if (CheckForDiagWin() == true)
            {
                return true;
            }
            return false;
        }

        private bool CheckForRowWin()
        {
            ulong horizontal;
            ulong didWin;
            ulong horizontalMask = Connect4Constants.Masks.horizontal4;
            const short rows = Connect4Constants.Dimensions.rows;

            for(short i = 0; i < rows; i++)
            {
                for(short j = 0; j < 4; j++)
                {
                    horizontal = Bitboard & horizontalMask;
                    didWin = ~(~horizontalMask | horizontal);
                    if (didWin == 0)
                    {
                        return true;
                    }
                    horizontalMask = horizontalMask << 1;
                }
                horizontalMask = horizontalMask << 3;
            }
            return false;
        }

        private bool CheckForColWin()
        {
            ulong column;
            ulong didWin;
            ulong columnWinMask = Connect4Constants.Masks.vertical4;
            const short cols = Connect4Constants.Dimensions.cols;

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

        private bool CheckForDiagWin()
        {
            ulong diagonal;
            ulong didWin;
            ulong diagonalWinMask = Connect4Constants.Masks.diagonalTopRight;

            for (short i = 0; i < 3; i++)
            {
                for (short j = 0; j < 4; j++)
                {
                    diagonal = Bitboard & diagonalWinMask;
                    didWin = ~(~diagonalWinMask | diagonal);
                    if (didWin == 0 && diagonal != 0)
                    {
                        return true;
                    }
                    
                    diagonalWinMask = diagonalWinMask << 1;
                }
                diagonalWinMask = diagonalWinMask << 3;
            }

            diagonalWinMask = Connect4Constants.Masks.diagonalTopLeft;

            for (short i = 0; i < 3; i++)
            {
                for (short j = 0; j < 4; j++)
                {
                    diagonal = Bitboard & diagonalWinMask;
                    didWin = ~(~diagonalWinMask | diagonal);
                    if (didWin == 0 && diagonal != 0)
                    {
                        return true;
                    }

                    diagonalWinMask = diagonalWinMask << 1;
                }
                diagonalWinMask = diagonalWinMask << 3;
            }
            return false;
        }
    }
}
