using System.Drawing;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class.
    /// </summary>
    public ChessBoard()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                this[i, j] = new Cell(i, j, this);
            }
        }

        #region Initialize White Pieces
        
        this[0, 6].Piece = new Pawn(Color.White, this[0, 6], this, AttackDirection.North);
        this[1, 6].Piece = new Pawn(Color.White, this[1, 6], this, AttackDirection.North);
        this[2, 6].Piece = new Pawn(Color.White, this[2, 6], this, AttackDirection.North);
        this[3, 6].Piece = new Pawn(Color.White, this[3, 6], this, AttackDirection.North);
        this[4, 6].Piece = new Pawn(Color.White, this[4, 6], this, AttackDirection.North);
        this[5, 6].Piece = new Pawn(Color.White, this[5, 6], this, AttackDirection.North);
        this[6, 6].Piece = new Pawn(Color.White, this[6, 6], this, AttackDirection.North);
        this[7, 6].Piece = new Pawn(Color.White, this[7, 6], this, AttackDirection.North);
        this[0, 7].CreateAndSetPiece<Rook>(Color.White);
        this[1, 7].CreateAndSetPiece<Knight>(Color.White);
        this[2, 7].CreateAndSetPiece<Bishop>(Color.White);
        this[3, 7].CreateAndSetPiece<Queen>(Color.White);
        this[4, 7].CreateAndSetPiece<King>(Color.White);
        this[5, 7].CreateAndSetPiece<Bishop>(Color.White);
        this[6, 7].CreateAndSetPiece<Knight>(Color.White);
        this[7, 7].CreateAndSetPiece<Rook>(Color.White);
        
        #endregion
        
        #region Initialize Black Pieces
        
        this[0, 1].Piece = new Pawn(Color.Black, this[0, 1], this, AttackDirection.South);
        this[1, 1].Piece = new Pawn(Color.Black, this[1, 1], this, AttackDirection.South);
        this[2, 1].Piece = new Pawn(Color.Black, this[2, 1], this, AttackDirection.South);
        this[3, 1].Piece = new Pawn(Color.Black, this[3, 1], this, AttackDirection.South);
        this[4, 1].Piece = new Pawn(Color.Black, this[4, 1], this, AttackDirection.South);
        this[5, 1].Piece = new Pawn(Color.Black, this[5, 1], this, AttackDirection.South);
        this[6, 1].Piece = new Pawn(Color.Black, this[6, 1], this, AttackDirection.South);
        this[7, 1].Piece = new Pawn(Color.Black, this[7, 1], this, AttackDirection.South);

        this[0, 0].CreateAndSetPiece<Rook>(Color.Black);
        this[1, 0].CreateAndSetPiece<Knight>(Color.Black);
        this[2, 0].CreateAndSetPiece<Bishop>(Color.Black);
        this[3, 0].CreateAndSetPiece<Queen>(Color.Black);
        this[4, 0].CreateAndSetPiece<King>(Color.Black);
        this[5, 0].CreateAndSetPiece<Bishop>(Color.Black);
        this[6, 0].CreateAndSetPiece<Knight>(Color.Black);
        this[7, 0].CreateAndSetPiece<Rook>(Color.Black);

        #endregion
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoard"/> class using string to represent board.
    /// </summary>
    /// <example>
    /// this is standard chess board example. Valid names are the same as the names of the elements of the
    /// <see cref="System.Drawing.KnownColor"/> enumeration.
    /// <c>
    /// WhiteR;WhiteN;WhiteB;WhiteQ;WhiteK;WhiteB;WhiteN;WhiteR|
    /// WhiteP;WhiteP;WhiteP;WhiteP;WhiteP;WhiteP;WhiteP;WhiteP|
    /// _;_;_;_;_;_;_;_|_;_;_;_;_;_;_;_;_|_;_;_;_;_;_;_;_|_;_;_;_;_;_;_;_;_|
    /// BlackP;BlackP;BlackP;BlackP;BlackP;BlackP;BlackP;BlackP|
    /// BlackR;BlackN;BlackB;BlackQ;BlackK;BlackB;BlackN;BlackR|
    /// </c>
    /// </example>
    public ChessBoard(string boardString)
    {
        // convert boardString to 2D array of cellStrings
        var cellStringsArray = new string[8, 8];
        var rows = boardString.Split('|');
        for (var i = 0; i < 8; i++)
        {
            var cells = rows[i].Split(';');
            for (var j = 0; j < 8; j++)
            {
                cellStringsArray[i, j] = cells[j];
            }
        }
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                // create empty cell
                this[i, j] = new Cell(i, j, this);
                
                // if cell should stay empty, continue
                if (cellStringsArray[i, j] == "_")
                    continue;
                
                // else create piece and set it to cell
                Color color;
                try
                {
                    color = Color.FromName(cellStringsArray[i, j][..^1]);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid color name");
                }
                
                // Code below breaks Open-Closed Principle :(
                switch (cellStringsArray[i, j][^1])
                {
                    case 'P':
                        throw new NotImplementedException();
                        break;
                    case 'R':
                        this[i, j].CreateAndSetPiece<Rook>(color);
                        break;
                    case 'N':
                        this[i, j].CreateAndSetPiece<Knight>(color);
                        break;
                    case 'B':
                        this[i, j].CreateAndSetPiece<Bishop>(color);
                        break;
                    case 'Q':
                        this[i, j].CreateAndSetPiece<Queen>(color);
                        break;
                    case 'K':
                        this[i, j].CreateAndSetPiece<King>(color);
                        break;
                    default:
                        throw new ArgumentException("Invalid piece name");
                }
            }
        }
        
        //TODO: cover case when boardString is to small or too big by checking if arrays after split have length 8 or _boardArray.Length or something like that
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
    public void MovePiece(ChessPiece piece, Cell to)
    {
        try
        {
            piece
                // Get valid moves for this piece
                // returns: IEnumerable<Move>
                .GetValidMoves()
                // get valid move where destination match destination passed as parameter
                // if no matching move is found, InvalidOperationException will be thrown by First method
                // returns: Move
                // -- or --
                // throws: InvalidOperationException
                .First(m => m.DestinationCell == to)
                // if exception is not thrown, execute move
                .ExecuteMove();
        }
        catch (InvalidOperationException)
        {
            throw new Exception("Invalid move.");
        }
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
                if (this[i, j].Piece is { } piece)
                    charArray[j, i] = piece.ToChar();
                else
                    charArray[j, i] = ' ';
            }
        }

        return charArray;
    }
}