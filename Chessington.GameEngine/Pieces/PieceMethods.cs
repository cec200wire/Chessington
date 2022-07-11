using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine;

public class PieceMethods
{
    public static bool ConfirmSpace(Board board, Square potentialMove)
    {
        bool success = false;
        if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) & (potentialMove.Col < 8))
        {
            if ((board.GetPiece(potentialMove)) == null)
            {
                success = true;
            }
        }

        return success;
    }

    public static bool ConfirmOpponent(Board board, Square potentialMove, Player currentPlayer)
    {
        bool opponent = false;
        if ((-1 < potentialMove.Row) & (potentialMove.Row < 8) & (-1 < potentialMove.Col) & (potentialMove.Col < 8))
        {
            if (board.GetPiece(potentialMove).Player != currentPlayer)
            {
                opponent = true;
            }
        }
        return opponent;
    }
}