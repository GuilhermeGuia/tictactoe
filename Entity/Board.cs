namespace TICTACTOE.Entity;
class Board
{
    private BoardState[,] Game = {};
    public Board()
    {
        Game = new BoardState[3,3];
        InitBoard();
    }

    public BoardState[,] GameBoard
    {
        get { return Game; }
    }

    public int GetRowBoardItem(int position)
    {
        return (position - 1) / 3;
    }

    public int GetColumnBoardItem(int position)
    {
        return (position - 1) % 3;
    }

    public bool CheckWin(Player player)
    {
        return WinInRow(player.Mark) || WinInColumn(player.Mark) || WinInDiagonal(player.Mark);
    }

    public bool CheckDrawn()
    {
        int drawCount = 0;
        // verifica se todas as linhas e colunas estao preenchidas
         for (int i = 0; i < Game.GetLength(0); i++)
        {
            for (int j = 0; j < Game.GetLength(1); j++)
            {
               if(Game[i,j] == BoardState.X || Game[i,j] == BoardState.O){
                drawCount++;
               }
            }
        }

        return drawCount == 9;
    }
    
    public void InitBoard()
    {
        for(int i = 0; i < Game.GetLength(0); i++){
            for(int j = 0; j < Game.GetLength(1); j++){
                Game[i,j] = BoardState.Empty;
            }   
        }
    }
    public void InsertInBoard(int choice, Player player)
    {
        int row = GetRowBoardItem(choice);
        int column = GetColumnBoardItem(choice);

        Game[row, column] = player.Mark;
    }
    public void PrintBoard()
    {
        var FrontBoard = GetFrontBoard();

        Console.WriteLine(@$"
                 |     |
              {FrontBoard[0,0]}  |  {FrontBoard[0,1]}  |  {FrontBoard[0,2]}
            _____|_____|_____
                 |     |    
              {FrontBoard[1,0]}  |  {FrontBoard[1,1]}  |  {FrontBoard[1,2]}
            _____|_____|_____  
                 |     |    
              {FrontBoard[2,0]}  |  {FrontBoard[2,1]}  |  {FrontBoard[2,2]}
                 |     |
        ");
    }
    private string[,] GetFrontBoard()
    {
        string[,] userGameSelecteds = new string[3,3];

        for (int i = 0; i < Game.GetLength(0); i++)
        {
            for (int j = 0; j < Game.GetLength(1); j++)
            {
                if(Game[i,j] == BoardState.X){
                    userGameSelecteds[i,j] = "X";
                } else if(Game[i,j] == BoardState.O){
                    userGameSelecteds[i,j] = "O";
                }else{
                    userGameSelecteds[i,j] = "-";
                }
            }
        }

        return userGameSelecteds;
    }
    private bool WinInRow(BoardState player)
    {
        for (int i = 0; i < Game.GetLength(0); i++)
        {
            int sequenceWin = 0;
            for (int j = 0; j < Game.GetLength(1); j++)
            {
                if(Game[i,j] == player){
                    sequenceWin++;
                }
            }

            if(sequenceWin == 3){
                return true;
            }
        }

        return false;
    }
    private bool WinInColumn(BoardState player)
    {
        for (int i = 0; i < Game.GetLength(0); i++)
        {
            int sequenceWin = 0;
            for (int j = 0; j < Game.GetLength(1); j++)
            {
                if(Game[j,i] == player){
                    sequenceWin++;
                }
            }

            if(sequenceWin == 3){
                return true;
            }
        }

        return false;
    }
    private bool WinInDiagonal(BoardState player){
        int ordem = Game.GetLength(0);
        int sequenceWin = 0;

        for (int i = 0; i < ordem; i++)
        {
            if(Game[i,i] == player){
                sequenceWin++;
            }
        }

        if(sequenceWin == 3){
            return true;
        }

        sequenceWin = 0;
        for (int i = 0; i < ordem; i++)
        {
            int j = ordem - i - 1;
            if(Game[i,j] == player){
                sequenceWin++;
            }
        }
        if(sequenceWin == 3){
            return true;
        }

        return false;
    }
}

public enum BoardState
{
    Empty = -1,
    X = 1,
    O = 0,
}