namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Queen : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Queen"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Queen(Cell position, ChessBoard parentBoard, Player player)
        : base(position, parentBoard, player)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'Q';

    public override IEnumerable<Move> GetValidMoves()
    {
        // Combined mechanics of rook and bishop
        
        // North
        // y is decrementing, x is constant
        for (var currentY = Position.Y - 1; currentY >= 0; currentY--)
        {
            // return new move
            yield return new Move(ParentBoard[Position.X, currentY], Position);
            
            // if there is a piece, break this direction, but return move anyway, because it is a valid capture
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }
        
        // North-East
        // y is decrementing, x is incrementing
        for (int x = Position.X + 1, y = Position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
        
        // East
        // x is incrementing, y is constant
        for (var currentX = Position.X + 1; currentX <= 7; currentX++)
        {
            yield return new Move(ParentBoard[currentX, Position.Y], Position);
            
            if (ParentBoard[currentX, Position.Y].IsOccupied)
                break;
        }
        
        // South-East
        // y is incrementing, x is incrementing
        for (int x = Position.X + 1, y = Position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
        
        // South
        // y is incrementing, x is constant
        for (var currentY = Position.Y + 1; currentY <= 7; currentY++)
        {
            yield return new Move(ParentBoard[Position.X, currentY], Position);
            
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }
        
        // South-West
        // y is incrementing, x is decrementing
        for (int x = Position.X - 1, y = Position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
        
        // West
        // x is decrementing, y is constant
        for (var currentX = Position.X - 1; currentX >= 0; currentX--)
        {
            yield return new Move(ParentBoard[currentX, Position.Y], Position);
            
            if (ParentBoard[currentX, Position.Y].IsOccupied)
                break;
        }
        
        // North-West
        // y is decrementing, x is decrementing
        for (int x = Position.X - 1, y = Position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
    }
}