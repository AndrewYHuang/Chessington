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

            var direction = (Player == Player.White) ? -1 : 1;

            var squareInFront = Square.At(currentSquare.Row + direction, currentSquare.Col);
            if (board.SquareIsEmpty(squareInFront))
            {
                availableMoves.Add(squareInFront);

                var squareTwoInFront = Square.At(currentSquare.Row + direction + direction, currentSquare.Col);
                if (!HasMoved && board.SquareIsEmpty(squareTwoInFront))
                {
                    availableMoves.Add(squareTwoInFront);
                }
            }

            var attackingSquareLeft = Square.At(currentSquare.Row + direction, currentSquare.Col+1);
            if (board.SquareHasEnemy(attackingSquareLeft, Player))
            {
                availableMoves.Add(attackingSquareLeft);
            }

            var attackingSquareRight = Square.At(currentSquare.Row + direction, currentSquare.Col-1);
            if (board.SquareHasEnemy(attackingSquareRight, Player))
            {
                availableMoves.Add(attackingSquareRight);
            }
            return availableMoves;
        }
    }
}