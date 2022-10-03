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
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[Position.X, currentY].Piece?.Player, Player))
                break;

            // return new move
            yield return new Move(ParentBoard[Position.X, currentY], Position);

            // break if the cell is occupied by enemy piece
            if (ParentBoard[Position.X, currentY].IsOccupied)
                break;
        }

        // North-East
        // y is decrementing, x is incrementing
        for (int currentX = Position.X + 1, currentY = Position.Y - 1;
             currentX <= 7 && currentY >= 0;
             currentX++, currentY--)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[currentX, currentY].Piece?.Player, Player))
                break;

            // return new move
            yield return new Move(ParentBoard[currentX, currentY], Position);

            // break if the cell is occupied by enemy piece
            if (ParentBoard[currentX, currentY].IsOccupied)
                break;
        }

        // East
        // y is constant, x is incrementing
        for (var currentX = Position.X + 1; currentX <= 7; currentX++)
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
        
        // South-East
        // y is incrementing, x is incrementing
        for (int currentX = Position.X + 1, currentY = Position.Y + 1;
             currentX <= 7 && currentY <= 7;
             currentX++, currentY++)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[currentX, currentY].Piece?.Player, Player))
                break;

            // return new move
            yield return new Move(ParentBoard[currentX, currentY], Position);

            // break if the cell is occupied by enemy piece
            if (ParentBoard[currentX, currentY].IsOccupied)
                break;
        }
        
        // South
        // y is incrementing, x is constant
        for (var currentY = Position.Y + 1; currentY <= 7; currentY++)
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
        
        // South-West
        // y is incrementing, x is decrementing
        for (int currentX = Position.X - 1, currentY = Position.Y + 1;
             currentX >= 0 && currentY <= 7;
             currentX--, currentY++)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[currentX, currentY].Piece?.Player, Player))
                break;

            // return new move
            yield return new Move(ParentBoard[currentX, currentY], Position);

            // break if the cell is occupied by enemy piece
            if (ParentBoard[currentX, currentY].IsOccupied)
                break;
        }
        
        // West
        // y is constant, x is decrementing
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
        
        // North-West
        // y is decrementing, x is decrementing
        for (int currentX = Position.X - 1, currentY = Position.Y - 1;
             currentX >= 0 && currentY >= 0;
             currentX--, currentY--)
        {
            // break if the cell is occupied by a piece of the same player
            if (ReferenceEquals(ParentBoard[currentX, currentY].Piece?.Player, Player))
                break;

            // return new move
            yield return new Move(ParentBoard[currentX, currentY], Position);

            // break if the cell is occupied by enemy piece
            if (ParentBoard[currentX, currentY].IsOccupied)
                break;
        }
    }
}