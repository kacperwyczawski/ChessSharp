namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Rook : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rook"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Rook(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'R';

    /// <inheritdoc/>
    public override bool ValidateMove((int x, int y) from, (int x, int y) to, ChessBoard board)
    {
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

        // move is not horizontal nor vertical
        return false;
    }
}
