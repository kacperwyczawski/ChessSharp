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

    public ChessGame(string csgnString)
    {
        /*
        
        Chess Sharp Game Notation (CSGN)
        - line breaks and whitespaces are ignored
        - each section begins with a tag and ends with two semicolons
        - each tag is # followed by a tag name
        - inside section, values are separated by colons
        - Empty in board section can also by represented as a `-` (single dash)
        Example:
        
        #Player:John:White:North;;
        #Player:Lisa:Black:South;;
        #CurrentPlayer:John;;
        #Board:8
        :John'sRook:John'sKnight:John'sBishop:John'sQueen:John'sKing:John'sBishop:John'sKnight:John'sRook
        :John'sPawn:John'sPawn:John'sPawn:John'sPawn:John'sPawn:John'sPawn:John'sPawn:John'sPawn
        :Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty
        :Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty
        :Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty
        :Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty
        :Lisa'sPawn:Lisa'sPawn:Lisa'sPawn:Lisa'sPawn:Lisa'sPawn:Lisa'sPawn:Lisa'sPawn:Lisa'sPawn:
        :Lisa'sRook:Lisa'sKnight:Lisa'sBishop:Lisa'sQueen:Lisa'sKing:Lisa'sBishop:LisaKnight:Lisa'sRook;;
        
        */
        
        // remove whitespaces and line breaks from string
        csgnString = Regex.Replace(csgnString, @"\s+", "");

        // split string into sections
        var sections = csgnString.Split(";;");

        foreach (var section in sections)
        {
            // split section
            var tagAndValues = section.Split(":");

            // get tag and values
            var tag = tagAndValues[0];
            var values = tagAndValues[1..];

            // parse tag and values
            switch (tag)
            {
                case "#Player":
                    HandlePlayerTag(values);
                    break;
                case "#CurrentPlayer":
                    HandleCurrentPlayerTag(values);
                    break;
                case "#Board":
                    HandleBoardTag(values);
                    break;
                default:
                    throw new ArgumentException($"Unknown tag: {tag}");
            }
        }
        
        // throw exception if there is not enough players
        if (_players.Count < 2)
            throw new ArgumentException("Please provide at least two valid #Player tags");
        
        // throw exception if there is no current player
        if (CurrentPlayer == null)
            throw new ArgumentException("Please provide a valid #CurrentPlayer tag");
        
        // throw exception if there is no board
        if (Board == null)
            throw new ArgumentException("Please provide a valid #Board tag");

        // End
        return;

        void HandlePlayerTag(string[] values)
        {
            _players.Add(new Player
            (
                values[0],
                Color.FromName(values[1]),
                (AttackDirection)Enum.Parse(typeof(AttackDirection), values[2])
            ));
        }

        void HandleCurrentPlayerTag(string[] values)
        {
            if (values.Length != 1)
                throw new ArgumentException("Invalid number of values for tag #CurrentPlayer");
            
            CurrentPlayer = _players.First(p => p.Name == values[0]);
        }

        void HandleBoardTag(string[] values)
        {
            // get board size from first value
            var boardSize = int.Parse(values[0]);
            
            // check there are enough values for the board size
            if (values.Length != boardSize * boardSize * 2 + 1)
                throw new ArgumentException("Not enough values for given board size");
            
            // create board
            Board = new ChessBoard(_players[0], _players[1], true);

            // fill array with chess pieces from values
            var currentValueIndex = 0;
            for (var x = 0; x < boardSize; x++)
            {
                for (var y = 0; y < boardSize; y++)
                {
                    // get current value from values of section
                    var currentValue = values[currentValueIndex];
                    
                    // leave empty if "Empty"
                    if(currentValue is "Empty" or "-")
                        continue;
                    
                    // get player and piece strings
                    var playerString = currentValue.Split("'s")[0];
                    var pieceString = currentValue.Split("'s")[1];
                    
                    // get owner of piece
                    var player = _players.First(p => p.Name == playerString);
                    // get piece type
                    var pieceType = Type.GetType(pieceString)
                                    ?? throw new ArgumentException($"Unknown piece type: {pieceString}");
                    // create piece
                    var piece = Activator.CreateInstance(pieceType, Board[x, y], Board, player) as ChessPiece
                                ?? throw new ArgumentException($"Could not create piece of type {pieceType}");
                    
                    // add piece to board
                    Board[x, y].Piece = piece;
                    
                    // increment current value index
                    currentValueIndex++;
                }
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