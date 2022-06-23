namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="IChessPiece"/>
public class Rook : IChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rook"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Rook(Color color)
    {
        this.Color = color;
    }

    /// <inheritdoc/>
    public Color Color
    {
        get;
    }

    /// <inheritdoc/>
    public char ToChar() => 'R';
}
