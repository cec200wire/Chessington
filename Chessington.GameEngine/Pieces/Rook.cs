using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
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
                    potentialMove = Square.At(currentSquare.Row + i, currentSquare.Col);
                    if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) &
                        (potentialMove.Col < 8))
                    {
                        if (board.GetPiece(potentialMove) == null)
                        {
                            validMoves.Add(potentialMove);
                        }
                        else
                        {
                            passage[0] = false;
                        }
                    }
                    else
                    {
                        passage[0] = false;
                    }

                }
                if (passage[1])
                {
                    potentialMove = Square.At(currentSquare.Row - i, currentSquare.Col);
                    if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) &
                        (potentialMove.Col < 8))
                    {
                        if (board.GetPiece(potentialMove) == null)
                        {
                            validMoves.Add(potentialMove);
                        }
                        else
                        {
                            passage[1] = false;
                        }
                    }
                    else
                    {
                        passage[1] = false;
                    }

                }
                if (passage[2])
                {
                    potentialMove = Square.At(currentSquare.Row, currentSquare.Col + i);
                    if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) &
                        (potentialMove.Col < 8))
                    {
                        if (board.GetPiece(potentialMove) == null)
                        {
                            validMoves.Add(potentialMove);
                        }
                        else
                        {
                            passage[2] = false;
                        }
                    }
                    else
                    {
                        passage[2] = false;
                    }

                }
                if (passage[3])
                {
                    potentialMove = Square.At(currentSquare.Row, currentSquare.Col - i);
                    if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) &
                        (potentialMove.Col < 8))
                    {
                        if (board.GetPiece(potentialMove) == null)
                        {
                            validMoves.Add(potentialMove);
                        }
                        else
                        {
                            passage[3] = false;
                        }
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