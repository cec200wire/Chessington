using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Ribbon.Primitives;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> validMoves = new List<Square>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int displaceRow = currentSquare.Row - i;
                    int displaceCol = currentSquare.Col - j;

                    if (displaceRow != 0 || displaceCol != 0)
                    {
                        if (displaceRow * displaceCol == 0)
                        {
                            validMoves.Add(Square.At(i, j));
                        }

                        else if (Math.Abs(displaceRow) == Math.Abs(displaceCol))
                        {
                            validMoves.Add(Square.At(i, j));
                        }
                    }
                }
            }
            return validMoves;
        }
    }
}