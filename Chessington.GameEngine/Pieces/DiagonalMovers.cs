using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class DiagonalMovers
    {
        public static IEnumerable<Square> GetDiagonalMoves(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);

            var diagonalMoves = new List<Square>();

            for (var i = 1; currentSquare.Col - i >= 0 && currentSquare.Row - i >= 0; i++)
            {
                diagonalMoves.Add(Square.At(currentSquare.Col - i, currentSquare.Row - i));
            }

            for (var i = 1; currentSquare.Col - i >= 0 && currentSquare.Row + i < GameSettings.BoardSize; i++)
            {
                diagonalMoves.Add(Square.At(currentSquare.Col - i, currentSquare.Row + i));
            }

            for (var i = 1; currentSquare.Col + i < GameSettings.BoardSize && currentSquare.Row - i >= 0; i++)
            {
                diagonalMoves.Add(Square.At(currentSquare.Col + i, currentSquare.Row - i));
            }

            for (var i = 1; currentSquare.Col + i < GameSettings.BoardSize && currentSquare.Row + i < GameSettings.BoardSize; i++)
            {
                diagonalMoves.Add(Square.At(currentSquare.Col + i, currentSquare.Row + i));
            }
            diagonalMoves.RemoveAll(s => s == currentSquare);
            return diagonalMoves;
        }
    }
}