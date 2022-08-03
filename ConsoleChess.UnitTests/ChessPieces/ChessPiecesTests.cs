using System.Collections;
using System.Drawing;

using ConsoleChess.ChessPieces;

namespace ConsoleChess.UnitTests.ChessPieces;

public class ChessPiecesTests
{
    private static readonly ChessBoard Board = new();

    [TestCaseSource(nameof(GetValidMovesTestCases))]
    public void GetValidMoves(Cell position, ChessPiece piece, 
        IEnumerable<Cell> expectedValidMoves, Cell[] obstacleCells)
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                Board[i, j].Piece = null;
            }
        }

        foreach (var cell in obstacleCells)
            cell.Piece = new Pawn(Color.White);

        Assert.That(piece.GetValidMoves(position, Board), Is.EquivalentTo(expectedValidMoves));
    }

    private static IEnumerable GetValidMovesTestCases
    {
        get
        {
            #region Pawn
            
            // White 4, 4
            yield return new TestCaseData
            (
                Board[4, 4],
                new Pawn(Color.White),
                new List<Cell> { Board[4, 3] },
                Array.Empty<Cell>()
            ).SetName("{m} White pawn 4, 4");
    
            // White 4, 4 with obstacle in 4, 3
            yield return new TestCaseData
            (
                Board[4, 4],
                new Pawn(Color.White),
                new List<Cell>(),
                new[] { Board[4, 3] }
            ).SetName("{m} White pawn 4, 4 with obstacle in 4, 3");
            
            // White 4, 6
            yield return new TestCaseData
            (
                Board[4, 6],
                new Pawn(Color.White),
                new List<Cell> { Board[4, 5], Board[4, 4] },
                Array.Empty<Cell>()
            ).SetName("{m} White pawn 4, 6");
            
            // White 4, 6 with obstacle in 4, 5
            yield return new TestCaseData
            (
                Board[4, 6],
                new Pawn(Color.White),
                new List<Cell>(),
                new[] { Board[4, 5] }
            ).SetName("{m} White pawn 4, 6 with obstacle in 4, 5");
            
            // White 4, 6 with obstacle in 4, 4
            yield return new TestCaseData
            (
                Board[4, 6],
                new Pawn(Color.White),
                new List<Cell> { Board[4, 5] },
                new[] { Board[4, 4] }
            ).SetName("{m} White pawn 4, 6 with obstacle in 4, 4");
            
            // White 0, 0
            yield return new TestCaseData
            (
                Board[0, 0],
                new Pawn(Color.White),
                new List<Cell>(),
                Array.Empty<Cell>()
            ).SetName("{m} White pawn 0, 0");
            
            // Black 4, 4
            yield return new TestCaseData
            (
                Board[4, 4],
                new Pawn(Color.Black),
                new List<Cell> { Board[4, 5] },
                Array.Empty<Cell>()
            ).SetName("{m} Black pawn 4, 4");
            
            // Black 4, 4 with obstacle in 4, 5
            yield return new TestCaseData
            (
                Board[4, 4],
                new Pawn(Color.Black),
                new List<Cell>(),
                new[] { Board[4, 5] }
            ).SetName("{m} Black pawn 4, 4 with obstacle in 4, 5");
            
            // Black 4, 1
            yield return new TestCaseData
            (
                Board[4, 1],
                new Pawn(Color.Black),
                new List<Cell> { Board[4, 2], Board[4, 3] },
                Array.Empty<Cell>()
            ).SetName("{m} Black pawn 4, 1");
            
            // Black 4, 1 with obstacle in 4, 2
            yield return new TestCaseData
            (
                Board[4, 1],
                new Pawn(Color.Black),
                new List<Cell>(),
                new[] { Board[4, 2] }
            ).SetName("{m} Black pawn 4, 1 with obstacle in 4, 2");
            
            // Black 4, 1 with obstacle in 4, 3
            yield return new TestCaseData
            (
                Board[4, 1],
                new Pawn(Color.Black),
                new List<Cell> { Board[4, 2] },
                new[] { Board[4, 3] }
            ).SetName("{m} Black pawn 4, 1 with obstacle in 4, 3");
            
            // Black 0, 7
            yield return new TestCaseData
            (
                Board[0, 7],
                new Pawn(Color.Black),
                new List<Cell>(),
                Array.Empty<Cell>()
            ).SetName("{m} Black pawn 0, 7");
            
            #endregion

            #region Knight
    
            // White 2, 2 with obstacle in: 4, 1; 2, 1; 1, 1
            yield return new TestCaseData
            (
                Board[2, 2],
                new Knight(Color.White),
                new List<Cell>
                {
                    Board[1, 0], Board[3, 0],
                    Board[4, 3],
                    Board[3, 4], Board[1, 4],
                    Board[0, 3], Board[0, 1]
                },
                new[]
                {
                    Board[4, 1],
                    Board[2, 1],
                    Board[1, 1]
                }
            ).SetName("{m} White knight 2, 2 with obstacle in: 4, 1; 2, 1; 1, 1");
            
            // Black 0, 0
            yield return new TestCaseData
            (
                Board[0, 0],
                new Knight(Color.Black),
                new List<Cell> { Board[2, 1], Board[1, 2] },
                Array.Empty<Cell>()
            ).SetName("{m} Black knight 0, 0");

            #endregion

            #region Bishop
            
            // White 3, 2 with obstacle in 4, 1 and 3, 1
            yield return new TestCaseData
            (
                Board[3, 2],
                new Bishop(Color.White),
                new List<Cell>
                {
                    // North-west
                    Board[2, 1], Board[1, 0],
                    // South-east
                    Board[4, 3], Board[5, 4], Board[6, 5], Board[7, 6],
                    // South-west
                    Board[2, 3], Board[1, 4], Board[0, 5]
                },
                new[]
                {
                    Board[4, 1],
                    Board[3, 1]
                }
            ).SetName("{m} White bishop 3, 2 with obstacle in 4, 1 and 3, 1");

            #endregion

            #region Rook

            // White 3, 4 with obstacle in 5, 4
            yield return new TestCaseData
            (
                Board[3, 4],
                new Rook(Color.White),
                new List<Cell>
                {
                    // North
                    Board[3, 3], Board[3, 2], Board[3, 1], Board[3, 0],
                    // East
                    Board[4, 4],
                    // South
                    Board[3, 5], Board[3, 6], Board[3, 7],
                    // West
                    Board[2, 4], Board[1, 4], Board[0, 4]
                },
                new[]
                {
                    Board[5, 4]
                }
            ).SetName("{m} White rook 3, 4 with obstacle in 5, 4");

            #endregion
        }
    }
}