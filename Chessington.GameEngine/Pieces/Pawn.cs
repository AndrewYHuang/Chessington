using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMoved;


        public Pawn(Player player) : base(player)
        {
            HasMoved = false;
        }

        public new void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            HasMoved = true;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            if (Player == Player.White)
            {
                availableMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                if (!HasMoved) availableMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
            }

            else
            {
                availableMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                if (!HasMoved) availableMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
            }
            return availableMoves;
        }
    }
}