using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(string i_Name, bool i_IsHuman, char i_PieceType, Board i_Board, IStrategy i_Strategy = null)
        {
            Player player = new Player(i_Name, i_IsHuman, i_PieceType, i_Board);
            if (!i_IsHuman && i_Strategy != null)
            {
                player.Strategy = i_Strategy;
            }
            return player;
        }
    }


}
