using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            Square[] validMoves = Array.Empty<Square>();
            if (Player == Player.Black)
            {
                validMoves = new Square[]
                {
                    Square.At(currentSquare.Row + 1, currentSquare.Col)
                };
            }
            else
            {
                validMoves = new Square[]
                {
                    Square.At(currentSquare.Row - 1, currentSquare.Col)
                };
            }

            return validMoves;
        }
    }
}