// TODO: Remove this after writing new tests
// This is temporary left here for copilot


/*

using System.Collections;
using System.Drawing;
using ChessSharp.Core.BoardRepresentation;
using ChessSharp.Core.BoardRepresentation.ChessPieces;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

public class ChessPiecesTests
{
    private static readonly Player P1 = new Player("Player 1", Color.Blue, AttackDirection.North);
    private static readonly Player P2 = new Player("Player 2", Color.Red, AttackDirection.South);
    private static readonly Player P3 = new Player("Player 3", Color.Green, AttackDirection.East);
    private static readonly Player P4 = new Player("Player 4", Color.Yellow, AttackDirection.West);

    private static readonly ChessBoard StandardBoard = new ChessBoard(P1, P2, true);
    private static readonly ChessBoard RotatedBoard = new ChessBoard(P3, P4, true);

    [TestCaseSource(nameof(GetValidMovesTestCases))]
    public void GetValidMoves(ChessPiece piece, IEnumerable<Move> expectedValidMoves) =>
        Assert.That(piece.GetValidMoves(), Is.EquivalentTo(expectedValidMoves));

    private static IEnumerable<TestCaseData> GetValidMovesTestCases
    {
        // T__ODO: Finish this
        get
        {
            #region Pawn

            // north-attacking pawn on 4, 4
            StandardBoard.ClearBoard();
            StandardBoard.SetPieceAt(4, 4, typeof(Pawn), P1);
            Move.Board = StandardBoard;
            
            yield return new TestCaseData
            (
                StandardBoard[4, 4].Piece,
                new List<Move>
                {
                    new("4, 4 > 4, 3 n"),
                    new("4, 4 > 4, 2 n") // can move two spaces on first move
                }
            ).SetName("{m} North-Attacking Pawn on 4, 4");
            
            // T__ODO: Add more tests after implementing en passant and promotion

            #endregion

            #region Knight

            // north-attacking knight on 4, 4
            StandardBoard.ClearBoard();
            StandardBoard.SetPieceAt(4, 4, typeof(Knight), P1);
            Move.Board = StandardBoard;
            
            yield return new TestCaseData
            (
                StandardBoard[4, 4].Piece,
                new List<Move>
                {
                    new("4, 4 > 2, 3"),
                    new("4, 4 > 2, 5"),
                    new("4, 4 > 3, 2"),
                    new("4, 4 > 3, 6"),
                    new("4, 4 > 5, 2"),
                    new("4, 4 > 5, 6"),
                    new("4, 4 > 6, 3"),
                    new("4, 4 > 6, 5")
                }
            ).SetName("{m} North-Attacking Knight on 4, 4");
            
            // north-attacking knight on 0, 0 with obstacle in 2, 1 and 1, 0
            StandardBoard.ClearBoard();
            StandardBoard.SetPieceAt(0, 0, typeof(Knight), P1);
            StandardBoard.SetPieceAt(2, 1, typeof(Pawn), P2);
            StandardBoard.SetPieceAt(1, 0, typeof(Pawn), P2);
            Move.Board = StandardBoard;
            
            yield return new TestCaseData
            (
                StandardBoard[0, 0].Piece,
                new List<Move>
                {
                    new("0, 0 > 1, 2"),
                    new("0, 0 > 2, 1")
                }
            ).SetName("{m} North-Attacking Knight on 0, 0 with obstacle in 2, 1 and 1, 0");

            #endregion
        }
    }

    /*
    private static IEnumerable GetValidMovesTestCasesOLD
    {
        get
        {
            #region Pawn
            
            // White 4, 4
            yield return new TestCaseData
            (
                new Pawn(Color.White, Board[4, 4], Board, AttackDirection.North),
                new List<Cell> { Board[4, 3] },
                Array.Empty<Cell>()
            ).SetName("{m} White pawn 4, 4");
    
            // White 4, 4 with obstacle in 4, 3
            yield return new TestCaseData
            (
                new Pawn(Color.White, Board[4, 4], Board, AttackDirection.North),
                Enumerable.Empty<Cell>(),
                new[] { Board[4, 3] }
            ).SetName("{m} White pawn 4, 4 with obstacle in 4, 3");
            
            // White 4, 6
            yield return new TestCaseData
            (
                new Pawn(Color.White, Board[4, 6], Board, AttackDirection.North),
                new List<Cell> { Board[4, 5], Board[4, 4] },
                Array.Empty<Cell>()
            ).SetName("{m} White pawn 4, 6");
            
            // White 4, 6 with obstacle in 4, 5
            yield return new TestCaseData
            (
                new Pawn(Color.White, Board[4, 6], Board, AttackDirection.North),
                Enumerable.Empty<Cell>(),
                new[] { Board[4, 5] }
            ).SetName("{m} White pawn 4, 6 with obstacle in 4, 5");
            
            // White 4, 6 with obstacle in 4, 4
            yield return new TestCaseData
            (
                new Pawn(Color.White, Board[4, 6], Board, AttackDirection.North),
                new List<Cell> { Board[4, 5] },
                new[] { Board[4, 4] }
            ).SetName("{m} White pawn 4, 6 with obstacle in 4, 4");
            
            // White 0, 0
            yield return new TestCaseData
            (
                new Pawn(Color.White, Board[0, 0], Board, AttackDirection.North),
                Enumerable.Empty<Cell>(),
                Array.Empty<Cell>()
            ).SetName("{m} White pawn 0, 0");
            
            // Black 4, 4
            yield return new TestCaseData
            (
                new Pawn(Color.Black, Board[4, 4], Board, AttackDirection.South),
                new List<Cell> { Board[4, 5] },
                Array.Empty<Cell>()
            ).SetName("{m} Black pawn 4, 4");
            
            // Black 4, 4 with obstacle in 4, 5
            yield return new TestCaseData
            (
                new Pawn(Color.Black, Board[4, 4], Board, AttackDirection.South),
                Enumerable.Empty<Cell>(),
                new[] { Board[4, 5] }
            ).SetName("{m} Black pawn 4, 4 with obstacle in 4, 5");
            
            // Black 4, 1
            yield return new TestCaseData
            (
                new Pawn(Color.Black, Board[4, 1], Board, AttackDirection.South),
                new List<Cell> { Board[4, 2], Board[4, 3] },
                Array.Empty<Cell>()
            ).SetName("{m} Black pawn 4, 1");
            
            // Black 4, 1 with obstacle in 4, 2
            yield return new TestCaseData
            (
                new Pawn(Color.Black, Board[4, 1], Board, AttackDirection.South),
                Enumerable.Empty<Cell>(),
                new[] { Board[4, 2] }
            ).SetName("{m} Black pawn 4, 1 with obstacle in 4, 2");
            
            // Black 4, 1 with obstacle in 4, 3
            yield return new TestCaseData
            (
                new Pawn(Color.Black, Board[4, 1], Board, AttackDirection.South),
                new List<Cell> { Board[4, 2] },
                new[] { Board[4, 3] }
            ).SetName("{m} Black pawn 4, 1 with obstacle in 4, 3");
            
            // Black 0, 7
            yield return new TestCaseData
            (
                new Pawn(Color.Black, Board[0, 7], Board, AttackDirection.South),
                Enumerable.Empty<Cell>(),
                Array.Empty<Cell>()
            ).SetName("{m} Black pawn 0, 7");
            
            #endregion

            #region Knight
    
            // White 2, 2 with obstacle in: 4, 1; 2, 1; 1, 1
            yield return new TestCaseData
            (
                new Knight(Color.White, Board[2, 2], Board),
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
                new Knight(Color.Black, Board[0, 0], Board),
                new List<Cell> { Board[2, 1], Board[1, 2] },
                Array.Empty<Cell>()
            ).SetName("{m} Black knight 0, 0");

            #endregion

            #region Bishop
            
            // White 3, 2 with obstacle in 4, 1 and 3, 1
            yield return new TestCaseData
            (
                new Bishop(Color.White, Board[3, 2], Board),
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

            // Black 7, 0 with obstacle in 5, 2
            yield return new TestCaseData
            (
                new Bishop(Color.Black, Board[7, 0], Board),
                new List<Cell>
                {
                    Board[6, 1]
                },
                new[]
                {
                    Board[5, 2]
                }
            ).SetName("{m} Black bishop 7, 0 with obstacle in 5, 2");
            
            #endregion

            #region Rook

            // White 3, 4 with obstacle in 5, 4
            yield return new TestCaseData
            (
                new Rook(Color.White, Board[3, 4], Board),
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

            // Black 7, 7
            yield return new TestCaseData
            (
                new Rook(Color.Black, Board[7, 7], Board),
                new List<Cell>
                {
                    // North
                    Board[7, 6], Board[7, 5], Board[7, 4], Board[7, 3],
                    Board[7, 2], Board[7, 1], Board[7, 0],
                    // West
                    Board[6, 7], Board[5, 7], Board[4, 7], Board[3, 7],
                    Board[2, 7], Board[1, 7], Board[0, 7]
                },
                Array.Empty<Cell>()
            ).SetName("{m} Black rook 7, 7");
            
            #endregion

            #region King

            // White 3, 3 with obstacle in 4, 4 and 3, 4
            yield return new TestCaseData
            (
                new King(Color.White, Board[3, 3], Board),
                new List<Cell>
                {
                    Board[3, 2],
                    Board[4, 2],
                    Board[4, 3],
                    Board[2, 4],
                    Board[2, 3],
                    Board[2, 2]
                },
                new[]
                {
                    Board[4, 4],
                    Board[3, 4]
                }
            ).SetName("{m} White king 3, 3 with obstacle in 4, 4 and 3, 4");

            // Black 0, 0
            yield return new TestCaseData
            (
                new King(Color.Black, Board[0, 0], Board),
                new List<Cell>
                {
                    Board[1, 0],
                    Board[0, 1],
                    Board[1, 1]
                },
                Array.Empty<Cell>()
            ).SetName("{m} Black king 0, 0");
            
            #endregion

            #region Queen

            // White 6, 3 with obstacle in 4, 1; 5, 1; 6, 1
            yield return new TestCaseData
            (
                new Queen(Color.White, Board[6, 3], Board),
                new List<Cell>
                {
                    // North-west
                    Board[5, 2],
                    // North-east
                    Board[7, 2],
                    // South-west
                    Board[5, 4], Board[4, 5], Board[3, 6], Board[2, 7],
                    // South-east
                    Board[7, 4],
                    // North
                    Board[6, 2],
                    // East
                    Board[7, 3],
                    // South
                    Board[6, 4], Board[6, 5], Board[6, 6], Board[6, 7],
                    // West
                    Board[5, 3], Board[4, 3], Board[3, 3], Board[2, 3], Board[1, 3], Board[0, 3]
                },
                new[]
                {
                    Board[4, 1],
                    Board[5, 1],
                    Board[6, 1]
                }
            ).SetName("{m} White queen 6, 3 with obstacle in 4, 1; 5, 1; 6, 1");

            // Black 0, 0 with obstacle in 1, 1
            yield return new TestCaseData
            (
                new Queen(Color.Black, Board[0, 0], Board),
                new List<Cell>
                {
                    // East
                    Board[1, 0], Board[2, 0], Board[3, 0], Board[4, 0],
                    Board[5, 0], Board[6, 0], Board[7, 0],
                    // South
                    Board[0, 1], Board[0, 2], Board[0, 3], Board[0, 4],
                    Board[0, 5], Board[0, 6], Board[0, 7]
                },
                new[]
                {
                    Board[1, 1]
                }
            ).SetName("{m} Black queen 0, 0 with obstacle in 1, 1");

            #endregion
        }
    }
    */