using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <summary>
/// Represents single chess piece.
/// </summary>
public abstract class ChessPiece
{
    private bool Equals(ChessPiece other)
    {
        return Color.Equals(other.Color);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((ChessPiece)obj);
    }

    public override int GetHashCode()
    {
        return Color.GetHashCode();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessPiece"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    /// <param name="position">
    /// Cell on which chess piece is placed.
    /// </param>
    /// <param name="parentBoard">
    /// Board on which chess piece is located.
    /// </param>
    public ChessPiece(Color color, Cell position, ChessBoard parentBoard)
    {
        Color = color;
        Position = position;
        ParentBoard = parentBoard;
    }

    /// <summary>
    /// Gets color of chess piece.
    /// </summary>
    public Color Color { get; }
    
    
    /// <summary>
    /// Gets or sets cell on which chess piece is located.
    /// </summary>
    public Cell Position { get; set; }
    
    
    /// <summary>
    /// Gets board on which chess piece is located.
    /// </summary>
    public ChessBoard ParentBoard { get; }

    /// <summary>
    /// Converts chess piece to it's <see cref="char"/> representation.
    /// </summary>
    /// <returns>
    /// The <see cref="char"/> representation of object.
    /// </returns>
    public abstract char ToChar();
    
    public abstract IEnumerable<Cell> GetValidMoves ();
}