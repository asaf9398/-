using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class GameOverState : IGameState
    {
        public void Handle(Game i_Game)
        {
            Console.WriteLine("Game Over!");
            Player winner = i_Game.GetWinner();

            if (winner != null)
            {
                Console.WriteLine($"Winner: {winner.Name}");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Environment.Exit(0); // סיים את המשחק
        }
    }


}
