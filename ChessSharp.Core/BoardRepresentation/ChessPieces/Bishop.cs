namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Bishop : ChessPiece
{
    /// <summary>
     /// Initializes a new instance of the <see cref="Bishop"/> class.
     /// </summary>
     /// <inheritdoc/>
    public Bishop(Cell position, ChessBoard parentBoard, Player player)
        : base(position, parentBoard, player)
    {
    }
    
    /// <inheritdoc/>
    public override char ToChar() => 'B';

    public override IEnumerable<Move> GetValidMoves()
    {
        // North-West direction
        // x is decrementing, y is decrementing
        for (int x = Position.X - 1, y = Position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            // always return new move
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            // if piece hit occupied cell, break
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
        
        // North-East direction
        // x is incrementing, y is decrementing
        for (int x = Position.X + 1, y = Position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
        
        // South-West direction
        // x is decrementing, y is incrementing
        for (int x = Position.X - 1, y = Position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
        
        // South-East direction
        // x is incrementing, y is incrementing
        for (int x = Position.X + 1, y = Position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            yield return new Move(ParentBoard[x, y],
                ParentBoard[Position.X, Position.Y]);
            
            if (ParentBoard[x, y].IsOccupied)
                break;
        }
    }
}