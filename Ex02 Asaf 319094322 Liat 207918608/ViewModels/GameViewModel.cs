using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class GameViewModel
    {
        private readonly Game m_Game;

        public GameViewModel(Game i_Game)
        {
            m_Game = i_Game;
        }

        public void HandleMove(string i_Input)
        {
            if (!InputValidator.IsValidMoveFormat(i_Input))
            {
                throw new FormatException("Invalid move format.");
            }

            string[] parts = i_Input.Split('>');
            Position from = ParsePosition(parts[0]);
            Position to = ParsePosition(parts[1]);

            if (!m_Game.Board.IsMoveValid(from, to))
            {
                throw new InvalidOperationException("Invalid move.");
            }

            m_Game.Board.MovePiece(from, to);
        }

        private Position ParsePosition(string i_Input)
        {
            char row = i_Input[0];
            char col = i_Input[1];
            return new Position(row - 'a', col - 'A');
        }
    }

}
