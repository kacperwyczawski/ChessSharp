using System.Drawing;
using ChessSharp.Core.BoardRepresentation;

namespace ChessSharp.Core.UnitTests;

// TODO: Move this to readme as example usage
[TestFixture]
public class BigAssTopLevelTests
{
    /// <summary>
    /// This big-ass test is how whole ChessSharp library should work
    /// </summary>
    [Test]
    public void RegularGame()
    {
        var game = new ChessGame
        (
            new Player("P1", Color.Blue, AttackDirection.North),
            new Player("P2", Color.Red, AttackDirection.South)
        );

        while (!game.IsOver)
        {
            // get board and display it
            _ = game.Board;

            // get current player name and display it
            _ = game.CurrentPlayer.Name;

            // ask user for coordinates of piece and get piece from that coordinates
            // for example user entered 0, 1
            var selectedPiece = game.Board[0, 1].Piece
                                ?? throw new Exception("There is no piece under given coordinates");

            // now you can get and display valid moves for that piece
            var moves = selectedPiece.GetValidMoves();

            // and finally you can execute that move, like this:
            moves
                .ElementAt(new Random().Next(moves.Count()))
                .ExecuteMove();

            // or like this, using coordinates
            moves.First(m => m.DestinationCell is { X: 0, Y: 3 }).ExecuteMove();

            // or even like this (probably most readable)
            var selectedCell = game.Board[0, 3];
            moves.First(m => m.DestinationCell == selectedCell).ExecuteMove();
        }

        Console.WriteLine(game.Winner is not null ? $"{game.Winner.Color} player won!" : "Stalemate!");
    }
}