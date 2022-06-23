namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <summary>
/// Represents single chess piece.
/// </summary>
public abstract class ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChessPiece"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public ChessPiece(Color color)
    {
        this.Color = color;
    }

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
    public abstract char ToChar();
}