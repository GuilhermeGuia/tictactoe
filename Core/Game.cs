using System.Security.Principal;
using TICTACTOE.Entity;

namespace TICTACTOE.Core;
class Game 
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentPlayer;

    public Game()
    {
        board = new Board();
        player1 = new Player(BoardState.X);
        player2 = new Player(BoardState.O);
        currentPlayer = player1;
    }
    
    public void Run()
    {
        while (true)
        {
            board.PrintBoard();

            Console.Write($"Jogador {currentPlayer.Mark}: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            bool isValid = ValidateChoice(choice);
            if(!isValid){
                continue;
            }

            board.InsertInBoard(choice, currentPlayer);

            bool isWin = board.CheckWin(currentPlayer);
            if(isWin){
                Console.WriteLine($"\nJogador {currentPlayer.Mark} ganhou!!");
                board.PrintBoard();

                Console.WriteLine("Deseja jogar novamente? [S/N]");
                string? option = Console.ReadLine();
                if(option?.ToLower() == "s"){
                    RestartGame(true);
                    continue;
                }

                break;
            }

            bool isDraw = board.CheckDrawn();
            if(isDraw){
                Console.WriteLine($"\n\nDeu velha!\n");
                board.PrintBoard();
                Console.WriteLine("Deseja jogar novamente? [S/N]");
                string? option = Console.ReadLine();
                if(option?.ToLower() == "s"){
                    RestartGame(false);
                    continue;
                }

                break;
            }

            currentPlayer = SwitchCurrentPlayer();
        }
    }

    private Player SwitchCurrentPlayer()
    {
        return currentPlayer == player1 ? player2 : player1;
    }

    private void RestartGame(bool isWin)
    {
        board.InitBoard();
        currentPlayer = isWin ? currentPlayer : SwitchCurrentPlayer(); 
    }

    private bool ValidateChoice(int choice)
    {
        if(choice < 1 || choice > 9){
            Console.WriteLine("\n\nERROR: numero digitado fora do escopo do jogo!");
            return false;
        }

        int row = board.GetRowBoardItem(choice);
        int column = board.GetColumnBoardItem(choice);

        if(board.GameBoard[row, column] != BoardState.Empty){
            Console.WriteLine("\n\nERROR: posição ja foi selecionada!");
            return false;
        }

        return true;        
    }
}