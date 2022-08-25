using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using ChessSharp.Core.ChessPieces;

namespace ChessSharp.Core;

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

    public void CreateAndSetPiece<T>(Color color) where T : ChessPiece
    {
        Piece = (T?)Activator.CreateInstance(typeof(T), color, this, _parentBoard);
    }
    
    public void RemovePiece()
    {
        Piece = null;
    }
    
    public Cell GetNorthNeighbor() => _parentBoard[X, Y - 1];
    public Cell GetSouthNeighbor() => _parentBoard[X, Y + 1];
    public Cell GetEastNeighbor() => _parentBoard[X + 1, Y];
    public Cell GetWestNeighbor() => _parentBoard[X - 1, Y];
    public Cell GetNorthEastNeighbor() => _parentBoard[X + 1, Y - 1];
    public Cell GetNorthWestNeighbor() => _parentBoard[X - 1, Y - 1];
    public Cell GetSouthEastNeighbor() => _parentBoard[X + 1, Y + 1];
    public Cell GetSouthWestNeighbor() => _parentBoard[X - 1, Y + 1];
}