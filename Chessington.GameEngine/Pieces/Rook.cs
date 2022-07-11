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
            for (int i = 0; i < 8; i++)
            {
                if (i != currentSquare.Row)
                {
                    validMoves.Add(Square.At(i, currentSquare.Col));
                }

                if (i != currentSquare.Col)
                {
                    validMoves.Add(Square.At(currentSquare.Row, i)); 
                }
            }
            return validMoves;
        }
    }
}