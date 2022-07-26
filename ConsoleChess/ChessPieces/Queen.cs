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
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board)
    {
        // combine mechanics of rook and bishop
        
        // check if move is vertical, horizontal, or diagonal, if not, return false
        if ((from.X == to.X || from.Y == to.Y || Math.Abs(from.X - to.X) == Math.Abs(from.Y - to.Y)) == false)
            return false;

        // -- bishop part -- //

        int xIterator;
        int yIterator;

        // North-West direction
        if (to.X < from.X && to.Y < from.Y)
        {
            xIterator = from.X - 1;
            yIterator = from.Y - 1;

            // if there is a piece in the way, return false
            for (; xIterator >= to.X && yIterator >= to.Y; xIterator--, yIterator--)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // North-East direction
        if (to.X > from.X && to.Y < from.Y)
        {
            xIterator = from.X + 1;
            yIterator = from.Y - 1;
            
            // if there is a piece in the way, return false
            for (; xIterator <= to.X && yIterator >= to.Y; xIterator++, yIterator--)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South-West direction
        if (to.X < from.X && to.Y > from.Y)
        {
            xIterator = from.X - 1;
            yIterator = from.Y + 1;
            
            // if there is a piece in the way, return false
            for (; xIterator >= to.X && yIterator <= to.Y; xIterator--, yIterator++)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South-East direction
        if (to.X > from.X && to.Y > from.Y)
        {
            xIterator = from.X + 1;
            yIterator = from.Y + 1;
            
            // if there is a piece in the way, return false
            for (; xIterator <= to.X && yIterator <= to.Y; xIterator++, yIterator++)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }
        
        // -- rook part -- //
        
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

        // this should be unreachable, but poor compiler doesn't know that :(
        return false;
    }

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        throw new NotImplementedException();
    }
}