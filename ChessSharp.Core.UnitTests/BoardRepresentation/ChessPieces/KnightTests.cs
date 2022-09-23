using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests.BoardRepresentation.ChessPieces;

[TestFixture]
public class KnightTests
{
    [Test]
    public void GetValidMoves()
    {
        var game = new ChessGame(csgnString:
            "1N 2P -- -- -- -- -- --;" +
            "-- 2P 2P -- 2N -- -- --;" +
            "-- -- -- -- -- -- -- --;" +
            "-- -- 1P -- -- -- -- --;" +
            "-- -- -- -- 1N -- -- --;" +
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
                new("0,0 > 2,1"),
                new("0,0 > 1,2")
            }));
            Assert.That(game.Board[4, 1].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("4,1 > 2,0"),
                new("4,1 > 6,0"),
                new("4,1 > 5,3"),
                new("4,1 > 3,3"),
                new("4,1 > 2,2"),
                new("4,1 > 6,2")
            }));
            Assert.That(game.Board[4, 4].Piece!.GetValidMoves(), Is.EquivalentTo(new List<Move>
            {
                new("4,4 > 6,3"),
                new("4,4 > 5,6"),
                new("4,4 > 3,6"),
                new("4,4 > 2,5"),
                new("4,4 > 6,5"),
                new("4,4 > 5,2"),
                new("4,4 > 3,2")
            }));
        });
    }
}