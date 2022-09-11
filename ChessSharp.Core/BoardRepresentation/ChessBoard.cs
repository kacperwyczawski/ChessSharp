using ChessSharp.Core.BoardRepresentation.ChessPieces;

namespace ChessSharp.Core.BoardRepresentation;

/// <summary>
/// Represents chess board.
/// </summary>
public class ChessBoard
{
    /// <summary>
    /// Represents cells on board. Should be modified only by ChessBoard's indexer.
    /// </summary>
    private readonly Cell[,] _boardArray = new Cell[8, 8];
    
    // TODO: Add stack, queue or something to log moves.

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class.
    /// </summary>
    public ChessBoard(Player firstPlayer, Player secondPlayer, bool initializeEmpty = false)
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                this[i, j] = new Cell(i, j, this);
            }
        }

        if (initializeEmpty)
            return;

        #region Initialize First Player's Pieces
        
        this[0, 6].Piece = new Pawn(this[0, 6], this, firstPlayer);
        this[1, 6].Piece = new Pawn(this[1, 6], this, firstPlayer);
        this[2, 6].Piece = new Pawn(this[2, 6], this, firstPlayer);
        this[3, 6].Piece = new Pawn(this[3, 6], this, firstPlayer);
        this[4, 6].Piece = new Pawn(this[4, 6], this, firstPlayer);
        this[5, 6].Piece = new Pawn(this[5, 6], this, firstPlayer);
        this[6, 6].Piece = new Pawn(this[6, 6], this, firstPlayer);
        this[7, 6].Piece = new Pawn(this[7, 6], this, firstPlayer);
        
        this[0, 7].Piece = new Rook(this[0, 7], this, firstPlayer);
        this[1, 7].Piece = new Knight(this[1, 7], this, firstPlayer);
        this[2, 7].Piece = new Bishop(this[2, 7], this, firstPlayer);
        this[3, 7].Piece = new Queen(this[3, 7], this, firstPlayer);
        this[4, 7].Piece = new King(this[4, 7], this, firstPlayer);
        this[5, 7].Piece = new Bishop(this[5, 7], this, firstPlayer);
        this[6, 7].Piece = new Knight(this[6, 7], this, firstPlayer);
        this[7, 7].Piece = new Rook(this[7, 7], this, firstPlayer);
        
        
        #endregion
        
        #region Initialize Second Player's Pieces
        
        this[0, 1].Piece = new Pawn(this[0, 1], this, secondPlayer);
        this[1, 1].Piece = new Pawn(this[1, 1], this, secondPlayer);
        this[2, 1].Piece = new Pawn(this[2, 1], this, secondPlayer);
        this[3, 1].Piece = new Pawn(this[3, 1], this, secondPlayer);
        this[4, 1].Piece = new Pawn(this[4, 1], this, secondPlayer);
        this[5, 1].Piece = new Pawn(this[5, 1], this, secondPlayer);
        this[6, 1].Piece = new Pawn(this[6, 1], this, secondPlayer);
        this[7, 1].Piece = new Pawn(this[7, 1], this, secondPlayer);
        
        this[0, 0].Piece = new Rook(this[0, 0], this, secondPlayer);
        this[1, 0].Piece = new Knight(this[1, 0], this, secondPlayer);
        this[2, 0].Piece = new Bishop(this[2, 0], this, secondPlayer);
        this[3, 0].Piece = new Queen(this[3, 0], this, secondPlayer);
        this[4, 0].Piece = new King(this[4, 0], this, secondPlayer);
        this[5, 0].Piece = new Bishop(this[5, 0], this, secondPlayer);
        this[6, 0].Piece = new Knight(this[6, 0], this, secondPlayer);
        this[7, 0].Piece = new Rook(this[7, 0], this, secondPlayer);

        #endregion
    }

    /// <summary>
    /// Gets specified chess piece from given coordinates or sets specified chess piece on given coordinates.
    /// This indexer uses Cartesian coordinates instead of array indexes.
    /// </summary>
    /// <example>
    /// Here is the example how chess board is indexed:
    ///     <code>
    ///     [0,0] [1,0] [2,0] [3,0]
    ///     [0,1] [1,1] [2,1] [3,1]
    ///     [0,2] [1,2] [2,2] [3,2]
    ///     [0,3] [1,3] [2,3] [3,3]
    ///     </code>
    /// Here is the example how regular array is indexed:
    ///     <code>
    ///     [0,0] [0,1] [0,2] [0,3]
    ///     [1,0] [1,1] [1,2] [1,3]
    ///     [2,0] [2,1] [2,2] [2,3]
    ///     [3,0] [3,1] [3,2] [3,3]
    ///     </code>
    /// </example>
    /// <param name="x">x coordinate.</param>
    /// <param name="y">y coordinate.</param>
    /// <returns>
    /// <see cref="ChessPiece"/> on given coordinates.
    /// </returns>
    public Cell this[int x, int y]
    {
        get => _boardArray[y, x];
        private init => _boardArray[y, x] = value;
    }
    // TODO add indexer that uses char and int for coordinates.
    // TODO implementation should use char to int conversion and old indexer.
    
    public IEnumerable<ChessPiece> GetAllChessPieces()
    {
        return
            from Cell cell in _boardArray
            where cell.IsOccupied
            select cell.Piece!;
    }

    public void ClearBoard()
    {
        foreach (var cell in _boardArray)
            cell.RemovePiece();
    }
}