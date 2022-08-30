namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Rook : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rook"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Rook(Color color, Cell position, ChessBoard parentBoard)
        : base(color, position, parentBoard)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'R';

    /// <inheritdoc/>
    public override IEnumerable<Move> GetValidMoves()
    {
        // West direction
        // x is decrementing, y is constant
        for (var currentX = Position.X - 1; currentX >= 0; currentX--)
        {
            // return new move
            yield return new Move(ParentBoard[currentX, Position.Y], Position);
            
            // if there is a piece, break this direction, but return move anyway, because it is a valid capture
            if (ParentBoard[currentX, Position.Y].IsOccupied)
                break;
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var currentX = Position.X + 1; currentX < 8; currentX++)
        {
            // return new move
            yield return new Move(ParentBoard[currentX, Position.Y], Position);
            
            // if there is a piece, break this direction, but return move anyway, because it is a valid capture
            if (ParentBoard[currentX, Position.Y].IsOccupied)
                break;
        }
        
        // North direction
        // y is decrementing, x is constant
        for (var currentY = Position.Y - 1; currentY >= 0; currentY--)
        {
            // return new move
            yield return new Move(ParentBoard[Position.X, currentY], Position);
            
            // if there is a piece, break this direction, but return move anyway, because it is a valid capture
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var currentY = Position.Y + 1; currentY < 8; currentY++)
        {
            // return new move
            yield return new Move(ParentBoard[Position.X, currentY], Position);
            
            // if there is a piece, break this direction, but return move anyway, because it is a valid capture
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }
    }
}
