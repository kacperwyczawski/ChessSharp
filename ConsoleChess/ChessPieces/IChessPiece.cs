namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <summary>
/// Represents single chess piece.
/// </summary>
public interface IChessPiece
{
    /// <summary>
    /// Gets color of chess piece.
    /// </summary>
    public Color Color { get; }

    /// <summary>
    /// Converts chess piece to it's <see cref="char"/> representation.
    /// </summary>
    /// <returns>
    /// The <see cref="char"/> representation of object.
    /// </returns>
    public char ToChar();
}