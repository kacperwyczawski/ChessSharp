using System.Drawing;

namespace ChessCs.Core.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class King : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="King"/> class.
    /// </summary>
    /// <inheritdoc/>
    public King(Color color, Cell position, ChessBoard parentBoard)
        : base(color, position, parentBoard)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'K';

    public override IEnumerable<Move> GetValidMoves()
    {
        // North
        if (Position.Y - 1 >= 0)
        {
            yield return new Move(
                ParentBoard[Position.X, Position.Y - 1],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // North-East
        if (Position.X + 1 < 8 && Position.Y - 1 >= 0)
        {
            yield return new Move(
                ParentBoard[Position.X + 1, Position.Y - 1],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // East
        if (Position.X + 1 < 8)
        {
            yield return new Move(
                ParentBoard[Position.X + 1, Position.Y],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // South-East
        if (Position.X + 1 < 8 && Position.Y + 1 < 8)
        {
            yield return new Move(
                ParentBoard[Position.X + 1, Position.Y + 1],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // South
        if (Position.Y + 1 < 8)
        {
            yield return new Move(
                ParentBoard[Position.X, Position.Y + 1],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // South-West
        if (Position.X - 1 >= 0 && Position.Y + 1 < 8)
        {
            yield return new Move(
                ParentBoard[Position.X - 1, Position.Y + 1],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // West
        if (Position.X - 1 >= 0)
        {
            yield return new Move(
                ParentBoard[Position.X - 1, Position.Y],
                ParentBoard[Position.X, Position.Y]);
        }
        
        // North-West
        if (Position.X - 1 >= 0 && Position.Y - 1 >= 0)
        {
            yield return new Move(
                ParentBoard[Position.X - 1, Position.Y - 1],
                ParentBoard[Position.X, Position.Y]);
        }
    }
}