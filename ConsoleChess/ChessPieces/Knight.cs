namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="IChessPiece"/>
public class Knight : IChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Knight"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Knight(Color color)
    {
        this.Color = color;
    }

    /// <inheritdoc/>
    public Color Color
    {
        get;
    }

    /// <inheritdoc/>
    public char ToChar() => 'N';
}