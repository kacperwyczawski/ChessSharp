namespace ChessSharp.Core.BoardRepresentation.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class King : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="King"/> class.
    /// </summary>
    /// <inheritdoc/>
    public King(Cell position, ChessBoard parentBoard, Player player)
        : base(position, parentBoard, player)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'K';

    public override IEnumerable<Move> GetValidMoves()
    {
        // North
        if (Position.Y - 1 >= 0 && !ReferenceEquals(ParentBoard[Position.X, Position.Y - 1].Piece?.Player, Player))
            yield return new Move(Position.GetNorthNeighbor(), Position);

        // North-East
        if (Position.X + 1 < 8 && Position.Y - 1 >= 0 &&
            !ReferenceEquals(ParentBoard[Position.X + 1, Position.Y - 1].Piece?.Player, Player))
            yield return new Move(Position.GetNorthEastNeighbor(), Position);

        // East
        if (Position.X + 1 < 8 && !ReferenceEquals(ParentBoard[Position.X + 1, Position.Y].Piece?.Player, Player))
            yield return new Move(Position.GetEastNeighbor(), Position);

        // South-East
        if (Position.X + 1 < 8 && Position.Y + 1 < 8 &&
            !ReferenceEquals(ParentBoard[Position.X + 1, Position.Y + 1].Piece?.Player, Player))
            yield return new Move(Position.GetSouthEastNeighbor(), Position);

        // South
        if (Position.Y + 1 < 8 && !ReferenceEquals(ParentBoard[Position.X, Position.Y + 1].Piece?.Player, Player))
            yield return new Move(Position.GetSouthNeighbor(), Position);

        // South-West
        if (Position.X - 1 >= 0 && Position.Y + 1 < 8 &&
            !ReferenceEquals(ParentBoard[Position.X - 1, Position.Y + 1].Piece?.Player, Player))
            yield return new Move(Position.GetSouthWestNeighbor(), Position);

        // West
        if (Position.X - 1 >= 0 && !ReferenceEquals(ParentBoard[Position.X - 1, Position.Y].Piece?.Player, Player))
            yield return new Move(Position.GetWestNeighbor(), Position);

        // North-West
        if (Position.X - 1 >= 0 && Position.Y - 1 >= 0 &&
            !ReferenceEquals(ParentBoard[Position.X - 1, Position.Y - 1].Piece?.Player, Player))
            yield return new Move(Position.GetNorthWestNeighbor(), Position);
    }
}