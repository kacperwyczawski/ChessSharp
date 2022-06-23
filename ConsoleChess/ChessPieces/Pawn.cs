namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="IChessPiece"/>
public class Pawn : IChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Pawn"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Pawn(Color color)
    {
        this.Color = color;
    }

    /// <inheritdoc/>
    public Color Color
    {
        get;
    }

    /// <inheritdoc/>
    public char ToChar() => 'P';
}