
using System.Collections.Generic;
using System.Linq;
using RenjuProject;

namespace Renju
{
    public class TestCase
    {
        List<List<string>> _cells;
        Result _result;

        const int WinCount = MainClass.WinCount;
        const int StepSize = WinCount - 1;
        const int BoardSize = MainClass.BoardSize;


        public TestCase(List<string> lines)
        {
            _cells = new List<List<string>>();
            foreach (string line in lines)
            {
                List<string> newLine = new(line.Split(' '));
                _cells.Add(newLine);
            }
            _result = new Result();
        }

        public string Process()
        {
            CheckRow();
            CheckColumn();
            CheckRightDiagonal();
            CheckLeftDiagonal();
            return _result.GetStringResult();
        }

        private void CheckRow()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize - StepSize; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && Enumerable.Range(1, StepSize).All(k => _cells[i][j + k] == player))
                    {
                        if (j + WinCount < BoardSize && _cells[i][j + WinCount] == player)
                            continue;
                        if (j - 1 >= 0 && _cells[i][j - 1] == player)
                            continue;
                        _result = new Result(player, i + 1, j + 1);
                    }
                }
            }
        }

        private void CheckColumn()
        {
            for (int j = 0; j < BoardSize; j++)
            {
                for (int i = 0; i < BoardSize - StepSize; i++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && Enumerable.Range(1, StepSize).All(k => _cells[i + k][j] == player))
                    {
                        if (i + WinCount < BoardSize && _cells[i + WinCount][j] == player)
                            continue;
                        if (i - 1 >= 0 && _cells[i - 1][j] == player)
                            continue;
                        _result = new Result(player, i + 1, j + 1);
                    }
                }
            }
        }

        private void CheckRightDiagonal()
        {
            for (int i = 0; i < BoardSize - StepSize; i++)
            {
                for (int j = 0; j < BoardSize - StepSize; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && Enumerable.Range(1, StepSize).All(k => _cells[i + k][j + k] == player))
                    {
                        if (i + WinCount < BoardSize && j + WinCount < BoardSize && _cells[i + WinCount][j + WinCount] == player)
                            continue;
                        if (i - 1 >= 0 && j - 1 >= 0 && _cells[i - 1][j - 1] == player)
                            continue;
                        _result = new Result(player, i + 1, j + 1);
                    }
                }
            }
        }

        private void CheckLeftDiagonal()
        {
            for (int i = 0; i < BoardSize - StepSize; i++)
            {
                for (int j = StepSize; j < BoardSize; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && Enumerable.Range(1, StepSize).All(k => _cells[i + k][j - k] == player))
                    {
                        if (i + WinCount < BoardSize && j - WinCount >= 0 && _cells[i + WinCount][j - WinCount] == player)
                            continue;
                        if (i - 1 >= 0 && j + 1 < BoardSize && _cells[i - 1][j + 1] == player)
                            continue;
                        _result = new Result(player, i + 1 + StepSize, j + 1 - StepSize);

                    }
                }
            }
        }

        public bool CheckTest()
        {
            foreach (List<string> row in _cells)
            {
                if (row.Count != BoardSize)
                    return false;
                if (!row.All(x => x == "0" || x == "1" || x == "2"))
                    return false;
            }
            return true;
        }
    }
}