using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class GameBuilder
    {
        private Board m_Board;
        private List<Player> m_Players;

        public GameBuilder()
        {
            m_Board = new Board();
            m_Players = new List<Player>();
        }

        public GameBuilder SetBoard(Board i_Board)
        {
            m_Board = i_Board;
            return this;
        }

        public GameBuilder AddPlayer(Player i_Player)
        {
            m_Players.Add(i_Player);
            return this;
        }

        public Game Build()
        {
            if (m_Players.Count < 2)
            {
                throw new InvalidOperationException("A game must have at least two players.");
            }
            return new Game(m_Board, m_Players.ToArray());
        }
    }

}
