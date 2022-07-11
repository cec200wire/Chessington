﻿using System.Collections.Generic;
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
                if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) & (potentialMove.Col < 8))
                {
                    validMoves.Add(potentialMove);
                }
            }
            
            return validMoves;
        }
    }
}