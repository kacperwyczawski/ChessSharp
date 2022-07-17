using System.ComponentModel.DataAnnotations;
using ConsoleChess.ChessPieces;

namespace ConsoleChess;

public class Cell
{
    [Range(0, 7)]
    public int X { get; }
    
    [Range(0, 7)]
    public int Y { get; }
    
    public ChessPiece? Piece { get; set; }
    
    public bool IsOccupied => Piece is not null;

    public Cell(int x, int y, ChessPiece? piece = null)
    {
        X = x;
        Y = y;
        Piece = piece;
    }
}