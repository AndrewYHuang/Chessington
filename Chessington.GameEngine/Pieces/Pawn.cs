using System.Collections.Generic;
using Chessington.GameEngine;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMoved;
        public bool CanEnPassant { get; private set; }
        public int Direction;
        public Board Board;

        public void ClearEnPassantOnPlayerChange(Player CurrentPlayer)
        {
            if (CurrentPlayer == this.Player)
            {
                CanEnPassant = false;
                Board.CurrentPlayerChanged -= ClearEnPassantOnPlayerChange;
            }
            
        }

        public Pawn(Player player) : base(player)
        {
            HasMoved = false;
            CanEnPassant = false;
            Direction = (Player == Player.White) ? -1 : 1;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            base.MoveTo(board, newSquare);
            HasMoved = true;
            Board = board;
            if (newSquare == Square.At(currentSquare.Row + Direction + Direction, currentSquare.Col))
            {
                CanEnPassant = true;
                Board.CurrentPlayerChanged += ClearEnPassantOnPlayerChange;
            }
            
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            var squareInFront = Square.At(currentSquare.Row + Direction, currentSquare.Col);
            if (board.SquareIsEmpty(squareInFront))
            {
                availableMoves.Add(squareInFront);
                var squareTwoInFront = Square.At(currentSquare.Row + Direction + Direction, currentSquare.Col);
                if (!HasMoved && board.SquareIsEmpty(squareTwoInFront))
                {
                    availableMoves.Add(squareTwoInFront);
                }
            }



            foreach (var i in new[] {-1, 1})
            {
            var attackingSquare = Square.At(currentSquare.Row + Direction, currentSquare.Col + i);
            if (board.SquareHasEnemy(attackingSquare, Player))
            {
                availableMoves.Add(attackingSquare);
            }
                var adjacentSquare = Square.At(currentSquare.Row, currentSquare.Col + i);
                if (board.GetPiece(adjacentSquare) is Pawn &&
                    board.GetPiece(adjacentSquare).Player != Player &&
                    ((Pawn)board.GetPiece(adjacentSquare)).CanEnPassant)
                {
                    availableMoves.Add(attackingSquare);
                }

            }

            return availableMoves;
        }
    }
}