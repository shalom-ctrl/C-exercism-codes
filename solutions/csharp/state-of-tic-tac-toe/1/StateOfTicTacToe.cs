using System;
using System.Linq;

public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe
{
    private readonly string[] _board;
    private readonly int _xCount;
    private readonly int _oCount;

    public TicTacToe(string[] rows)
    {
        _board = rows;
        _xCount = rows.Sum(r => r.Count(c => c == 'X'));
        _oCount = rows.Sum(r => r.Count(c => c == 'O'));
    }

    public State State
    {
        get
        {
            // 1. Basic Turn Order Validation
            if (_oCount > _xCount || _xCount > _oCount + 1)
            {
                return State.Invalid;
            }

            bool xWins = HasWon('X');
            bool oWins = HasWon('O');

            // 2. Logic Validation (Can't both win, can't play after a win)
            if (xWins && oWins) return State.Invalid;
            if (xWins && _xCount == _oCount) return State.Invalid;
            if (oWins && _xCount > _oCount) return State.Invalid;

            // 3. Determine Result
            if (xWins || oWins) return State.Win;
            if (_xCount + _oCount == 9) return State.Draw;
            
            return State.Ongoing;
        }
    }

    private bool HasWon(char player)
    {
        for (int i = 0; i < 3; i++)
        {
            // Rows
            if (_board[i][0] == player && _board[i][1] == player && _board[i][2] == player) return true;
            // Columns
            if (_board[0][i] == player && _board[1][i] == player && _board[2][i] == player) return true;
        }

        // Diagonals
        if (_board[0][0] == player && _board[1][1] == player && _board[2][2] == player) return true;
        if (_board[0][2] == player && _board[1][1] == player && _board[2][0] == player) return true;

        return false;
    }
}