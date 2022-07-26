using System.Drawing;

namespace ConsoleChess;

using ChessPieces;

/// <summary>
/// Represents chess board.
/// </summary>
public class ChessBoard
{
    private readonly Cell[,] _boardArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class.
    /// </summary>
    public ChessBoard()
    {
        _boardArray = new Cell[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _boardArray[i, j] = new Cell(i, j);
            }
        }

        #region Initialize White Pieces
        this[0, 6].Piece = new Pawn(Color.White);
        this[1, 6].Piece = new Pawn(Color.White);
        this[2, 6].Piece = new Pawn(Color.White);
        this[3, 6].Piece = new Pawn(Color.White);
        this[4, 6].Piece = new Pawn(Color.White);
        this[5, 6].Piece = new Pawn(Color.White);
        this[6, 6].Piece = new Pawn(Color.White);
        this[7, 6].Piece = new Pawn(Color.White);
        
        this[0, 7].Piece = new Rook(Color.White);
        this[1, 7].Piece = new Knight(Color.White);
        this[2, 7].Piece = new Bishop(Color.White);
        this[3, 7].Piece = new Queen(Color.White);
        this[4, 7].Piece = new King(Color.White);
        this[5, 7].Piece = new Bishop(Color.White);
        this[6, 7].Piece = new Knight(Color.White);
        this[7, 7].Piece = new Rook(Color.White);
        #endregion
        
        #region Initialize Black Pieces
        this[0, 1].Piece = new Pawn(Color.Black);
        this[1, 1].Piece = new Pawn(Color.Black);
        this[2, 1].Piece = new Pawn(Color.Black);
        this[3, 1].Piece = new Pawn(Color.Black);
        this[4, 1].Piece = new Pawn(Color.Black);
        this[5, 1].Piece = new Pawn(Color.Black);
        this[6, 1].Piece = new Pawn(Color.Black);
        this[7, 1].Piece = new Pawn(Color.Black);
        
        this[0, 0].Piece = new Rook(Color.Black);
        this[1, 0].Piece = new Knight(Color.Black);
        this[2, 0].Piece = new Bishop(Color.Black);
        this[3, 0].Piece = new Queen(Color.Black);
        this[4, 0].Piece = new King(Color.Black);
        this[5, 0].Piece = new Bishop(Color.Black);
        this[6, 0].Piece = new Knight(Color.Black);
        this[7, 0].Piece = new Rook(Color.Black);
        #endregion
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
    public Cell this[int x, int y]
    {
        get => _boardArray[x, y];
        set => _boardArray[x, y] = value;
    }

    public void MovePiece(Cell from, Cell to)
    {
        // if move is to the same position, do nothing
        if (ReferenceEquals(from, to))
            return;

        var currentPiece = from.Piece;

        // check if piece to move does not exist
        if (currentPiece is null)
            throw new Exception("There is no piece on given position.");

        // check if move is invalid
        if (currentPiece.GetValidMoves(from, this).Contains(to))
        {
            // move piece
            to.Piece = currentPiece;
            from.Piece = null;
        }
        else
        {
            throw new Exception("Invalid move");
        }
    }

    #region Convertion Methods
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
                if (this[i, j].Piece is { } piece)
                    charArray[i, j] = piece.ToChar();
                else
                    charArray[i, j] = ' ';
            }
        }

        return charArray;
    }

    /// <summary>
    /// Converts <see cref="ChessBoard"/> to an array of <see cref="ChessPiece"/>.
    /// </summary>
    /// <returns>An array of <see cref="ChessPiece"/>.</returns>
    public ChessPiece?[,] ToChessPiecesArray()
    {
        var chessPieceArray = new ChessPiece?[8, 8];

        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                chessPieceArray[i, j] = this[i, j].Piece;
            }
        }

        return chessPieceArray;
    }
    #endregion
}