namespace ConsoleChess.ChessPieces;

using System.Drawing;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Rook : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rook"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Rook(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'R';
}
