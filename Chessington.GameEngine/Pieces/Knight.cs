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
                var destinationSquare = new Square(currentSquare.Row + i, currentSquare.Col + j);
                if (board.SquareIsEmpty(destinationSquare) ||
                    board.SquareHasEnemy(destinationSquare))
                {
                    availableMoves.Add(destinationSquare);
                }

                destinationSquare = new Square(currentSquare.Row + j, currentSquare.Col + i);
                if (board.SquareIsEmpty(destinationSquare) ||
                    board.SquareHasEnemy(destinationSquare))
                {
                    availableMoves.Add(destinationSquare);
                }
            }

            availableMoves.RemoveAll(s => !s.IsValid());
            return availableMoves;
        }
    }
}