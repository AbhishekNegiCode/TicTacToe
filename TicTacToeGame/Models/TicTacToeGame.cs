using System;

namespace TicTacToeGame.Models
{
    public class TicTacToeModel
    {
        public char[] Board { get; set; }
        public char CurrentPlayer { get; set; }
        public bool GameOver { get; set; }
        public string Winner { get; set; }

        public TicTacToeModel()
        {
            Board = new char[9];
            for (int i = 0; i < 9; i++) Board[i] = ' ';
            CurrentPlayer = 'X';
            GameOver = false;
            Winner = string.Empty;
        }

        public void MakeMove(int index)
        {
            if (Board[index] == ' ' && !GameOver)
            {
                Board[index] = CurrentPlayer;
                if (CheckWinner())
                {
                    GameOver = true;
                    Winner = $"Player {CurrentPlayer} wins!";
                }
                else if (IsBoardFull())
                {
                    GameOver = true;
                    Winner = "It's a tie!";
                }
                else
                {
                    CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        public bool IsBoardFull()
        {
            foreach (var square in Board)
            {
                if (square == ' ') return false;
            }
            return true;
        }

        public bool CheckWinner()
        {
            int[][] winningCombinations = new int[][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };

            foreach (var combo in winningCombinations)
            {
                if (Board[combo[0]] == CurrentPlayer && Board[combo[1]] == CurrentPlayer && Board[combo[2]] == CurrentPlayer)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
