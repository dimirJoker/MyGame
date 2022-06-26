
using System.Collections;

namespace MyGame
{
    abstract class Levels  
    {
        public string[,] map;
        public Position playerPosition;
        public Position[] trapArr;
        public Position[] enemyArr;
        public class Position
        {
            public int y;
            public int x;
        }
    }
}