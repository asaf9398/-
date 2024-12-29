using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class PlayerTurnState : IGameState
    {
        public void Handle(Game i_Game)
        {
            Player currentPlayer = i_Game.GetCurrentPlayer();
            Board board = i_Game.Board;

            Console.Clear();
            Console.WriteLine($"It's {currentPlayer.Name}'s turn!");
            board.PrintBoard();

            Move move = currentPlayer.GetMove(board);
            board.MovePiece(move.From, move.To);
            i_Game.RecordMove(move); // עדכון המהלך האחרון

            if (i_Game.IsGameOver())
            {
                i_Game.SetState(new GameOverState());
            }
            else
            {
                i_Game.SwitchToNextPlayer();
                i_Game.SetState(new PlayerTurnState());
            }
        }
    }

}
