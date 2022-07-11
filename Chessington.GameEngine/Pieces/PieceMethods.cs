using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine;

public class PieceMethods
{
    public static bool CheckMove(Board board, Square potentialMove, int direction)
    {
        bool success = false;
        if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) & (potentialMove.Col < 8))
        {
            if (board.GetPiece(potentialMove) == null)
            {
                success = true;
            }
        }
        return success;
    }
}