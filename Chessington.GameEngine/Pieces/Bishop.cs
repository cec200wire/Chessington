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
            List<Square> potentialMoves = new List<Square>();
            for (int i = 1; i < 8; i++)
            {
                potentialMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + i));
                potentialMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col - i));
                potentialMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col + i));
                potentialMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col - i));
            }

            foreach (Square potentialMove in potentialMoves){
                if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) & (potentialMove.Col < 8))
                {
                    validMoves.Add(potentialMove);
                }
            }
            return validMoves;
        }
    }
}