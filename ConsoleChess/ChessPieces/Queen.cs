namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Queen : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Queen"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Queen(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'Q';

    /// <inheritdoc/>
    public override bool ValidateMove((int x, int y) from, (int x, int y) to, ChessBoard board)
    {
        // combine mechanics of rook and bishop
        
        // check if move is vertical, horizontal, or diagonal, if not, return false
        if ((from.x == to.x || from.y == to.y || Math.Abs(from.x - to.x) == Math.Abs(from.y - to.y)) == false)
            return false;

        // -- bishop part -- //

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
        
        // -- rook part -- //
        
        // West direction
        // x is decrementing, y is constant
        if (to.x < from.x && to.y == from.y)
        {
            // if there is a piece in the way, return false
            for (var i = from.x - 1; i >= to.x; i--)
            {
                if (board[i, from.y] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // North direction
        // y is decrementing, x is constant
        if (to.y < from.y && to.x == from.x)
        {
            // if there is a piece in the way, return false
            for (var i = from.y - 1; i >= to.y; i--)
            {
                if (board[from.x, i] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // East direction
        // x is incrementing, y is constant
        if (to.x > from.x && to.y == from.y)
        {
            // if there is a piece in the way, return false
            for (var i = from.x + 1; i <= to.x; i++)
            {
                if (board[i, from.y] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South direction
        // y is incrementing, x is constant
        if (to.y > from.y && to.x == from.x)
        {
            // if there is a piece in the way, return false
            for (var i = from.y + 1; i <= to.y; i++)
            {
                if (board[from.x, i] != null)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // this should be unreachable, but poor compiler doesn't know that :(
        return false;
    }
}