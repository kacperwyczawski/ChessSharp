namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="IChessPiece"/>
public class Queen : IChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Queen"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Queen(Color color)
    {
        this.Color = color;
    }

    /// <inheritdoc/>
    public Color Color
    {
        get;
    }

    /// <inheritdoc/>
    public char ToChar() => 'Q';
}