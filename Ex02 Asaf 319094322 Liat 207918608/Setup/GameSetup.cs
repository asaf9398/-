using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608.Setup
{
    public class GameSetupResult
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }

    public class GameSetup
    {
        public static GameSetupResult InitializeGame()
        {
            Console.WriteLine("Welcome to Checkers!");

            // קבלת שם השחקן הראשון
            Console.Write("Enter your name (max 20 characters, no spaces): ");
            string player1Name = GetValidatedName();

            // קבלת גודל הלוח
            Console.Write("Choose board size (6, 8, or 10): ");
            int boardSize = GetValidatedBoardSize();

            // קבלת סוג המשחק
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1. Two players");
            Console.WriteLine("2. Play against computer");
            int gameMode = GetValidatedGameMode();

            Board board = new Board(boardSize);
            Player player1 = null;
            Player player2 = null;

            // הגדרת השחקנים וסוג הכלי שלהם (X או O)
            if (gameMode == 1)
            {
                Console.Write("Enter the second player's name (max 20 characters, no spaces): ");
                string player2Name = GetValidatedName();
                player1 = PlayerFactory.CreatePlayer(player1Name, true, 'X', board);
                player2 = PlayerFactory.CreatePlayer(player2Name, true, 'O', board);
            }
            else
            {
                player1 = PlayerFactory.CreatePlayer(player1Name, true, 'X', board);
                player2 = PlayerFactory.CreatePlayer("Computer", false, 'O', board, new RandomMoveStrategy());
            }

            Console.WriteLine("Game setup complete!");
            Console.WriteLine($"Player 1: {player1.Name} ({player1.PieceType})");
            Console.WriteLine($"Player 2: {player2.Name} ({player2.PieceType})");
            Console.WriteLine($"Board size: {boardSize}x{boardSize}");

            return new GameSetupResult
            {
                Board = board,
                Player1 = player1,
                Player2 = player2
            };
        }

        private static string GetValidatedName()
        {
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name) || name.Contains(" ") || name.Length > 20)
            {
                Console.Write("Invalid name. Please enter a name (max 20 characters, no spaces): ");
                name = Console.ReadLine();
            }
            return name;
        }

        private static int GetValidatedBoardSize()
        {
            int boardSize;
            while (!int.TryParse(Console.ReadLine(), out boardSize) || (boardSize != 6 && boardSize != 8 && boardSize != 10))
            {
                Console.Write("Invalid board size. Please choose 6, 8, or 10: ");
            }
            return boardSize;
        }

        private static int GetValidatedGameMode()
        {
            int gameMode;
            while (!int.TryParse(Console.ReadLine(), out gameMode) || (gameMode != 1 && gameMode != 2))
            {
                Console.Write("Invalid choice. Please choose 1 (Two players) or 2 (Play against computer): ");
            }
            return gameMode;
        }
    }
}
