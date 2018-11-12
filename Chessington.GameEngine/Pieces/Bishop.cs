using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            // Up and Left
            for (int i = 1; currentSquare.Col - i >= 0 && currentSquare.Row - i >= 0; i++)
                availableMoves.Add(Square.At(currentSquare.Col - i, currentSquare.Row - i));
            // Up and Right
            for (int i = 1; currentSquare.Col + i < GameSettings.BoardSize && currentSquare.Row - i >= 0; i++)
                availableMoves.Add(Square.At(currentSquare.Col + i, currentSquare.Row - i));
            // Down and Left
            for (int i = 1; currentSquare.Col - i >= 0 && currentSquare.Row + i < GameSettings.BoardSize; i++)
                availableMoves.Add(Square.At(currentSquare.Col - i, currentSquare.Row + i));
            // Down and Right
            for (int i = 1; currentSquare.Col + i < GameSettings.BoardSize && currentSquare.Row + i < GameSettings.BoardSize; i++)
                availableMoves.Add(Square.At(currentSquare.Col + i, currentSquare.Row + i));

            return availableMoves;
        }
    }
}