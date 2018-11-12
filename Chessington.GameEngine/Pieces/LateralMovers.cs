using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class LateralMovers
    {
        public static IEnumerable<Square> GetLateralMoves(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var lateralMoves = new List<Square>();

            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                lateralMoves.Add(Square.At(currentSquare.Row, i));
                lateralMoves.Add(Square.At(i, currentSquare.Col));
            }
            lateralMoves.RemoveAll(s => s == currentSquare);
            return lateralMoves;
        }
    }
}