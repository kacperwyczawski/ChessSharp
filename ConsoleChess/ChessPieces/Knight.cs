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

    public override IEnumerable<Cell> GetValidMoves()
    {
        List<Cell> validCells = new();

        if(Position.X - 1 >= 0 && Position.Y - 2 >= 0)
            validCells.Add(ParentBoard[Position.X - 1, Position.Y - 2]);
        if(Position.X + 1 <= 7 && Position.Y - 2 >= 0)
            validCells.Add(ParentBoard[Position.X + 1, Position.Y - 2]);
        if(Position.X + 2 <= 7 && Position.Y - 1 >= 0)
            validCells.Add(ParentBoard[Position.X + 2, Position.Y - 1]);
        if(Position.X + 2 <= 7 && Position.Y + 1 <= 7)
            validCells.Add(ParentBoard[Position.X + 2, Position.Y + 1]);
        if(Position.X + 1 <= 7 && Position.Y + 2 <= 7)
            validCells.Add(ParentBoard[Position.X + 1, Position.Y + 2]);
        if(Position.X - 1 >= 0 && Position.Y + 2 <= 7)
            validCells.Add(ParentBoard[Position.X - 1, Position.Y + 2]);
        if(Position.X - 2 >= 0 && Position.Y + 1 <= 7)
            validCells.Add(ParentBoard[Position.X - 2, Position.Y + 1]);
        if(Position.X - 2 >= 0 && Position.Y - 1 >= 0)
            validCells.Add(ParentBoard[Position.X - 2, Position.Y - 1]);

        return validCells.Where(cell => !cell.IsOccupied);
    }
}