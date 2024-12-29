using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class Board
    {
        private const int k_DefaultSize = 10;
        private int m_Size;
        private Piece[,] m_Grid;
        private Move m_LastMove; // שמירת המהלך האחרון

        public int Size
        {
            get { return m_Size; }
        }

        public Board(int i_Size = k_DefaultSize)
        {
            m_Size = i_Size;
            m_Grid = new Piece[m_Size, m_Size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < m_Size; row++)
            {
                for (int col = 0; col < m_Size; col++)
                {
                    if ((row + col) % 2 != 0)
                    {
                        if (row < m_Size / 2 - 1)
                        {
                            m_Grid[row, col] = new Piece(ePieceType.O, new Position(row, col));
                        }
                        else if (row > m_Size / 2)
                        {
                            m_Grid[row, col] = new Piece(ePieceType.X, new Position(row, col));
                        }
                    }
                }
            }
        }

        public Piece GetPieceAt(Position i_Position)
        {
            // בדיקה אם המיקום נמצא בגבולות הלוח
            if (i_Position.Row < 0 || i_Position.Row >= m_Size || i_Position.Col < 0 || i_Position.Col >= m_Size)
            {
                throw new ArgumentOutOfRangeException("Position is out of bounds.");
            }

            return m_Grid[i_Position.Row, i_Position.Col];
        }

        private bool IsPositionValid(Position i_Position)
        {
            return i_Position.Row >= 0 && i_Position.Row < m_Size &&
                   i_Position.Col >= 0 && i_Position.Col < m_Size;
        }

        public bool IsMoveValid(Position i_From, Position i_To, Player i_CurrentPlayer)
        {
            if (!IsPositionValid(i_From) || !IsPositionValid(i_To))
            {
                return false; // המיקום מחוץ לטווח הלוח
            }

            Piece piece = m_Grid[i_From.Row, i_From.Col];
            if (piece == null || piece.Type != i_CurrentPlayer.PieceType)
            {
                return false; // אין כלי במיקום ההתחלה
            }

            // תנועה חוקית תלויה בהבדלים בין השורות והעמודות
            int rowDiff = Math.Abs(i_To.Row - i_From.Row);
            int colDiff = Math.Abs(i_To.Col - i_From.Col);

            if (rowDiff == 1 && colDiff == 1)
            {
                return m_Grid[i_To.Row, i_To.Col] == null; // יעד חייב להיות ריק
            }
            else if (rowDiff == 2 && colDiff == 2) // מהלך "אכילה"
            {
                int midRow = (i_From.Row + i_To.Row) / 2;
                int midCol = (i_From.Col + i_To.Col) / 2;
                Piece middlePiece = m_Grid[midRow, midCol];

                return middlePiece != null && middlePiece.Type != piece.Type; // חייב להיות כלי יריב באמצע
            }

            return false; // מהלך לא חוקי
        }


        public void MovePiece(Position i_From, Position i_To)
        {
            if (IsMoveValid(i_From, i_To))
            {
                Piece piece = m_Grid[i_From.Row, i_From.Col];
                m_Grid[i_From.Row, i_From.Col] = null;
                m_Grid[i_To.Row, i_To.Col] = piece;
                piece.Position = i_To;

                // אם המהלך כולל אכילה, נסיר את הכלי היריב
                if (Math.Abs(i_From.Row - i_To.Row) == 2 && Math.Abs(i_From.Col - i_To.Col) == 2)
                {
                    int midRow = (i_From.Row + i_To.Row) / 2;
                    int midCol = (i_From.Col + i_To.Col) / 2;
                    m_Grid[midRow, midCol] = null; // הסרת הכלי היריב
                }

                // שמירת המהלך האחרון
                SetLastMove(new Move(i_From, i_To));

                // בדיקה אם יש צורך להמיר למלך
                CheckAndPromote(i_To);
            }
            else
            {
                throw new InvalidOperationException($"Move from {i_From} to {i_To} is invalid.");
            }
        }



        public void PrintBoard()
        {
            Console.WriteLine("   " + string.Join("   ", Enumerable.Range(0, m_Size).Select(i => (char)('A' + i))));

            Console.WriteLine("  +" + string.Join("+", Enumerable.Repeat("---", m_Size)) + "+");

            for (int row = 0; row < m_Size; row++)
            {
                Console.Write($"{(char)('a' + row)} |");
                for (int col = 0; col < m_Size; col++)
                {
                    Piece currentPiece = m_Grid[row, col];
                    Console.Write($" {currentPiece?.ToString() ?? " "} |");
                }
                Console.WriteLine();
                Console.WriteLine("  +" + string.Join("+", Enumerable.Repeat("---", m_Size)) + "+");
            }

            if (m_LastMove != null)
            {
                Console.WriteLine($"Last move: {m_LastMove.From} > {m_LastMove.To}");
            }
        }

        public List<Position> GetValidMoves(Position i_From)
        {
            List<Position> validMoves = new List<Position>();
            Position[] directions = { new Position(-1, -1), new Position(-1, 1), new Position(1, -1), new Position(1, 1) };

            foreach (Position direction in directions)
            {
                Position to = new Position(i_From.Row + direction.Row, i_From.Col + direction.Col);
                if (IsMoveValid(i_From, to))
                {
                    validMoves.Add(to);
                }
            }

            return validMoves;
        }

        public void SetLastMove(Move i_Move)
        {
            m_LastMove = i_Move;
        }

        public void CheckAndPromote(Position i_Position)
        {
            Piece piece = GetPieceAt(i_Position);
            if (piece == null || piece.IsKing)
            {
                return; // אין כלי או שהכלי כבר מלך
            }

            if (piece.Type == ePieceType.X && i_Position.Row == 0)
            {
                piece.PromoteToKing();
                Console.WriteLine($"Piece at {i_Position} promoted to King!");
            }
            else if (piece.Type == ePieceType.O && i_Position.Row == m_Size - 1)
            {
                piece.PromoteToKing();
                Console.WriteLine($"Piece at {i_Position} promoted to King!");
            }
        }

    }


}
