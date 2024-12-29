using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class RandomMoveStrategy : IStrategy
    {
        private static readonly Random s_Random = new Random();

        public Move GetMove(Board i_Board)
        {
            List<Move> validMoves = GetAllValidMoves(i_Board);
            if (validMoves.Count == 0)
            {
                throw new InvalidOperationException("No valid moves available for AI.");
            }

            int randomIndex = s_Random.Next(validMoves.Count);
            return validMoves[randomIndex];
        }

        public List<Move> GetAllValidMoves(Board i_Board)
        {
            List<Move> validMoves = new List<Move>();

            for (int row = 0; row < i_Board.Size; row++)
            {
                for (int col = 0; col < i_Board.Size; col++)
                {
                    Piece piece = i_Board.GetPieceAt(new Position(row, col));
                    if (piece != null && piece.Type == ePieceType.O) // דוגמה לשחקן O
                    {
                        List<Position> possibleMoves = GetValidDestinations(i_Board, new Position(row, col));
                        foreach (Position destination in possibleMoves)
                        {
                            validMoves.Add(new Move(new Position(row, col), destination));
                        }
                    }
                }
            }

            return validMoves;
        }

        private List<Position> GetValidDestinations(Board i_Board, Position i_From)
        {
            List<Position> destinations = new List<Position>();

            // בדוק תנועות אפשריות (אלכסוניות, קפיצה וכדומה)
            Position[] directions = { new Position(-1, -1), new Position(-1, 1), new Position(1, -1), new Position(1, 1) };

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
    }

}
