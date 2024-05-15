namespace TICTACTOE.Entity;
class Player
{
    public BoardState Mark { get; } 
    public Player(BoardState mark)
    {
        Mark = mark;
    }
}