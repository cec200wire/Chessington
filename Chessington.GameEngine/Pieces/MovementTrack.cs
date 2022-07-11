namespace Chessington.GameEngine.Pieces;

public class MovementTrack
{
    public static bool[,] StartingPositions =
    {
        { true, true, true, true, true, true, true, true }, { true, true, true, true, true, true, true, true },
        { true, true, true, true, true, true, true, true }, { true, true, true, true, true, true, true, true },
        { true, true, true, true, true, true, true, true }, { true, true, true, true, true, true, true, true },
        { true, true, true, true, true, true, true, true }, { true, true, true, true, true, true, true, true }
    };

    public static bool[,] ChangeInPosition(Square from, bool [,] StartingPositions)
    {
        StartingPositions[from.Row, from.Col] = false;
        return StartingPositions;
    }
}