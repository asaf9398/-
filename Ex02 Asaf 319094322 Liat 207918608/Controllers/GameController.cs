using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class GameController
    {
        private readonly Game m_Game;
        private readonly ConsoleView m_View;

        public GameController(Game i_Game, ConsoleView i_View)
        {
            m_Game = i_Game;
            m_View = i_View;
        }

        public void StartGame()
        {
            m_Game.SetState(new PlayerTurnState());

            //while (!m_Game.IsGameOver())
            //{
            //    m_View.PrintBoard(m_Game.Board);
            //    Player currentPlayer = m_Game.GetCurrentPlayer();
            //    m_View.PrintTurn(currentPlayer.Name, currentPlayer.PieceType);
            //
            //    Move move = currentPlayer.GetMove(m_Game.Board);
            //    if (m_Game.Board.IsMoveValid(move.From, move.To))
            //    {
            //        m_Game.Board.MovePiece(move.From, move.To);
            //        m_Game.RecordMove(move);
            //        
            //    }
            //    else
            //    {
            //        m_View.PrintInvalidMove();
            //    }
            //}
            //
            //m_View.PrintGameOver(m_Game.GetWinner());
        }
    }

}
