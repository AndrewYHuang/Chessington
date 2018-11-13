using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public void AddAttackOrMove(Board board, Square destinationSquare, ICollection<Square> moves)
        {
            if (board.SquareIsEmpty(destinationSquare) ||
                board.SquareHasEnemy(destinationSquare))
            {
                moves.Add(destinationSquare);
            }
        }
    }
}