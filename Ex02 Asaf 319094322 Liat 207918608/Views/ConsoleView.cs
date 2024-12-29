using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class ConsoleView
    {
        public void PrintBoard(Board i_Board)
        {
            i_Board.PrintBoard();
        }

        public void PrintTurn(string i_PlayerName, char i_PieceType)
        {
            Console.WriteLine($"It's {i_PlayerName}'s turn ({i_PieceType}).");
        }


        public void PrintInvalidMove()
        {
            Console.WriteLine("Invalid move. Try again.");
        }

        public void PrintGameOver(Player i_Winner)
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine(i_Winner != null ? $"Winner: {i_Winner.Name}" : "It's a draw!");
        }
    }

}
