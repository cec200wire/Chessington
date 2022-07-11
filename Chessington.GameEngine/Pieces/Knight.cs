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
            bool[] passage = { true, true, true, true , true, true, true, true};
            Square potentialMove = new Square();
            int[,] movements = {{2,1},{2,-1},{1,-2},{-1,-2},{-2,-1},{-2,1},{-1,2},{1,2}};
            for (int direction = 0; direction < 8; direction++)
            {
                if (passage[direction])
                {
                    potentialMove = Square.At(currentSquare.Row + movements[direction, 0], currentSquare.Col + movements[direction, 1]);
                    if (PieceMethods.ConfirmSpace(board, potentialMove))
                    {
                        validMoves.Add(potentialMove);
                    }
                    else
                    {
                        passage[direction] = false;
                        if (PieceMethods.ConfirmOpponent(board, potentialMove, Player))
                        {
                            validMoves.Add(potentialMove);
                        }
                    }
                }
            }
            return validMoves;
        }
    }
}