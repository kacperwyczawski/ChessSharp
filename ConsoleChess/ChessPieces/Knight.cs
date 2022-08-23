using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Knight : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Knight"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Knight(Color color, Cell position, ChessBoard parentBoard)
        : base(color, position, parentBoard)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'N';

    public override IEnumerable<Move> GetValidMoves()
    {
        if (Position.X - 1 >= 0 && Position.Y - 2 >= 0)
            yield return new Move(ParentBoard[Position.X - 1, Position.Y - 2], Position);
        if(Position.X + 1 <= 7 && Position.Y - 2 >= 0)
            yield return new Move(ParentBoard[Position.X + 1, Position.Y - 2], Position);
        if(Position.X + 2 <= 7 && Position.Y - 1 >= 0)
            yield return new Move(ParentBoard[Position.X + 2, Position.Y - 1], Position);
        if(Position.X + 2 <= 7 && Position.Y + 1 <= 7)
            yield return new Move(ParentBoard[Position.X + 2, Position.Y + 1], Position);
        if(Position.X + 1 <= 7 && Position.Y + 2 <= 7)
            yield return new Move(ParentBoard[Position.X + 1, Position.Y + 2], Position);
        if(Position.X - 1 >= 0 && Position.Y + 2 <= 7)
            yield return new Move(ParentBoard[Position.X - 1, Position.Y + 2], Position);
        if(Position.X - 2 >= 0 && Position.Y + 1 <= 7)
            yield return new Move(ParentBoard[Position.X - 2, Position.Y + 1], Position);
        if(Position.X - 2 >= 0 && Position.Y - 1 >= 0)
            yield return new Move(ParentBoard[Position.X - 2, Position.Y - 1], Position);
    }
}