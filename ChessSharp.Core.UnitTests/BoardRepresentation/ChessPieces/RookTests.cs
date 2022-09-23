using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

public class RookTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame(csgnString:
            "1R -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "2R -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- 1R -- -- 1P;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;",
            new Player("P1", Color.White, AttackDirection.North),
            new Player("P2", Color.Black, AttackDirection.South));

        Move.Board = game.Board;
        Assert.Multiple(() =>
        {
            Assert.That(game.Board[0, 0].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("0,0 > 1,0"),
                new("0,0 > 2,0"),
                new("0,0 > 3,0"),
                new("0,0 > 4,0"),
                new("0,0 > 5,0"),
                new("0,0 > 6,0"),
                new("0,0 > 7,0"),

                new("0,0 > 0,1"),
                new("0,0 > 0,2")
            }));
            Assert.That(game.Board[0, 2].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("0,2 > 1,2"),
                new("0,2 > 2,2"),
                new("0,2 > 3,2"),
                new("0,2 > 4,2"),
                new("0,2 > 5,2"),
                new("0,2 > 6,2"),
                new("0,2 > 7,2"),

                new("0,2 > 0,0"),
                new("0,2 > 0,1"),

                new("0,2 > 0,3"),
                new("0,2 > 0,4"),
                new("0,2 > 0,5"),
                new("0,2 > 0,6"),
                new("0,2 > 0,7")
            }));
            Assert.That(game.Board[4, 4].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("4,4 > 5,4"),
                new("4,4 > 6,4"),

                new("4,4 > 3,4"),
                new("4,4 > 2,4"),
                new("4,4 > 1,4"),
                new("4,4 > 0,4"),

                new("4,4 > 4,5"),
                new("4,4 > 4,6"),
                new("4,4 > 4,7"),

                new("4,4 > 4,3"),
                new("4,4 > 4,2"),
                new("4,4 > 4,1"),
                new("4,4 > 4,0")
            }));
        });
    }
}