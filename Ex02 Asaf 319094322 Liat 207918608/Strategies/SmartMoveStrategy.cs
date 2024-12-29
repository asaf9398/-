using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class SmartMoveStrategy : IStrategy
    {
        public Move GetMove(Board i_Board)
        {
            List<Move> captureMoves = GetCaptureMoves(i_Board);
            if (captureMoves.Count > 0)
            {
                return captureMoves[0]; // כרגע נבחר את המהלך הראשון (ניתן לשפר בהמשך)
            }

            // אם אין מהלכי אכילה, נבחר מהלך רגיל
            List<Move> validMoves = GetAllValidMoves(i_Board);
            if (validMoves.Count == 0)
            {
                throw new InvalidOperationException("No valid moves available for AI.");
            }

            return validMoves[0];
        }

        private List<Move> GetCaptureMoves(Board i_Board)
        {
            List<Move> captureMoves = new List<Move>();

            for (int row = 0; row < i_Board.Size; row++)
            {
                for (int col = 0; col < i_Board.Size; col++)
                {
                    Piece piece = i_Board.GetPieceAt(new Position(row, col));
                    if (piece != null && piece.Type == ePieceType.O) // דוגמה לשחקן O
                    {
                        List<Position> destinations = GetCaptureDestinations(i_Board, new Position(row, col));
                        foreach (Position destination in destinations)
                        {
                            captureMoves.Add(new Move(new Position(row, col), destination));
                        }
                    }
                }
            }

            return captureMoves;
        }

        private List<Position> GetCaptureDestinations(Board i_Board, Position i_From)
        {
            List<Position> destinations = new List<Position>();

            // בדיקת מהלכי אכילה (קפיצה מעל יריב)
            Position[] directions = { new Position(-2, -2), new Position(-2, 2), new Position(2, -2), new Position(2, 2) };

            foreach (Position direction in directions)
            {
                Position to = new Position(i_From.Row + direction.Row, i_From.Col + direction.Col);
                if (i_Board.IsMoveValid(i_From, to))
                {
                    destinations.Add(to);
                }
            }

            return destinations;
        }

        private List<Move> GetAllValidMoves(Board i_Board)
        {
            // שימוש באותה שיטה כמו ב-RandomMoveStrategy
            RandomMoveStrategy randomStrategy = new RandomMoveStrategy();
            return randomStrategy.GetAllValidMoves(i_Board);
        }
    }

}
