using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Queen : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Queen"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Queen(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'Q';

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        // Combined mechanics of rook and bishop
        
        // North direction
        // y is decrementing, x is constant
        for (var y = position.Y - 1; y >= 0; y--)
        {
            if (board[position.X, y].IsOccupied)
                break;
            yield return board[position.X, y];
        }
        
        // North-East direction
        // x is incrementing, y is decrementing
        for (int x = position.X + 1, y = position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            if (board[x, y].IsOccupied)
                break;
            yield return board[x, y];
        }
        
        // East direction
        // x is incrementing, y is constant
        for (var x = position.X + 1; x <= 7; x++)
        {
            if (board[x, position.Y].IsOccupied)
                break;
            yield return board[x, position.Y];
        }
        
        // South-East direction
        // x is incrementing, y is incrementing
        for (int x = position.X + 1, y = position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            if (board[x, y].IsOccupied)
                break;
            yield return board[x, y];
        }
        
        // South direction
        // y is incrementing, x is constant
        for (var y = position.Y + 1; y <= 7; y++)
        {
            if (board[position.X, y].IsOccupied)
                break;
            yield return board[position.X, y];
        }
        
        // South-West direction
        // x is decrementing, y is incrementing
        for (int x = position.X - 1, y = position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            if (board[x, y].IsOccupied)
                break;
            yield return board[x, y];
        }
        
        // West direction
        // x is decrementing, y is constant
        for (var x = position.X - 1; x >= 0; x--)
        {
            if (board[x, position.Y].IsOccupied)
                break;
            yield return board[x, position.Y];
        }
        
        // North-West direction
        // x is decrementing, y is decrementing
        for (int x = position.X - 1, y = position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (board[x, y].IsOccupied)
                break;
            yield return board[x, y];
        }
    }
}