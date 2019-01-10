using System;

namespace queensnxn
{
    public class ChessBoard
    {
        public ChessBoard(int size)
        {
            Size = size;
            Board = new byte[Size, Size];
            NumberOfQueens = 0;
        }

        public int NumberOfQueens { get; set; }
        public byte[,] Board { get; set; }
        public int Size { get; set; }
        public int FreeSpaces => CountFreeSpaces();

        public ChessBoard Clone()
        {
            var newBoard = new ChessBoard(Size);
            newBoard.NumberOfQueens = NumberOfQueens;
            newBoard.Board = (byte[,])Board.Clone();
            return newBoard;
        }

        private int CountFreeSpaces()
        {
            var counter = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public void PutQueen(Queen queen)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (queen.AttackedFields[i, j] == 1)
                    {
                        Board[i, j] = 1;
                    }
                }
            }
            Board[queen.PositionX, queen.PositionY] = 255;
            NumberOfQueens++;
        }

        public void Print()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //   Console.Write("   A B C D E F G H \n");
            Console.WriteLine();
            for (int i = 0; i < Size; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] == 255)
                    {
                        Console.Write("X ");
                    }
                    else if (Board[i, j] == 1)
                    {
                        Console.Write("· ");
                    }
                    else
                    {
                        Console.Write($"{Board[i, j]} ");
                    }
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}