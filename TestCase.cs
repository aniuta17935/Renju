
using System.Collections.Generic;
using System.Linq;

namespace Renju
{
    public class TestCase
    {
        public const int BoardSize = 19;
        List<List<string>> _cells;
        string _result;
        int _resultHorizontal;
        int _resultVertical;

        public string ReturnResult()
        {
            if (this._result == "0")
                return _result;
            return _result + '\n' + _resultHorizontal + ' ' + _resultVertical;
        }


        public TestCase(List<string> lines)
        {
            _cells = new List<List<string>>();
            foreach (string line in lines)
            {
                List<string> newLine = new(line.Split(' '));
                this._cells.Add(newLine);
            }
            this._result = "0";
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


        public void Process()
        {
            CheckRow();
            CheckColumn();
            CheckRightDiagonal();
            CheckLeftDiagonal();
        }

        private void CheckRow()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize - 4; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i][j + 1] == player && _cells[i][j + 2] == player && _cells[i][j + 3] == player && _cells[i][j + 4] == player)
                    {
                        if (j + 5 < BoardSize && _cells[i][j + 5] == player)
                            continue;
                        if (j - 1 >= 0 && _cells[i][j - 1] == player)
                            continue;
                        _resultHorizontal = i + 1;
                        _resultVertical = j + 1;
                        _result = player;
                    }
                }
            }
        }

        private void CheckColumn()
        {
            for (int j = 0; j < BoardSize; j++)
            {
                for (int i = 0; i < BoardSize - 4; i++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i + 1][j] == player && _cells[i + 2][j] == player && _cells[i + 3][j] == player && _cells[i + 4][j] == player)
                    {
                        if (i + 5 < BoardSize && _cells[i + 5][j] == player)
                            continue;
                        if (i - 1 >= 0 && _cells[i - 1][j] == player)
                            continue;
                        _resultHorizontal = i + 1;
                        _resultVertical = j + 1;
                        _result = player;
                    }
                }
            }
        }

        private void CheckRightDiagonal()
        {
            for (int i = 0; i < BoardSize - 4; i++)
            {
                for (int j = 0; j < BoardSize - 4; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i + 1][j + 1] == player && _cells[i + 2][j + 2] == player && _cells[i + 3][j + 3] == player && _cells[i + 4][j + 4] == player)
                    {
                        if (i + 5 < BoardSize && j + 5 < BoardSize && _cells[i + 5][j + 5] == player)
                            continue;
                        if (i - 1 >= 0 && j - 1 >= 0 && _cells[i - 1][j - 1] == player)
                            continue;
                        _resultHorizontal = i + 1;
                        _resultVertical = j + 1;
                        _result = player;
                    }
                }
            }
        }

        private void CheckLeftDiagonal()
        {
            for (int i = 0; i < BoardSize - 4; i++)
            {
                for (int j = 4; j < BoardSize; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i + 1][j - 1] == player && _cells[i + 2][j - 2] == player && _cells[i + 3][j - 3] == player && _cells[i + 4][j - 4] == player)
                    {
                        if (i + 5 < BoardSize && j - 5 >= 0 && _cells[i + 5][j - 5] == player)
                            continue;
                        if (i - 1 >= 0 && j + 1 < BoardSize && _cells[i - 1][j + 1] == player)
                            continue;
                        _resultHorizontal = i + 1 + 4;
                        _resultVertical = j + 1 - 4;
                        _result = player;
                    }
                }
            }
        }
    }
}