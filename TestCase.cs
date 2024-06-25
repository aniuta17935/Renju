
using System.Collections.Generic;
using System.Linq;
using RenjuProject;

namespace Renju
{
    public class TestCase
    {
        List<List<string>> _cells;
        Result _result;

        const int StepSize = MainClass.WinCount - 1;
        const int BoardSize = MainClass.BoardSize;


        public TestCase(List<string> lines)
        {
            _cells = new List<List<string>>();
            foreach (string line in lines)
            {
                List<string> newLine = new(line.Split(' '));
                _cells.Add(newLine);
            }
            _result = new Result("0");
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
                    if (player != "0" && _cells[i][j + 1] == player && _cells[i][j + 2] == player && _cells[i][j + 3] == player && _cells[i][j + 4] == player)
                    {
                        if (j + 5 < BoardSize && _cells[i][j + 5] == player)
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
                    if (player != "0" && _cells[i + 1][j] == player && _cells[i + 2][j] == player && _cells[i + 3][j] == player && _cells[i + 4][j] == player)
                    {
                        if (i + 5 < BoardSize && _cells[i + 5][j] == player)
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
                    if (player != "0" && _cells[i + 1][j + 1] == player && _cells[i + 2][j + 2] == player && _cells[i + 3][j + 3] == player && _cells[i + 4][j + 4] == player)
                    {
                        if (i + 5 < BoardSize && j + 5 < BoardSize && _cells[i + 5][j + 5] == player)
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
                    if (player != "0" && _cells[i + 1][j - 1] == player && _cells[i + 2][j - 2] == player && _cells[i + 3][j - 3] == player && _cells[i + 4][j - 4] == player)
                    {
                        if (i + 5 < BoardSize && j - 5 >= 0 && _cells[i + 5][j - 5] == player)
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