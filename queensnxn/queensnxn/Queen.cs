namespace queensnxn
{
    public class Queen
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public byte[,] AttackedFields { get; set; }

        public Queen(int positionX, int positionY, int chessBoardSize)
        {
            PositionX = positionX;
            PositionY = positionY;
            Attack(chessBoardSize);
        }

        public void Attack(int chessBoardSize)
        {
            var chessBoard = new byte[chessBoardSize, chessBoardSize];
            for (int i = 0; i < chessBoardSize; i++)
            {
                chessBoard[PositionX, i] = 1;
                chessBoard[i, PositionY] = 1;

                if (PositionY - i >= 0)
                {
                    if (PositionX - i >= 0)
                    {
                        chessBoard[PositionX - i, PositionY - i] = 1;
                    }

                    if (PositionX + i < chessBoardSize)
                    {
                        chessBoard[PositionX + i, PositionY - i] = 1;
                    }
                }

                if (PositionY + i < chessBoardSize)
                {
                    if (PositionX - i >= 0)
                    {
                        chessBoard[PositionX - i, PositionY + i] = 1;
                    }

                    if (PositionX + i < chessBoardSize)
                    {
                        chessBoard[PositionX + i, PositionY + i] = 1;
                    }
                }
            }

            AttackedFields = chessBoard;
        }
    }
}