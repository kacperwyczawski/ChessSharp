using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Queen : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Queen"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Queen(Color color, Cell position, ChessBoard parentBoard)
        : base(color, position, parentBoard)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'Q';

    public override IEnumerable<Cell> GetValidMoves()
    {
        // Combined mechanics of rook and bishop
        
        // North direction
        // y is decrementing, x is constant
        for (var y = Position.Y - 1; y >= 0; y--)
        {
            if (ParentBoard[Position.X, y].IsOccupied)
                break;
            yield return ParentBoard[Position.X, y];
        }
        
        // North-East direction
        // x is incrementing, y is decrementing
        for (int x = Position.X + 1, y = Position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;
            yield return ParentBoard[x, y];
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var x = Position.X + 1; x <= 7; x++)
        {
            if (ParentBoard[x, Position.Y].IsOccupied)
                break;
            yield return ParentBoard[x, Position.Y];
        }
        
        // South-East direction
        // x is incrementing, y is incrementing
        for (int x = Position.X + 1, y = Position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;
            yield return ParentBoard[x, y];
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var y = Position.Y + 1; y <= 7; y++)
        {
            if (ParentBoard[Position.X, y].IsOccupied)
                break;
            yield return ParentBoard[Position.X, y];
        }
        
        // South-West direction
        // x is decrementing, y is incrementing
        for (int x = Position.X - 1, y = Position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;
            yield return ParentBoard[x, y];
        }
        
        // West direction
        // x is decrementing, y is constant
        for (var x = Position.X - 1; x >= 0; x--)
        {
            if (ParentBoard[x, Position.Y].IsOccupied)
                break;
            yield return ParentBoard[x, Position.Y];
        }
        
        // North-West direction
        // x is decrementing, y is decrementing
        for (int x = Position.X - 1, y = Position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;
            yield return ParentBoard[x, y];
        }
    }
}