using Ex02_Asaf_319094322_Liat_207918608.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // אתחול המשחק באמצעות GameSetup
                var gameSetupResult = GameSetup.InitializeGame();

                // חילוץ פרטי המשחק מהתוצאה
                Board board = gameSetupResult.Board;
                Player player1 = gameSetupResult.Player1;
                Player player2 = gameSetupResult.Player2;

                // יצירת משחק באמצעות GameBuilder
                GameBuilder gameBuilder = new GameBuilder();
                Game game = gameBuilder
                    .SetBoard(board)
                    .AddPlayer(player1)
                    .AddPlayer(player2)
                    .Build();

                // יצירת ConsoleView ו-GameController
                ConsoleView consoleView = new ConsoleView();
                GameController gameController = new GameController(game, consoleView);

                // ניקוי המסך והפעלת המשחק
                Console.Clear();
                gameController.StartGame();
            }
            catch (Exception ex)
            {
                // טיפול בשגיאות כלליות
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }


}
