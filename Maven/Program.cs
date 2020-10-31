using System;
using System.Linq;

namespace Maven
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution(4, "1B 2C,2D 4D", "2B 2D 3D 4D 4A");
        }

        public static  string Solution(int size, string ships, string hits)
        {
            var sunkenShips = 0;
            var hitShips = 0;
            const char PAIR_SEPARATOR = ' ';
            const char SHIP_SEPARATOR = ',';
            const bool IS_TAKEN = true;

            // excuse me but this is totally wrong to give absolutely outdated versions of .NET

            // initialize the board game with data to paly with
            var gameBoard = new bool[size, size]; // size of the board game
            var hitList = hits.Split(new[] { PAIR_SEPARATOR }, StringSplitOptions.None); // {2B, 2D, 3D ... }

            Array.ForEach(hitList, hit =>
            {
                // hit = 2B
                var point = ConvertPoint(hit);
                gameBoard[point.X, point.Y] = IS_TAKEN;
            });

            // for every ship walk the board and count occupied areas of the ship
            var shipList = ships.Split(new[] { SHIP_SEPARATOR }, StringSplitOptions.None); // {1B 2C, 2D 4D ...}
            Array.ForEach(shipList, shipArea =>
            {
                //   BOARD
                //__________
                //   A B C D
                // 1   0 0     
                // 2   x 0 x  
                // 3       x
                // 4 x     x
                // _________

                // hit = 1B 2C
                var area = shipArea.Split(new[] { PAIR_SEPARATOR }, StringSplitOptions.None); // {1B, 2C} always two
                var shipCoordinates = area.Select(pos => ConvertPoint(pos)).ToArray();

                var shipSize = 0;
                var hitCount = 0;
                for (var x = shipCoordinates[0].X; x <= shipCoordinates[1].X; x++)
                {
                    shipSize++;
                    for (var y = shipCoordinates[0].Y; y <= shipCoordinates[1].Y; y++)
                    {
                        if (gameBoard[x, y])
                            hitCount++;
                    }
                };

                if (shipSize == hitCount)
                    sunkenShips++;
                else if (hitCount != 0)
                    hitShips++;
            });


            return $"{sunkenShips} {hitShips}";
        }

        private static GamePoint ConvertPoint(string coord)
        {
            var pos = Int32.Parse(coord.Remove(coord.Length - 1));
            return new GamePoint(pos-1, coord.Last() - 'A');
        }

        struct GamePoint
        {
            public int X;
            public int Y;

            public GamePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
