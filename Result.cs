using System;
namespace RenjuProject
{
    public class Result
    {
        string _player;
        int _horizontal;
        int _vertical;

        public Result(string player)
        {
            _player = player;
        }

        public Result(string player, int horizontal, int vertical)
        {
            _player = player;
            _horizontal = horizontal;
            _vertical = vertical;
        }

        public string GetStringResult()
        {
            if (_player == "0")
                return _player;
            return _player + '\n' + _horizontal + ' ' + _vertical;
        }
    }
}
