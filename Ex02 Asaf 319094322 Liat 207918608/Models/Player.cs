using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class Player
    {
        private readonly string r_Name;      // שם השחקן
        private readonly bool r_IsHuman;    // האם השחקן אנושי
        private IStrategy m_Strategy;       // אסטרטגיה לשחקן (עבור AI)
        private readonly Board r_Board;
        public char PieceType { get; } // סוג הכלי (X או O)

        public Player(string i_Name, bool i_IsHuman, char i_PieceType, Board i_Board)
        {
            r_Name = i_Name;
            r_IsHuman = i_IsHuman;
            PieceType = i_PieceType;
            r_Board = i_Board;
        }

        public string Name
        {
            get { return r_Name; }
        }

        public bool IsHuman
        {
            get { return r_IsHuman; }
        }

        public IStrategy Strategy
        {
            get { return m_Strategy; }
            set { m_Strategy = value; }
        }

        public Move GetMove(Board i_Board)
        {
            if (r_IsHuman)
            {
                Console.WriteLine($"{r_Name}, Enter your move (e.g., Fa>Fb): ");
                string input = Console.ReadLine();
                return ParseMove(input, i_Board);
            }
            else
            {
                if (m_Strategy == null)
                {
                    throw new InvalidOperationException("Strategy is not set for AI player.");
                }

                return m_Strategy.GetMove(i_Board);
            }
        }

        private Move ParseMove(string i_Input, Board i_Board)
        {
            try
            {
                string[] parts = i_Input.Split('>')
                                        .Select(part => part.Trim())
                                        .ToArray();

                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid format. Please use the format 'ROWcol>ROWcol' (e.g., Fa>Fb).");
                }

                Position from = ParsePosition(parts[0]);
                Position to = ParsePosition(parts[1]);

                if (!i_Board.IsMoveValid(from, to))
                {
                    Console.WriteLine($"Invalid move from {from} to {to}. Please try again.");
                    return GetMove(i_Board); // בקשת קלט מחדש
                }

                return new Move(from, to);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return GetMove(i_Board); // בקשת קלט מחדש
            }
        }

        private Position ParsePosition(string i_Input)
        {
            if (i_Input.Length != 2)
            {
                throw new FormatException($"Invalid position '{i_Input}'. Please use a valid format like 'Fa'.");
            }

            char row = i_Input[0];
            char col = i_Input[1];

            int rowIndex = row - 'A'; // תרגום לשורה
            int colIndex = col - 'a'; // תרגום לעמודה

            if (rowIndex < 0 || rowIndex >= r_Board.Size || colIndex < 0 || colIndex >= r_Board.Size)
            {
                throw new ArgumentOutOfRangeException($"Position '{i_Input}' is out of bounds.");
            }

            return new Position(rowIndex, colIndex);
        }
    }

}
