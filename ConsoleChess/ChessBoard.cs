namespace ConsoleChess;

using ChessPieces;

/// <summary>
/// Represents chess board.
/// </summary>
public partial class ChessBoard
{
    private ChessPiece?[,] _chessPiecesArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class.
    /// </summary>
    /// <param name="initializeEmpty">
    /// Describe if <see cref="ChessBoard"/> would be initialized empty.
    /// </param>
    public ChessBoard(bool initializeEmpty = false)
    {
        _chessPiecesArray = initializeEmpty ? EmptyChessPiecesArray : StartingChessPiecesArray;
    }

    /// <summary>
    /// Gets specified chess piece from given index or sets specified chess piece on given index.
    /// Left upper corner == [0, 0].
    /// </summary>
    /// <param name="x">i index.</param>
    /// <param name="y">j index.</param>
    /// <returns>
    /// <see cref="ChessPiece"/> on given index.
    /// </returns>
    public ChessPiece? this[int x, int y]
    {
        get => _chessPiecesArray[x, y];
        set => _chessPiecesArray[x, y] = value;
    }

    public void MovePiece((int x, int y) from, (int x, int y) to)
    {
        // if move is to the same position, do nothing
        if (from == to)
            return;

        // check if parameters are outside array, if so, throw exception
        if (from.x > 7 || from.y > 7 || from.x < 0 || from.y < 0)
            throw new ArgumentOutOfRangeException(nameof(from));
        if (to.x > 7 || to.y > 7 || to.x < 0 || to.y < 0)
            throw new ArgumentOutOfRangeException(nameof(to));

        var currentPiece = _chessPiecesArray[from.x, from.y];

        // check if piece to move does not exist
        if (currentPiece is null)
            throw new Exception("Starting index must contain chess piece.");

        // check if move is invalid
        if (currentPiece.ValidateMove(from, to, this) == false)
            throw new Exception("Invalid move");

        // finally move piece
        _chessPiecesArray[to.x, to.y] = currentPiece;
        _chessPiecesArray[from.x, from.y] = null;
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
                var piece = _chessPiecesArray[i, j];
                if (piece is null)
                    charArray[i, j] = ' ';
                else
                    charArray[i, j] = piece.ToChar();
            }
        }

        return charArray;
    }

    /// <summary>
    /// Converts <see cref="ChessBoard"/> to an array of <see cref="ChessPiece"/>.
    /// </summary>
    /// <returns>An array of <see cref="ChessPiece"/>.</returns>
    public ChessPiece?[,] ToArray() => _chessPiecesArray;
}