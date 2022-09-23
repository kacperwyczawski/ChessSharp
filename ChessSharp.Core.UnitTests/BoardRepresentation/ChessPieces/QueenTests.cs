using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

public class QueenTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame(csgnString:
            "1Q -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- 2Q -- -- 2Q;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --",
            new Player("P1", Color.White, AttackDirection.North),
            new Player("P2", Color.Black, AttackDirection.West));

        Move.Board = game.Board;
        
        Assert.Multiple(() =>
        {
            Assert.That(game.Board[0, 0].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("0,0 > 0,1"),
                new("0,0 > 0,2"),
                new("0,0 > 0,3"),
                new("0,0 > 0,4"),
                new("0,0 > 0,5"),
                new("0,0 > 0,6"),
                new("0,0 > 0,7"),

                new("0,0 > 1,0"),
                new("0,0 > 2,0"),
                new("0,0 > 3,0"),
                new("0,0 > 4,0"),
                new("0,0 > 5,0"),
                new("0,0 > 6,0"),
                new("0,0 > 7,0"),

                new("0,0 > 1,1"),
                new("0,0 > 2,2"),
                new("0,0 > 3,3"),
                new("0,0 > 4,4")
            }));
            Assert.That(game.Board[4, 4].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                // north
                new("4,4 > 4,3"),
                new("4,4 > 4,2"),
                new("4,4 > 4,1"),
                new("4,4 > 4,0"),

                // south
                new("4,4 > 4,5"),
                new("4,4 > 4,6"),
                new("4,4 > 4,7"),

                // east
                new("4,4 > 5,4"),
                new("4,4 > 6,4"),
                // here is another piece of same player so without move 4,4 > 7,4

                // west
                new("4,4 > 3,4"),
                new("4,4 > 2,4"),
                new("4,4 > 1,4"),
                new("4,4 > 0,4"),

                // north-east
                new("4,4 > 5,3"),
                new("4,4 > 6,2"),
                new("4,4 > 7,1"),

                // north-west
                new("4,4 > 3,3"),
                new("4,4 > 2,2"),
                new("4,4 > 1,1"),
                new("4,4 > 0,0"),

                // south-east
                new("4,4 > 5,5"),
                new("4,4 > 6,6"),
                new("4,4 > 7,7"),

                // south-west
                new("4,4 > 3,5"),
                new("4,4 > 2,6"),
                new("4,4 > 1,7")
            }));
            Assert.That(game.Board[7, 4].Piece!.GetValidMoves(), Has.None.EqualTo(new Move("7,4 > 4,4")));
            Assert.That(game.Board[7, 4].Piece!.GetValidMoves(), Has.None.EqualTo(new Move("7,4 > 3,4")));
        });
    }
}