using System.Drawing;
using ConsoleChess.ChessPieces;

namespace ConsoleChess.UnitTests.ChessPieces;

public class BishopTests
{
    private static readonly ChessBoard Board = new();

    private static object[] _validateMoveCases =
    {
        #region bishop
        
        // 6, 2 to 1, 7
        new object?[] {new Bishop(Color.White), Board[6, 2], Board[1, 7], true, null},
        // 3, 3 to 4, 4
        new object?[] {new Bishop(Color.White), Board[3, 3], Board[4, 4], true, null},
        // 3, 3 to 6, 6
        new object?[] {new Bishop(Color.White), Board[3, 3], Board[6, 6], true, null},
        // 1, 1 to 0, 0
        new object?[] {new Bishop(Color.White), Board[1, 1], Board[0, 0], true, null},
        // 0, 5 to 3, 2 with obstacle in destination
        new object?[] {new Bishop(Color.White), Board[0, 5], Board[3, 2], false, Board[3, 2]},
        // 0, 5 to 3, 2 with obstacle in the way
        new object?[] {new Bishop(Color.White), Board[0, 5], Board[3, 2], false, Board[2, 3]},
        // 1, 3 to 6, 3
        new object?[] {new Bishop(Color.White), Board[1, 3], Board[6, 3], false, null},
        // 1, 3 to 6, 2
        new object?[] {new Bishop(Color.White), Board[1, 3], Board[6, 2], false, null},
        
        #endregion
        
        #region king
        
        // 4, 5 to 3, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[3, 4], true, null},
        // 4, 5 to 4, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[4, 4], true, null},
        // 4, 5 to 5, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 4], true, null},
        // 4, 5 to 5, 5
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 5], true, null},
        // 4, 5 to 5, 6
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 6], true, null},
        // 4, 5 to 4, 6
        new object?[] {new King(Color.White), Board[4, 5], Board[4, 6], true, null},
        // 4, 5 to 3, 6
        new object?[] {new King(Color.White), Board[4, 5], Board[3, 6], true, null},
        // 4, 5 to 3, 5
        new object?[] {new King(Color.White), Board[4, 5], Board[3, 5], true, null},
        // 4, 5 to 4, 4 with obstacle in destination
        new object?[] {new King(Color.White), Board[4, 5], Board[4, 4], false, Board[4, 4]},
        // 4, 5 to 5, 6 with non-colliding piece in 4, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 6], true, Board[4, 4]},
        // 4, 5 to 6, 5
        new object?[] {new King(Color.White), Board[4, 5], Board[6, 5], false, null},
        // 4, 5 to 6, 3
        new object?[] {new King(Color.White), Board[4, 5], Board[6, 3], false, null},
        
        #endregion

        #region Knight

        // 5, 2 to 3, 1
        new object?[] {new Knight(Color.White), Board[5, 2], Board[3, 1], true, null},
        // 5, 2 to 4, 0
        new object?[] {new Knight(Color.White), Board[5, 2], Board[4, 0], true, null},
        // 5, 2 to 6, 0
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 0], true, null},
        // 5, 2 to 7, 1
        new object?[] {new Knight(Color.White), Board[5, 2], Board[7, 1], true, null},
        // 5, 2 to 7, 3
        new object?[] {new Knight(Color.White), Board[5, 2], Board[7, 3], true, null},
        // 5, 2 to 6, 4
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 4], true, null},
        // 5, 2 to 4, 4
        new object?[] {new Knight(Color.White), Board[5, 2], Board[4, 4], true, null},
        // 5, 2 to 3, 3
        new object?[] {new Knight(Color.White), Board[5, 2], Board[3, 3], true, null},
        // 5, 2 to 6, 0 with obstacle in destination
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 0], false, Board[6, 0]},
        // 5, 2 to 6, 0 with non-colliding piece in 5, 1
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 0], true, Board[5, 1]},
        // 5, 2 to 6, 0 with non-colliding piece in 5, 0
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 0], true, Board[5, 0]},
        // 5, 2 to 6, 0 with non-colliding piece in 6, 1
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 0], true, Board[6, 1]},
        // 5, 2 to 6, 0 with non-colliding piece in 6, 2
        new object?[] {new Knight(Color.White), Board[5, 2], Board[6, 0], true, Board[6, 2]},
        // 5, 2 to 5, 0
        new object?[] {new Knight(Color.White), Board[5, 2], Board[5, 0], false, null},
        // 5, 2 to 5, 1
        new object?[] {new Knight(Color.White), Board[5, 2], Board[5, 1], false, null},

        #endregion
        
        #region Pawn
        
        // 2, 4 to 2, 3 white
        new object?[] {new Pawn(Color.White), Board[2, 4], Board[2, 3], true, null},
        // 2, 4 to 3, 3 white
        new object?[] {new Pawn(Color.White), Board[2, 4], Board[3, 3], false, null},
        // 2, 4 to 2, 5 white
        new object?[] {new Pawn(Color.White), Board[2, 4], Board[2, 5], false, null},
        // 2, 4 to 2, 2 white
        new object?[] {new Pawn(Color.White), Board[2, 4], Board[2, 2], false, null},
        // 0, 6 to 0, 4 white
        new object?[] {new Pawn(Color.White), Board[0, 6], Board[0, 4], true, null},
        // 0, 6 to 0, 5 white
        new object?[] {new Pawn(Color.White), Board[0, 6], Board[0, 5], true, null},
        // 0, 3 to 0, 1 white
        new object?[] {new Pawn(Color.White), Board[0, 3], Board[0, 1], false, null},
        
        // 7, 1 to 7, 2 black
        new object?[] {new Pawn(Color.Black), Board[7, 1], Board[7, 2], true, null},
        // 7, 1 to 7, 3 black
        new object?[] {new Pawn(Color.Black), Board[7, 1], Board[7, 3], true, null},
        // 7, 1 to 7, 0 black
        new object?[] {new Pawn(Color.Black), Board[7, 1], Board[7, 0], false, null},
        // 7, 5 to 6, 6 black
        new object?[] {new Pawn(Color.Black), Board[7, 5], Board[6, 6], false, null},
        
        #endregion
    };

    [TestCaseSource(nameof(_validateMoveCases))]
    public void ValidateMove(ChessPiece piece, Cell from, Cell to, bool expectedResult, Cell? obstacleCell = null)
    {
        for (var i = 0; i < 8; i++)
            for (var j = 0; j < 8; j++)
                Board[i, j].Piece = null;
        
        from.Piece = piece;

        if (obstacleCell is not null)
            obstacleCell.Piece = new Pawn(Color.White);

        Assert.That(from.Piece.ValidateMove(from, to, Board), Is.EqualTo(expectedResult));
    }

    private static object[] _getValidMovesCases =
    {
        #region Pawn

        // Pawn white
        // 4, 4
        new object?[] { Board[4, 4], new Pawn(Color.White), Board, new List<Cell> { Board[4, 3] }, null },
        // 4, 4 with obstacle in destination
        new object?[] { Board[4, 4], new Pawn(Color.White), Board, new List<Cell>(), Board[4, 3], },
        // 4, 6
        new object?[] { Board[4, 6], new Pawn(Color.White), Board, new List<Cell> { Board[4, 5], Board[4, 4] }, null },
        // 4, 6 with obstacle in 4, 5
        new object?[] { Board[4, 6], new Pawn(Color.White), Board, new List<Cell>(), Board[4, 5] },
        // 4, 6 with obstacle in 4, 4
        new object?[] { Board[4, 6], new Pawn(Color.White), Board, new List<Cell> { Board[4, 5] }, Board[4, 4] },
        
        // Pawn black
        // 4, 4
        new object?[] { Board[4, 4], new Pawn(Color.Black), Board, new List<Cell> { Board[4, 5] }, null },
        // 4, 4 with obstacle in destination
        new object?[] { Board[4, 4], new Pawn(Color.Black), Board, new List<Cell>(), Board[4, 5] },
        // 4, 1
        new object?[] { Board[4, 1], new Pawn(Color.Black), Board, new List<Cell> { Board[4, 2], Board[4, 3] }, null },
        // 4, 1 with obstacle in 4, 2
        new object?[] { Board[4, 1], new Pawn(Color.Black), Board, new List<Cell>(), Board[4, 2] },
        // 4, 1 with obstacle in 4, 3
        new object?[] { Board[4, 1], new Pawn(Color.Black), Board, new List<Cell> { Board[4, 2] }, Board[4, 3] },

        #endregion
    };

    [TestCaseSource(nameof(_getValidMovesCases))]
    public void GetValidMoves(Cell position, ChessPiece piece, ChessBoard board, IEnumerable<Cell> expectedValidMoves, Cell? obstacleCell = null)
    {
        for (var i = 0; i < 8; i++)
            for (var j = 0; j < 8; j++)
                Board[i, j].Piece = null;
        
        if (obstacleCell is not null)
            obstacleCell.Piece = new Pawn(Color.White);
        
        Assert.That(piece.GetValidMoves(position, board), Is.EquivalentTo(expectedValidMoves));
    }
}