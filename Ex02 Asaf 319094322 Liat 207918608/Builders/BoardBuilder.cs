using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class BoardBuilder
    {
        private int m_Size = 10;

        public BoardBuilder SetSize(int i_Size)
        {
            m_Size = i_Size;
            return this;
        }

        public Board Build()
        {
            return new Board(m_Size);
        }
    }

}
