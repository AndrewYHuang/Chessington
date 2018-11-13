using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = (List<Square>)LinearMovers.GetLateralMoves(board, this);
            availableMoves.AddRange(LinearMovers.GetDiagonalMoves(board, this));
            return availableMoves;
        }
    }
}