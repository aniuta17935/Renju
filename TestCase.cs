
using System.Collections.Generic;
using System.Linq;

namespace Renju
{
    public class TestCase
    {
        List<List<string>> _cells;
        string _result;
        int _resultVertical;
        int _resultHorizontal;

        public string ReturnResult()
        {
            if (this._result == "0")
                return _result;
            else
                return _result + '\n' + _resultVertical + ' ' + _resultHorizontal;
        }


        public TestCase(List<string> lines)
        {
            _cells = new List<List<string>>();
            foreach (string line in lines)
            {
                List<string> newLine = new List<string>(line.Split(' '));
                this._cells.Add(newLine);
            }
            this._result = "0";
        }

        public bool CheckTest()
        {
            bool length = false;
            bool content = false;
            foreach (List<string> row in _cells)
            {
                length = row.Capacity == 19;
                content = row.All(x => x == "0" || x == "1" || x == "2");
            }
            return length && content;
        }


        public void Process()
        {
            CheckRow();
            CheckColumn();
            CheckRightDiagonal();
            checkLeftDiagonal();
        }

        private bool CheckRow()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i][j + 1] == player && _cells[i][j + 2] == player && _cells[i][j + 3] == player && _cells[i][j + 4] == player)
                    {
                        if (j + 5 < 19 && _cells[i][j + 5] == player)
                            continue;
                        if (j - 1 >= 0 && _cells[i][j - 1] == player)
                            continue;
                        _resultVertical = i + 1;
                        _resultHorizontal = j + 1;
                        _result = player;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckColumn()
        {
            for (int j = 0; j < 19; j++)
            {
                for (int i = 0; i < 15; i++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i + 1][j] == player && _cells[i + 2][j] == player && _cells[i + 3][j] == player && _cells[i + 4][j] == player)
                    {
                        if (i + 5 < 19 && _cells[i + 5][j] == player)
                            continue;
                        if (i - 1 >= 0 && _cells[i - 1][j] == player)
                            continue;
                        _resultVertical = i + 1;
                        _resultHorizontal = j + 1;
                        _result = player;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckRightDiagonal()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i + 1][j + 1] == player && _cells[i + 2][j + 2] == player && _cells[i + 3][j + 3] == player && _cells[i + 4][j + 4] == player)
                    {
                        if (i + 5 < 19 && j + 5 < 19 && _cells[i + 5][j + 5] == player)
                            continue;
                        if (i - 1 >= 0 && j - 1 >= 0 && _cells[i - 1][j - 1] == player)
                            continue;
                        _resultVertical = i + 1;
                        _resultHorizontal = j + 1;
                        _result = player;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkLeftDiagonal()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 4; j < 19; j++)
                {
                    string player = _cells[i][j];
                    if (player != "0" && _cells[i + 1][j - 1] == player && _cells[i + 2][j - 2] == player && _cells[i + 3][j - 3] == player && _cells[i + 4][j - 4] == player)
                    {
                        if (i + 5 < 19 && j - 5 >= 0 && _cells[i + 5][j - 5] == player)
                            continue;
                        if (i - 1 >= 0 && j + 1 < 19 && _cells[i - 1][j + 1] == player)
                            continue;
                        _resultVertical = i + 1 + 4;
                        _resultHorizontal = j + 1 - 4;
                        _result = player;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}