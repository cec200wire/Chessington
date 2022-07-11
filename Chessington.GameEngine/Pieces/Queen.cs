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
            bool[] passage = { true, true, true, true , true, true, true, true};
            Square potentialMove = new Square();
            int[,] movements = {{1,0},{1,1},{0,1},{-1,1},{-1,0},{-1,-1},{0,-1},{1,-1}};
            for (int i = 1; i < 8; i++)
            {
                for (int direction = 0; direction < 8; direction++)
                {
                    if (passage[direction])
                    {
                        potentialMove = Square.At(currentSquare.Row + movements[direction, 0]*i, currentSquare.Col + movements[direction, 1]*i);
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
            }
            return validMoves;
        }
    }
}