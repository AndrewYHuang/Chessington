using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            foreach (var i in new [] {-2, 2})
            foreach (var j in new [] {-1, 1})
            {
                AddAttackOrMove(board, new Square(currentSquare.Row + i, currentSquare.Col + j), availableMoves);
                AddAttackOrMove(board, new Square(currentSquare.Row + j, currentSquare.Col + i), availableMoves);
            }

            availableMoves.RemoveAll(s => !s.IsValid());
            return availableMoves;
        }
    }
}