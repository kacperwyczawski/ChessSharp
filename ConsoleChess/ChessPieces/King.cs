namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="IChessPiece"/>
public class King : IChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="King"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public King(Color color)
    {
        this.Color = color;
    }

    /// <inheritdoc/>
    public Color Color
    {
        get;
    }

    /// <inheritdoc/>
    public char ToChar() => 'K';
}