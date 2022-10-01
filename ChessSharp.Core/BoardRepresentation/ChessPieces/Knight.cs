namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Knight : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Knight"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Knight(Cell position, ChessBoard parentBoard, Player player)
        : base(position, parentBoard, player)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'N';

    public override IEnumerable<Move> GetValidMoves()
    {
        if (Position.X - 1 >= 0
            && Position.Y - 2 >= 0
            && !ReferenceEquals(ParentBoard[Position.X - 1, Position.Y - 2].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X - 1, Position.Y - 2], Position);
        
        if (Position.X + 1 < 8
            && Position.Y - 2 >= 0
            && !ReferenceEquals(ParentBoard[Position.X + 1, Position.Y - 2].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X + 1, Position.Y - 2], Position);
        
        if (Position.X + 2 < 8
            && Position.Y - 1 >= 0
            && !ReferenceEquals(ParentBoard[Position.X + 2, Position.Y - 1].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X + 2, Position.Y - 1], Position);
        
        if (Position.X + 2 < 8
            && Position.Y + 1 < 8
            && !ReferenceEquals(ParentBoard[Position.X + 2, Position.Y + 1].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X + 2, Position.Y + 1], Position);
        
        if (Position.X + 1 < 8
            && Position.Y + 2 < 8
            && !ReferenceEquals(ParentBoard[Position.X + 1, Position.Y + 2].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X + 1, Position.Y + 2], Position);
        
        if (Position.X - 1 >= 0
            && Position.Y + 2 < 8
            && !ReferenceEquals(ParentBoard[Position.X - 1, Position.Y + 2].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X - 1, Position.Y + 2], Position);
        
        if (Position.X - 2 >= 0
            && Position.Y + 1 < 8
            && !ReferenceEquals(ParentBoard[Position.X - 2, Position.Y + 1].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X - 2, Position.Y + 1], Position);
        
        if (Position.X - 2 >= 0
            && Position.Y - 1 >= 0
            && !ReferenceEquals(ParentBoard[Position.X - 2, Position.Y - 1].Piece?.Player, Player))
            yield return new Move(ParentBoard[Position.X - 2, Position.Y - 1], Position);
    }
}