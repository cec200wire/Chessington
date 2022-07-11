using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            List<Square> validMoves = new List<Square>();
            bool[] passage = { true, true, true, true , true, true, true, true};
            Square potentialMove = new Square();
            int[,] movements = {{1,0},{1,1},{0,1},{-1,1},{-1,0},{-1,-1},{0,-1},{1,-1}};
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
            
            //Castling
            if (MovementTrack.StartingPositions[currentSquare.Row, currentSquare.Col] & (currentSquare.Row == 0 || currentSquare.Row == 7))
            {
                if (MovementTrack.StartingPositions[currentSquare.Row, currentSquare.Col + 3])
                {
                    potentialMove = Square.At(currentSquare.Row, currentSquare.Col + 2);
                    if (PieceMethods.ConfirmSpace(board, potentialMove))
                    {
                        validMoves.Add(potentialMove);
                    }
                }
                if (MovementTrack.StartingPositions[currentSquare.Row, currentSquare.Col - 4])
                {
                    potentialMove = Square.At(currentSquare.Row, currentSquare.Col - 3);
                    if (PieceMethods.ConfirmSpace(board, potentialMove))
                    {
                        validMoves.Add(potentialMove);
                    }
                }
            }
            return validMoves;
        }
    }
}