using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= 1; j++)
            {
                availableMoves.Add(new Square(currentSquare.Row + i, currentSquare.Col + j));
            }

            availableMoves.RemoveAll(s => !s.IsValid());
            availableMoves.RemoveAll(s => s == currentSquare);
            return availableMoves;
        }
    }
}