using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Bishop : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Bishop"/> class.
    /// </summary>
    /// <inheritdoc/>
    public Bishop(Color color, Cell position, ChessBoard parentBoard) 
        : base(color, position, parentBoard)
    {
    }
    
    /// <inheritdoc/>
    public override char ToChar() => 'B';

    public override IEnumerable<Cell> GetValidMoves()
    {
        // North-West direction
        for (int x = Position.X - 1, y = Position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;

            yield return ParentBoard[x, y];
        }
        
        // North-East direction
        for (int x = Position.X + 1, y = Position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;

            yield return ParentBoard[x, y];
        }
        
        // South-West direction
        for (int x = Position.X - 1, y = Position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;

            yield return ParentBoard[x, y];
        }
        
        // South-East direction
        for (int x = Position.X + 1, y = Position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            if (ParentBoard[x, y].IsOccupied)
                break;

            yield return ParentBoard[x, y];
        }
    }
}