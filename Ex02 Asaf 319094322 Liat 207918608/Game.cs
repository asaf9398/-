using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public class Game
    {
        private readonly Board r_Board;
        private readonly Player[] r_Players;
        private IGameState m_CurrentState;
        private int m_CurrentPlayerIndex;
        public Board Board
        {
            get { return r_Board; }
        }
        public Game(Board i_Board, Player[] i_Players)
        {
            r_Board = i_Board;
            r_Players = i_Players;
            m_CurrentPlayerIndex = 0;
            m_CurrentState = new PlayerTurnState();
        }
        public void SetState(IGameState i_NewState)
        {
            m_CurrentState = i_NewState;
            m_CurrentState.Handle(this);
        }

        public Player GetCurrentPlayer()
        {
            return r_Players[m_CurrentPlayerIndex];
        }

        public void SwitchToNextPlayer()
        {
            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % r_Players.Length;
        }

        public void RecordMove(Move i_Move)
        {
            r_Board.SetLastMove(i_Move);
        }

    public bool IsGameOver()
        {
            // בדיקה אם אחד השחקנים אינו יכול לבצע מהלך
            foreach (Player player in r_Players)
            {
                if (HasValidMoves(player))
                {
                    return false;
                }
            }

            return true;
        }

        public Player GetWinner()
        {
            // בדיקה מי השחקן עם הכי הרבה כלים על הלוח
            int player1Pieces = CountPieces(r_Players[0]);
            int player2Pieces = CountPieces(r_Players[1]);

            if (player1Pieces > player2Pieces)
            {
                return r_Players[0];
            }
            else if (player2Pieces > player1Pieces)
            {
                return r_Players[1];
            }

            return null; // תיקו
        }

        private bool HasValidMoves(Player i_Player)
        {
            // בדיקה אם לשחקן יש מהלכים חוקיים
            for (int row = 0; row < r_Board.Size; row++)
            {
                for (int col = 0; col < r_Board.Size; col++)
                {
                    Piece piece = r_Board.GetPieceAt(new Position(row, col));
                    if (piece != null && piece.Type == (i_Player.IsHuman ? ePieceType.X : ePieceType.O))
                    {
                        if (r_Board.GetValidMoves(new Position(row, col)).Count > 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private int CountPieces(Player i_Player)
        {
            // סופרים את הכלים של השחקן על הלוח
            int count = 0;

            for (int row = 0; row < r_Board.Size; row++)
            {
                for (int col = 0; col < r_Board.Size; col++)
                {
                    Piece piece = r_Board.GetPieceAt(new Position(row, col));
                    if (piece != null && piece.Type == (i_Player.IsHuman ? ePieceType.X : ePieceType.O))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }

}
