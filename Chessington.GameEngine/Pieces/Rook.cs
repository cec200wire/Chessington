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
            int[,] movements = {{1,0},{-1,0},{0,1},{0,-1}};
            for (int i = 1; i < 8; i++)
            {
                for (int direction = 0; direction < 4; direction++)
                {
                    if (passage[direction])
                    {
                        potentialMove = Square.At(currentSquare.Row + movements[direction, 0]*i, currentSquare.Col + movements[direction, 1]*i);
                        if (PieceMethods.CheckMove(board, potentialMove))
                        {
                            validMoves.Add(potentialMove);
                        }
                        else
                        {
                            passage[direction] = false;
                        }
                    }
                }
            }
            
            return validMoves;
        }
    }
}