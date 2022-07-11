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
            List<Square> validMoves = new List<Square>();
            int direction = 0;
            if (Player == Player.Black)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            Square potentialMove = Square.At(currentSquare.Row + direction, currentSquare.Col);
            if (PieceMethods.ConfirmSpace(board, potentialMove))
            {
                validMoves.Add(potentialMove);
                if ((currentSquare.Row-direction)%7 == 0)
                {
                    potentialMove = Square.At(currentSquare.Row + 2 * direction, currentSquare.Col);
                    if (PieceMethods.ConfirmSpace(board, potentialMove))
                    {
                        validMoves.Add(potentialMove);
                    }
                }
            }

            for (int side = -1; side < 2; side += 2)
            {
                potentialMove = Square.At(currentSquare.Row + direction, currentSquare.Col + side);
                if (PieceMethods.ConfirmOpponent(board, potentialMove, Player))
                {
                    validMoves.Add(potentialMove);
                }
            }

            return validMoves;
        }
    }
}