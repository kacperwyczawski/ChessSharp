using System.Drawing;
using ConsoleChess.ChessPieces;

namespace ConsoleChess.UnitTests.ChessPieces;

[TestFixture]
public class BishopTests
{
    private static ChessBoard _board = ChessBoard.GetInstance();
    
    [SetUp]
    public void SetUp()
    {
        _board = ChessBoard.GetInstance();
        
        // iterate over all cells and remove all pieces
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _board[i, j].Piece = null;
            }
        }
    }

    private static object[] _validateMoveCases =
    {
        // 6, 2 to 1, 7
        new object?[] {_board[6, 2], _board[1, 7], true},
        // 3, 3 to 4, 4
        new object?[] {_board[3, 3], _board[4, 4], true},
        // 3, 3 to 6, 6
        new object?[] {_board[3, 3], _board[6, 6], true},
        // 1, 1 to 0, 0
        new object?[] {_board[1, 1], _board[0, 0], true},
        
        // 0, 5 to 3, 2 with obstacle in destination
        new object?[] {_board[0, 5], _board[3, 2], false, _board[3, 2]},
        // 0, 5 to 3, 2 with obstacle in the way
        new object?[] {_board[0, 5], _board[3, 2], false, _board[2, 3]},
        
        // 1, 3 to 6, 3
        new object?[] {_board[1, 3], _board[6, 3], false},
        // 1, 3 to 6, 2
        new object?[] {_board[1, 3], _board[6, 2], false}
    };

    [TestCaseSource(nameof(_validateMoveCases))]
    public void ValidateMove(Cell from, Cell to, bool expectedResult, Cell? obstacle = null)
    {
        from.Piece = new Bishop(Color.White);

        if (obstacle is not null)
        {
            obstacle.Piece = new Pawn(Color.White);
        }
        
        Assert.That(from.Piece.ValidateMove(from, to, _board), Is.EqualTo(expectedResult));
    }
}