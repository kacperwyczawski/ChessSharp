namespace ConsoleChess;

using ChessPieces;

/// <summary>
/// Represents chess board.
/// </summary>
public partial class ChessBoard
{
    private ChessPiece?[,] chessPiecesArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class.
    /// </summary>
    /// <param name="initializeEmpty">
    /// Describe if <see cref="ChessBoard"/> would be initialized empty.
    /// </param>
    public ChessBoard(bool initializeEmpty = false)
    {
        this.chessPiecesArray = initializeEmpty ? EmptyChessPiecesArray : StartingChessPiecesArray;
    }

    /// <summary>
    /// Gets specified chess piece from given index or sets specified chess piece on given index.
    /// </summary>
    /// <param name="i">i index.</param>
    /// <param name="j">j index.</param>
    /// <returns>
    /// <see cref="ChessPiece"/> on given index.
    /// </returns>
    public ChessPiece? this[int i, int j]
    {
        get => this.chessPiecesArray[i, j];
        set => this.chessPiecesArray[i, j] = value;
    }

    public void Move((int x, int y) from, (int x, int y) to)
    {
        ChessPiece? pickedItem = this[from.x, from.y];
        this[from.x, from.y] = null;
        this[to.x, to.y] = pickedItem;
    }

    /// <summary>
    /// Converts <see cref="ChessBoard"/> to an array of <see cref="char"/> representing chess pieces.
    /// </summary>
    /// <returns>An array of <see cref="char"/> representing chess pieces.</returns>
    public char?[,] ToCharArray()
    {
        var charArray = new char?[8, 8];

        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                charArray[i, j] = this.chessPiecesArray[i, j]?.ToChar();
            }
        }

        return charArray;
    }

    /// <summary>
    /// Converts <see cref="ChessBoard"/> to an array of <see cref="ChessPiece"/>.
    /// </summary>
    /// <returns>An array of <see cref="ChessPiece"/>.</returns>
    public ChessPiece?[,] ToArray() => this.chessPiecesArray;
}