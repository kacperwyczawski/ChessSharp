namespace ChessSharp.Core.BoardRepresentation;

// this may be also struct in the future, with Func<int, int, bool> CanMoveForward with delegate to check if it can
// and some other fields and also North, South, East and West fields to use it like an enum
public enum AttackDirection
{
    North, // white pieces in regular chess
    South, // black pieces in regular chess
    East,
    West,
}