using System.Drawing;
using System.Text.RegularExpressions;
using ChessSharp.Core.BoardRepresentation;
using ChessSharp.Core.BoardRepresentation.ChessPieces;

namespace ChessSharp.Core;

public class ChessGame
{
    public ChessBoard Board { get; private set; }

    public Player CurrentPlayer { get; private set; }

    public bool IsOver { get; private set; } = false;

    public Player? Winner { get; private set; } = null;

    private IEnumerable<ChessPiece> ChessPieces => Board.GetAllChessPieces();

    private readonly List<Player> _players = new();

    public ChessGame(Player firstPlayer, Player secondPlayer, params Player[] additionalPlayers)
    {
        // TODO: Implement additional players and remove these two lines below
        if (additionalPlayers.Length > 0)
            throw new NotImplementedException();

        _players.Add(firstPlayer);
        _players.Add(secondPlayer);
        _players.AddRange(additionalPlayers);
        CurrentPlayer = firstPlayer;
        Board = new ChessBoard(firstPlayer, secondPlayer);
    }

    public ChessGame(string csgnString, Player firstPlayer, Player secondPlayer, params Player[] additionalPlayers)
    {
        /*
         
        Chess Sharp Game Notation (CSGN)
        
        Whitespaces and newlines are ignored.
            
        1R 1N 1B 1Q 1K 1B 1N 1R;
        1P 1P 1P 1P 1P 1P 1P 1P;
        -- -- -- -- -- -- -- --;
        -- -- -- -- -- -- -- --;
        -- -- -- -- -- -- -- --;
        -- -- -- -- -- -- -- --;
        2P 2P 2P 2P 2P 2P 2P 2P;
        2R 2N 2B 2Q 2K 2B 2N 2R;
        
        [] [] [] 1R 1N 1B 1Q 1K 1B 1N 1R [] [] [];
        [] [] [] 1P 1P 1P 1P 1P 1P 1P 1P [] [] [];
        [] [] [] -- -- -- -- -- -- -- -- [] [] [];
        4R 4P -- -- -- -- -- -- -- -- -- -- 2P 2R;
        4N 4P -- -- -- -- -- -- -- -- -- -- 2P 2N;
        4B 4P -- -- -- -- -- -- -- -- -- -- 2P 2B;
        4Q 4P -- -- -- -- -- -- -- -- -- -- 2P 2Q;
        4K 4P -- -- -- -- -- -- -- -- -- -- 2P 2K;
        4B 4P -- -- -- -- -- -- -- -- -- -- 2P 2B;
        4N 4P -- -- -- -- -- -- -- -- -- -- 2P 2N;
        4R 4P -- -- -- -- -- -- -- -- -- -- 2P 2R;
        [] [] [] -- -- -- -- -- -- -- -- [] [] [];
        [] [] [] 3P 3P 3P 3P 3P 3P 3P 3P [] [] [];
        [] [] [] 3R 3N 3B 3Q 3K 3B 3N 3R [] [] [];
        
        */
        
        // add players and create board
        // TODO: Implement additional players and remove these two lines below
        if (additionalPlayers.Length > 0)
            throw new NotImplementedException();

        _players.Add(firstPlayer);
        _players.Add(secondPlayer);
        _players.AddRange(additionalPlayers);
        CurrentPlayer = firstPlayer;
        Board = new ChessBoard(firstPlayer, secondPlayer);
        
        // remove whitespaces and newlines from string
        csgnString = Regex.Replace(csgnString, @"\s+", "");
        
        // split string into rows
        var rows = csgnString.Split(';', StringSplitOptions.RemoveEmptyEntries);
        
        // fill board
        for (var y = 0; y < rows.Length; y++)
        {
            var row = rows[y];
            for (var x = 0; x < rows.Length; x++)
            {
                var cell = row.Substring(x * 2, 2);
                
                // skip empty cells
                if (cell == "--")
                    continue;
                
                // TODO: if cell == "[]" add wall
                
                var player = _players[int.Parse(cell[0].ToString()) - 1];
                var pieceType = cell[1] switch
                {
                    // TODO: Use reflection or something to get the type and follow OCP
                    'P' => typeof(Pawn),
                    'R' => typeof(Rook),
                    'N' => typeof(Knight),
                    'B' => typeof(Bishop),
                    'Q' => typeof(Queen),
                    'K' => typeof(King),
                    _ => throw new ArgumentException($"Unknown piece type: {cell[1]}")
                };
                var piece =
                    Activator.CreateInstance(pieceType, Board[x, y], Board, player) as ChessPiece
                    ?? throw new ArgumentException($"Could not create piece of type {pieceType}");
                
                Board[x, y].Piece = piece;
            }
        }
    }

    public ChessGame(Player uppercasePlayer, Player lowercasePlayer, string simplifiedFenString)
    {
        // TODO: validate

        _players.Add(lowercasePlayer);
        _players.Add(uppercasePlayer);
        CurrentPlayer = uppercasePlayer;
        Board = new ChessBoard(uppercasePlayer, lowercasePlayer, true);

        var rows = simplifiedFenString.Split("/");

        for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
        {
            var row = rows[rowIndex];
            
            var columnIndex = 0;
            foreach (var character in row)
            {
                if (char.IsDigit(character))
                {
                    columnIndex += int.Parse(character.ToString());
                    continue;
                }

                var player = char.IsUpper(character) ? uppercasePlayer : lowercasePlayer;
                var pieceType = character switch
                {
                    // TODO: Use reflection or something to get the type and follow OCP
                    'P' => typeof(Pawn),
                    'R' => typeof(Rook),
                    'N' => typeof(Knight),
                    'B' => typeof(Bishop),
                    'Q' => typeof(Queen),
                    'K' => typeof(King),
                    _ => throw new ArgumentException($"Unknown piece type: {character}")
                };

                var piece =
                    Activator.CreateInstance(pieceType, Board[columnIndex, rowIndex], Board, player) as ChessPiece
                    ?? throw new ArgumentException($"Could not create piece of type {pieceType}");

                Board[columnIndex, rowIndex].Piece = piece;

                columnIndex++;
            }
        }
    }

    public IReadOnlyList<Player> GetPlayers()
    {
        return _players.AsReadOnly();
    }
}