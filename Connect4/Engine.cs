namespace Connect4
{
    public abstract class Engine
    {
        protected Player player1;
        protected Player player2;

        public Engine()
        {
            player1 = new Player();
            player2 = new Player();
        }

        public void Run()
        {
            UpdateGUI();
            GameLoop();
        }

        protected void PlayerTurn(ref Player player)
        {
            short columnIndex;
            short rowIndex;
            
            while (true)
            {
                PromptUserForMove();
                columnIndex = GetColumnMoveFromUser();
                if (IsValidMove(columnIndex))
                    break;
                InformUserInvalidMove();
            }
            rowIndex = GetRowMoveFromColumnIndex(columnIndex);
            player.OccupyLocation(rowIndex, columnIndex);
        }

        protected void GameLoop()
        {
            while (true)
            {
                PlayerTurn(ref player1);
                UpdateGUI();
                if (player1.CheckForWin())
                {
                    InformPlayer1Win();
                    break;
                }
                
                PlayerTurn(ref player2);
                UpdateGUI();
                if (player2.CheckForWin())
                {
                    InformPlayer2Win();
                    break;
                }
            }
        }

        protected bool IsValidMove(short columnIndex)
        {
            const short cols = Connect4Constants.Dimensions.cols;
            if (columnIndex < 0 || columnIndex >= cols)
            {
                return false;
            }
            ulong fullColumn = Connect4Constants.Masks.fullColumn << columnIndex;
            ulong player1Positions = player1.GetColumn(columnIndex);
            ulong player2Positions = player2.GetColumn(columnIndex);
            ulong columnAtIndex = player1Positions | player2Positions;
            if (columnAtIndex == fullColumn)
            {
                return false;
            }
            return true;
        }

        protected short GetRowMoveFromColumnIndex(short columnIndex)
        {
            ulong player1Positions = player1.GetColumn(columnIndex);
            ulong player2Positions = player2.GetColumn(columnIndex);
            ulong columnAtIndex = player1Positions | player2Positions;

            short rowIndex = 0;
            ulong mask = (ulong)0x1 << columnIndex;
            while((columnAtIndex & mask) == 0x0)
            {
                const short rows = Connect4Constants.Dimensions.rows;
                columnAtIndex = columnAtIndex >> 7;
                rowIndex++;
                if (rowIndex == rows)
                {
                    break;
                }
            }
            rowIndex--;
            return rowIndex;
        }
        
        protected abstract void UpdateGUI();
        protected abstract void PromptUserForMove();
        protected abstract short GetColumnMoveFromUser();
        protected abstract void InformUserInvalidMove();
        protected abstract void InformPlayer1Win();
        protected abstract void InformPlayer2Win();
    }
}
