# ♟️ ChessSharp

![GitHub](https://img.shields.io/github/license/kacperwyczawski/ConsoleChess)

## :toolbox: *Work In Progress*

- [x] working chess board representation
- [ ] full move validation and checkmate/stalemate detection
- [ ] fairy pieces
- [ ] chess variants
- [ ] chess AI

### Additional:

- [ ] example working implementation

## :hammer_and_wrench: How to use

### Regular chess

```csharp
using ChessSharp;

// create a new game
var game = new ChessGame
(
    // add players
    new Player("P1", Color.Blue, AttackDirection.North),
    new Player("P2", Color.Red, AttackDirection.South)
);

while (!game.IsOver)
{
    // get board and do something with it (display it, etc.)
    _ = game.Board;
    
    // get current player name and do whatever you want with it
    _ = game.CurrentPlayer.Name;
    
    // ask user for coordinates of piece and get piece from that coordinates
    // for example user entered 0, 1
    var selectedPiece = game.Board[0, 1].Piece
                        ?? throw new Exception("There is no piece under given coordinates");
                        
    // now you can get and for example display valid moves for that piece
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

// display result of the game
Console.WriteLine(game.Winner is not null ? $"{game.Winner.Color} player won!" : "Stalemate!");
```
