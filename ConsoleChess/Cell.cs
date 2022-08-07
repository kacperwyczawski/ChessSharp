using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ConsoleChess.ChessPieces;

namespace ConsoleChess;

[DebuggerDisplay("(Cell {X},{Y}) with {Piece}")]
public class Cell
{
    [Range(0, 7)]
    public int X { get; }
    
    [Range(0, 7)]
    public int Y { get; }
    
    public ChessPiece? Piece { get; set; }
    
    private ChessBoard _parentBoard;
    
    public bool IsOccupied => Piece is not null;

    public Cell(int x, int y, ChessBoard parentBoard)
    {
        X = x;
        Y = y;
        _parentBoard = parentBoard;
    }
}