namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Bishop : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Bishop"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Bishop(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'B';

    /// <inheritdoc/>
    public override bool ValidateMove((int x, int y) from, (int x, int y) to, ChessBoard board)
    {
        // if move is not diagonal, return false
        if (Math.Abs(from.x - to.x) == Math.Abs(from.y - to.y) == false)
            return false;

        int xIterator;
        int yIterator;

        // North-West direction
        if (to.x < from.x && to.y < from.y)
        {
            xIterator = from.x - 1;
            yIterator = from.y - 1;

            // if there is a piece in the way, return false
            for (; xIterator >= to.x && yIterator >= to.y; xIterator--, yIterator--)
            {
                if (board[xIterator, yIterator] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // North-East direction
        if (to.x > from.x && to.y < from.y)
        {
            xIterator = from.x + 1;
            yIterator = from.y - 1;
            
            // if there is a piece in the way, return false
            for (; xIterator <= to.x && yIterator >= to.y; xIterator++, yIterator--)
            {
                if (board[xIterator, yIterator] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South-West direction
        if (to.x < from.x && to.y > from.y)
        {
            xIterator = from.x - 1;
            yIterator = from.y + 1;
            
            // if there is a piece in the way, return false
            for (; xIterator >= to.x && yIterator <= to.y; xIterator--, yIterator++)
            {
                if (board[xIterator, yIterator] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South-East direction
        if (to.x > from.x && to.y > from.y)
        {
            xIterator = from.x + 1;
            yIterator = from.y + 1;
            
            // if there is a piece in the way, return false
            for (; xIterator <= to.x && yIterator <= to.y; xIterator++, yIterator++)
            {
                if (board[xIterator, yIterator] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // this return statement should never be reached, but is here to make the compiler happy :P
        return false;
    }
}