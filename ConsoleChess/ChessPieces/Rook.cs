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
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board)
    {
        // West direction
        // x is decrementing, y is constant
        if (to.X < from.X && to.Y == from.Y)
        {
            // if there is a piece in the way, return false
            for (var i = from.X - 1; i >= to.X; i--)
            {
                if (board[i, from.Y].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // North direction
        // y is decrementing, x is constant
        if (to.Y < from.Y && to.X == from.X)
        {
            // if there is a piece in the way, return false
            for (var i = from.Y - 1; i >= to.Y; i--)
            {
                if (board[from.X, i].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // East direction
        // x is incrementing, y is constant
        if (to.X > from.X && to.Y == from.Y)
        {
            // if there is a piece in the way, return false
            for (var i = from.X + 1; i <= to.X; i++)
            {
                if (board[i, from.Y].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South direction
        // y is incrementing, x is constant
        if (to.Y > from.Y && to.X == from.X)
        {
            // if there is a piece in the way, return false
            for (var i = from.Y + 1; i <= to.Y; i++)
            {
                if (board[from.X, i].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // move is not horizontal nor vertical
        return false;
    }

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        // West direction
        // x is decrementing, y is constant
        for (var i = position.X - 1; i >= 0; i--)
        {
            if (board[i, position.Y].IsOccupied)
                break;
            yield return board[i, position.Y];
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var i = position.X + 1; i < 8; i++)
        {
            if (board[i, position.Y].IsOccupied)
                break;
            yield return board[i, position.Y];
        }
        
        // North direction
        // y is decrementing, x is constant
        for (var i = position.Y - 1; i >= 0; i--)
        {
            if (board[position.X, i].IsOccupied)
                break;
            yield return board[position.X, i];
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var i = position.Y + 1; i < 8; i++)
        {
            if (board[position.X, i].IsOccupied)
                break;
            yield return board[position.X, i];
        }
    }
}
