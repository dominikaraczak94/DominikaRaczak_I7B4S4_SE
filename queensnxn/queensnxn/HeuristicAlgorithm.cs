using System.Collections.Generic;
using System.Linq;

namespace queensnxn
{
    public class HeuristicAlgorithm
    {
        private List<ChessBoard> _chessBoards;

        private void InitFirst(int chessBoardSize)
        {
            _chessBoards = new List<ChessBoard>();
            for (int i = 0; i < chessBoardSize; i++)
            {
                var chessBoard = new ChessBoard(chessBoardSize);
                chessBoard.PutQueen(new Queen(0, i, chessBoardSize));
                _chessBoards.Add(chessBoard);
            }
        }

        public void RunAlgorithm(int chessBoardSize)
        {
            InitFirst(chessBoardSize);
            var best = FindBest(chessBoardSize);
            best.Print();
        }

        public ChessBoard FindBest(int chessBoardSize)
        {
            var bestChessBoard = new ChessBoard(chessBoardSize);
            while (!_chessBoards.Any(x => x.NumberOfQueens == chessBoardSize))
            {
                var highestNumberOfQueens = _chessBoards.Max(x => x.NumberOfQueens);
                var ordered = _chessBoards.Where(x => x.NumberOfQueens == highestNumberOfQueens).OrderByDescending(x => x.FreeSpaces);
                bestChessBoard = ordered.First();
                TryAddQueens(bestChessBoard, ref bestChessBoard);
            }

            return bestChessBoard;
        }

        private void TryAddQueens(ChessBoard board, ref ChessBoard best)
        {
            var row = board.NumberOfQueens;
            var foundBest = false;
            var queens = new List<Queen>();
            for (int i = 0; i < board.Size; i++)
            {
                if (board.Board[row, i] == 0)
                {
                    var newBoard = board.Clone();
                    var queen = new Queen(row, i, board.Size);
                    newBoard.PutQueen(queen);
                    if (HasFreeSpace(newBoard) && !HasSomeRowBlocked(newBoard))
                    {
                        if (newBoard.NumberOfQueens == board.Size)
                        {
                            best = newBoard;
                            foundBest = true;
                        }
                        _chessBoards.Add(newBoard);
                        queens.Add(queen);
                    }
                }

                if (foundBest)
                {
                    break;
                }
            }

            _chessBoards.Remove(board);
        }

        private bool HasFreeSpace(ChessBoard board)
        {
            var queensLeftToPut = board.Size - board.NumberOfQueens;
            if (board.NumberOfQueens < board.Size && board.FreeSpaces < queensLeftToPut)
            {
                return false;
            }

            return true;
        }

        private bool HasSomeRowBlocked(ChessBoard board)
        {
            for (int i = board.NumberOfQueens; i < board.Size; i++)
            {
                var freeSpacesInRow = 0;
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.Board[i, j] == 0)
                    {
                        freeSpacesInRow++;
                    }
                }

                if (freeSpacesInRow == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}