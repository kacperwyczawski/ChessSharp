namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Rook : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rook"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Rook(Cell position, ChessBoard parentBoard, Player player)
        : base(position, parentBoard, player)
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
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[currentX, Position.Y].Piece?.Player, Player))
                break;
            
            // return new move
            yield return new Move(ParentBoard[currentX, Position.Y], Position);
            
            // break if the cell is occupied by enemy piece
            if (ParentBoard[currentX, Position.Y].IsOccupied)
                break;
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var currentX = Position.X + 1; currentX < 8; currentX++)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[currentX, Position.Y].Piece?.Player, Player))
                break;
            
            // return new move
            yield return new Move(ParentBoard[currentX, Position.Y], Position);
            
            // break if the cell is occupied by enemy piece
            if (ParentBoard[currentX, Position.Y].IsOccupied)
                break;
        }
        
        // North direction
        // x is constant, y is incrementing
        for (var currentY = Position.Y + 1; currentY < 8; currentY++)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[Position.X, currentY].Piece?.Player, Player))
                break;
            
            // return new move
            yield return new Move(ParentBoard[Position.X, currentY], Position);
            
            // break if the cell is occupied by enemy piece
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }
        
        // South direction
        // x is constant, y is decrementing
        for (var currentY = Position.Y - 1; currentY >= 0; currentY--)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[Position.X, currentY].Piece?.Player, Player))
                break;
            
            // return new move
            yield return new Move(ParentBoard[Position.X, currentY], Position);
            
            // break if the cell is occupied by enemy piece
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }
    }
}
