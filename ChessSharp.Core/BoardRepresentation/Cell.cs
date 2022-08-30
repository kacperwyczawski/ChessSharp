using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ChessSharp.Core.BoardRepresentation.ChessPieces;

namespace ChessSharp.Core.BoardRepresentation;

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

    public Cell GetFrontNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetNorthNeighbor(),
        AttackDirection.South => GetSouthNeighbor(),
        AttackDirection.East => GetEastNeighbor(),
        AttackDirection.West => GetWestNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetBackNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetSouthNeighbor(),
        AttackDirection.South => GetNorthNeighbor(),
        AttackDirection.East => GetWestNeighbor(),
        AttackDirection.West => GetEastNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetLeftNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetWestNeighbor(),
        AttackDirection.South => GetEastNeighbor(),
        AttackDirection.East => GetNorthNeighbor(),
        AttackDirection.West => GetSouthNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetRightNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetEastNeighbor(),
        AttackDirection.South => GetWestNeighbor(),
        AttackDirection.East => GetSouthNeighbor(),
        AttackDirection.West => GetNorthNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetFrontLeftNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetNorthWestNeighbor(),
        AttackDirection.South => GetSouthEastNeighbor(),
        AttackDirection.East => GetNorthNeighbor(),
        AttackDirection.West => GetSouthNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetFrontRightNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetNorthEastNeighbor(),
        AttackDirection.South => GetSouthWestNeighbor(),
        AttackDirection.East => GetSouthNeighbor(),
        AttackDirection.West => GetNorthNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetBackLeftNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetSouthWestNeighbor(),
        AttackDirection.South => GetNorthEastNeighbor(),
        AttackDirection.East => GetSouthNeighbor(),
        AttackDirection.West => GetNorthNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
    
    public Cell GetBackRightNeighbor(AttackDirection attackDirection) => attackDirection switch
    {
        AttackDirection.North => GetSouthEastNeighbor(),
        AttackDirection.South => GetNorthWestNeighbor(),
        AttackDirection.East => GetSouthNeighbor(),
        AttackDirection.West => GetNorthNeighbor(),
        _ => throw new InvalidEnumArgumentException(nameof(attackDirection),
            (int)attackDirection, typeof(AttackDirection))
    };
}