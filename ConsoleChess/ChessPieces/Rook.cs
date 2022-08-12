using System.Drawing;

namespace ConsoleChess.ChessPieces;

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
            if (ParentBoard[currentX, Position.Y].IsOccupied)
            {
                yield return new Move(
                    ParentBoard[currentX, Position.Y],
                    Position,
                    ParentBoard[currentX, Position.Y]);
                break;
            }
            yield return new Move(
                ParentBoard[currentX, Position.Y],
                Position,
                null);
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var currentX = Position.X + 1; currentX < 8; currentX++)
        {
            if (ParentBoard[currentX, Position.Y].IsOccupied)
            {
                yield return new Move(
                    ParentBoard[currentX, Position.Y],
                    Position,
                    ParentBoard[currentX, Position.Y]);
                break;
            }
            yield return new Move(
                ParentBoard[currentX, Position.Y],
                Position,
                null);
        }
        
        // North direction
        // y is decrementing, x is constant
        for (var currentY = Position.Y - 1; currentY >= 0; currentY--)
        {
            if (ParentBoard[Position.X, currentY].IsOccupied)
            {
                yield return new Move(
                    ParentBoard[Position.X, currentY],
                    Position,
                    ParentBoard[Position.X, currentY]);
                break;
            }
            yield return new Move(
                ParentBoard[Position.X, currentY],
                Position,
                null);
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var currentY = Position.Y + 1; currentY < 8; currentY++)
        {
            if (ParentBoard[Position.X, currentY].IsOccupied)
            {
                yield return new Move(
                    ParentBoard[Position.X, currentY],
                    Position,
                    ParentBoard[Position.X, currentY]);
                break;
            }
            yield return new Move(
                ParentBoard[Position.X, currentY],
                Position,
                null);
        }
    }
}
