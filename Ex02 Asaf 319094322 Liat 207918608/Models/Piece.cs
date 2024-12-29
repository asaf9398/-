using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public enum ePieceType
    {
        X,        // כלי של שחקן X
        O,        // כלי של שחקן O
        KingX,    // מלך של שחקן X
        KingO     // מלך של שחקן O
    }

    public class Piece
    {
        private ePieceType m_Type;
        private Position m_Position;

        public Piece(ePieceType i_Type, Position i_Position)
        {
            m_Type = i_Type;
            m_Position = i_Position;
        }

        public ePieceType Type
        {
            get { return m_Type; }
        }

        public Position Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public bool IsKing
        {
            get { return m_Type == ePieceType.KingX || m_Type == ePieceType.KingO; }
        }

        public void PromoteToKing()
        {
            if (m_Type == ePieceType.X)
            {
                m_Type = ePieceType.KingX;
            }
            else if (m_Type == ePieceType.O)
            {
                m_Type = ePieceType.KingO;
            }
        }

        public override string ToString()
        {
            switch (m_Type)
            {
                case ePieceType.X:
                    return "X";
                case ePieceType.O:
                    return "O";
                case ePieceType.KingX:
                    return "K";
                case ePieceType.KingO:
                    return "U";
                default:
                    return " ";
            }
        }

    }


}
