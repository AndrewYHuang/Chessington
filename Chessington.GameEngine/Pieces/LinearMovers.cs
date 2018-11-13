using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public static class LinearMovers
    {
        public static IEnumerable<Square> GetLateralMoves(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var lateralMoves = new List<Square>();

            var moveDirections = new[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (var i = 0; i < 4; i++)
            {
                AddMoveDirection(currentSquare, board, moveDirections[i, 0], moveDirections[i, 1], lateralMoves);
            }


            lateralMoves.RemoveAll(s => s == currentSquare);
            return lateralMoves;
        }



        public static IEnumerable<Square> GetDiagonalMoves(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var diagonalMoves = new List<Square>();

            var moveDirections = new [,] {{1, 1}, {1, -1}, {-1, 1}, {-1, -1}};
            for (var i = 0; i < 4; i++)
            {
                AddMoveDirection( currentSquare, board, moveDirections[i,0], moveDirections[i,1], diagonalMoves);
            }

            return diagonalMoves;
        }
        public static void AddMoveDirection(Square currentSquare, Board board, int rowDirection, int colDirection, ICollection<Square> moves)
        {
            for (int i = currentSquare.Row + rowDirection, j = currentSquare.Col + colDirection;;
                    i += rowDirection, j += colDirection)
            {
                var nextSquare = new Square(i,j);
                if (board.SquareIsEmpty(nextSquare))
                {
                    moves.Add(nextSquare);
                }
                else if (board.SquareHasEnemy(nextSquare))
                {
                    moves.Add(nextSquare);
                    break;
                }
                else
                {
                    break;
                }

            }

        }
    }
}