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

    public override IEnumerable<Cell> GetValidMoves()
    {
        // West direction
        // x is decrementing, y is constant
        for (var i = Position.X - 1; i >= 0; i--)
        {
            if (ParentBoard[i, Position.Y].IsOccupied)
                break;
            yield return ParentBoard[i, Position.Y];
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var i = Position.X + 1; i < 8; i++)
        {
            if (ParentBoard[i, Position.Y].IsOccupied)
                break;
            yield return ParentBoard[i, Position.Y];
        }
        
        // North direction
        // y is decrementing, x is constant
        for (var i = Position.Y - 1; i >= 0; i--)
        {
            if (ParentBoard[Position.X, i].IsOccupied)
                break;
            yield return ParentBoard[Position.X, i];
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var i = Position.Y + 1; i < 8; i++)
        {
            if (ParentBoard[Position.X, i].IsOccupied)
                break;
            yield return ParentBoard[Position.X, i];
        }
    }
}
