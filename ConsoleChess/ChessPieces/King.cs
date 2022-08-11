using System.Drawing;

namespace ConsoleChess.ChessPieces;

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

    public override IEnumerable<Cell> GetValidMoves()
    {
        if (Position.X - 1 >= 0 && Position.Y - 1 >= 0
            && ParentBoard[Position.X - 1, Position.Y - 1].IsOccupied == false)
            yield return ParentBoard[Position.X - 1, Position.Y - 1];
        
        if (Position.X - 1 >= 0 && Position.Y + 1 < 8
            && ParentBoard[Position.X - 1, Position.Y + 1].IsOccupied == false)
            yield return ParentBoard[Position.X - 1, Position.Y + 1];
        
        if (Position.X + 1 < 8 && Position.Y - 1 >= 0
            && ParentBoard[Position.X + 1, Position.Y - 1].IsOccupied == false)
            yield return ParentBoard[Position.X + 1, Position.Y - 1];
        
        if (Position.X + 1 < 8 && Position.Y + 1 < 8
            && ParentBoard[Position.X + 1, Position.Y + 1].IsOccupied == false)
            yield return ParentBoard[Position.X + 1, Position.Y + 1];
        
        if (Position.X - 1 >= 0
            && ParentBoard[Position.X - 1, Position.Y].IsOccupied == false)
            yield return ParentBoard[Position.X - 1, Position.Y];
        
        if (Position.X + 1 < 8
            && ParentBoard[Position.X + 1, Position.Y].IsOccupied == false)
            yield return ParentBoard[Position.X + 1, Position.Y];
        
        if (Position.Y - 1 >= 0
            && ParentBoard[Position.X, Position.Y - 1].IsOccupied == false)
            yield return ParentBoard[Position.X, Position.Y - 1];
        
        if (Position.Y + 1 < 8
            && ParentBoard[Position.X, Position.Y + 1].IsOccupied == false)
            yield return ParentBoard[Position.X, Position.Y + 1];
    }
}