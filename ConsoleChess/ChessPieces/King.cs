using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class King : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="King"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public King(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'K';

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        if (position.X - 1 >= 0 && position.Y - 1 >= 0
            && board[position.X - 1, position.Y - 1].IsOccupied == false)
            yield return board[position.X - 1, position.Y - 1];
        
        if (position.X - 1 >= 0 && position.Y + 1 < 8
            && board[position.X - 1, position.Y + 1].IsOccupied == false)
            yield return board[position.X - 1, position.Y + 1];
        
        if (position.X + 1 < 8 && position.Y - 1 >= 0
            && board[position.X + 1, position.Y - 1].IsOccupied == false)
            yield return board[position.X + 1, position.Y - 1];
        
        if (position.X + 1 < 8 && position.Y + 1 < 8
            && board[position.X + 1, position.Y + 1].IsOccupied == false)
            yield return board[position.X + 1, position.Y + 1];
        
        if (position.X - 1 >= 0
            && board[position.X - 1, position.Y].IsOccupied == false)
            yield return board[position.X - 1, position.Y];
        
        if (position.X + 1 < 8
            && board[position.X + 1, position.Y].IsOccupied == false)
            yield return board[position.X + 1, position.Y];
        
        if (position.Y - 1 >= 0
            && board[position.X, position.Y - 1].IsOccupied == false)
            yield return board[position.X, position.Y - 1];
        
        if (position.Y + 1 < 8
            && board[position.X, position.Y + 1].IsOccupied == false)
            yield return board[position.X, position.Y + 1];
    }
}