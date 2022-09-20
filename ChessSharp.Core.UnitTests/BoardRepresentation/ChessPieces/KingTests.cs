using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

public class KingTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame(csgnString:
            "1K 2P -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- 2K -- -- --;" +
            "-- -- -- -- -- 1R -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- -- -- -- -- -- --;",
            new Player("P1", Color.White, AttackDirection.North),
            new Player("P2", Color.Black, AttackDirection.South));

        Move.Board = game.Board;
        Assert.Multiple(() =>
        {
            Assert.That(game.Board[0, 0].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("0,0 > 0,1"),
                new("0,0 > 1,1"),
                new("0,0 > 1,0")
            }));
            Assert.That(game.Board[4, 4].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("4,4 > 3,3"),
                new("4,4 > 3,4"),
                new("4,4 > 3,5"),

                new("4,4 > 4,3"),
                new("4,4 > 4,5"),

                new("4,4 > 5,3"),
                new("4,4 > 5,4"),
                new("4,4 > 5,5")
            }));
        });
    }
}