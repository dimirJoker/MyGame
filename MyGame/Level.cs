using System.Collections.Generic;

namespace MyGame
{
    internal class Level : Levels
    {
        public Level(int levelNum)
        {
            map = _mapsLs[levelNum];
            playerPosition = _playerPositionLs[levelNum];
            trapArr = _trapPositionLs[levelNum];
            enemyArr = _enemyPositionLs[levelNum];
        }
        private List<string[,]> _mapsLs = new List<string[,]>
        {
            new string[,]
            {
                {"▓","▓","▓","▓","▓",null},
                {"▓","☻"," ","$","▓",null},
                {"▓","▓","▓","▓","▓",null}
            },
            new string[,]
            {
                {"▓","▓","▓","","","",null},
                {"▓","$","▓","","","",null},
                {"▓"," ","▓","▓","▓","▓",null},
                {"▓"," "," "," ","☻","▓",null},
                {"▓","▓","▓","▓","▓","▓",null}
            },
            new string[,]
            {
                {" ","▓","▓","▓","","",null},
                {"▓","▓","$","▓","▓","▓",null},
                {"▓","☺"," "," ","☻","▓",null},
                {"▓"," "," "," ","▓","▓",null},
                {"▓","▓","▓","▓","▓","",null}
            },
            new string[,]
            {
                {"▓","▓","▓","▓","▓","▓","▓","","",null},
                {"▓","☻"," "," "," ","☺","▓","","",null},
                {"▓"," "," ","▓","▓"," ","▓","▓","▓",null},
                {"▓"," ","#","#","▓"," "," "," ","▓",null},
                {"▓"," ","#","#","☺"," ","▓","$","▓",null},
                {"▓"," ","▓","▓"," "," ","▓","▓","▓",null},
                {"▓","☺"," "," "," "," ","▓","","",null},
                {"▓","▓","▓","▓","▓","▓","▓","","",null}
            }
        };
        private List<Position> _playerPositionLs = new List<Position>
        {
        new Position {y=1, x=1},
        new Position {y=3, x=4},
        new Position {y=2, x=4},
        new Position {y=1, x=1}
        };
        private List<Position[]> _trapPositionLs = new List<Position[]>
        {
        null,
        new Position[] { new Position {y=3, x=2} },
        null,
            new Position[]
            {
                new Position {y=3, x=2},
                new Position {y=3, x=3},
                new Position {y=4, x=2},
                new Position {y=4, x=3}
            }
        };
        private List<Position[]> _enemyPositionLs = new List<Position[]>
        {
            null,
            null,
            new Position[] { new Position {y=2, x=1} },
            new Position[]
            {
            new Position {y=1, x=5},
            new Position {y=4, x=4},
            new Position {y=6, x=1}
            }
        };
    }
}