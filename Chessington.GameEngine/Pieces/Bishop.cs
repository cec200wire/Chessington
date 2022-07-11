using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> validMoves = new List<Square>();
            bool[] passage = { true, true, true, true };
            Square potentialMove = new Square();
            for (int i = 1; i < 8; i++)
            {
                if (passage[0])
                {
                    potentialMove = Square.At(currentSquare.Row + i, currentSquare.Col + i);
                    if (PieceMethods.CheckMove(board, potentialMove, passage, 0))
                    {
                        validMoves.Add(potentialMove);
                    }
                    else
                    {
                        passage[0] = false;
                    }
                }
                if (passage[1])
                {
                    potentialMove = Square.At(currentSquare.Row + i, currentSquare.Col - i);
                    if (PieceMethods.CheckMove(board, potentialMove, passage, 1))
                    {
                        validMoves.Add(potentialMove);
                    }
                    else
                    {
                        passage[1] = false;
                    }
                }
                if (passage[2])
                {
                    potentialMove = Square.At(currentSquare.Row - i, currentSquare.Col + i);
                    if (PieceMethods.CheckMove(board, potentialMove, passage, 2))
                    {
                        validMoves.Add(potentialMove);
                    }
                    else
                    {
                        passage[2] = false;
                    }
                }
                
                if (passage[3])
                {
                    potentialMove = Square.At(currentSquare.Row - i, currentSquare.Col - i);
                    if (PieceMethods.CheckMove(board, potentialMove, passage, 3))
                    {
                        validMoves.Add(potentialMove);
                    }
                    else
                    {
                        passage[3] = false;
                    }
                }
            }
            
            return validMoves;
        }
    }
}