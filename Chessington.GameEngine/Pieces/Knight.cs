using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> validMoves = new List<Square>();
            List<Square> potentialMoves = new List<Square>();
            
            potentialMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col + 1));
            potentialMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col - 1));
            potentialMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col + 1));
            potentialMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col - 1));
            potentialMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col + 2));
            potentialMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col - 2));
            potentialMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col + 2));
            potentialMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col - 2));

            foreach (Square potentialMove in potentialMoves){
                if (PieceMethods.ConfirmSpace(board, potentialMove))
                {
                    validMoves.Add(potentialMove);
                }
                else
                {
                    if (PieceMethods.ConfirmOpponent(board, potentialMove, Player))
                    {
                        validMoves.Add(potentialMove);
                    }
                }
            }
            return validMoves;
        }
    }
}