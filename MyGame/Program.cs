using System;
using System.Collections.Generic;
using static MyGame.Levels;

namespace MyGame
{
    internal class Program
    {
        static bool runLevel;
        static void Main(string[] args)
        {
            var random = new Random();
            var levelLs = new List<Level>
            {
                new Level(0),
                new Level(1),
                new Level(2),
                new Level(3)
            };
            foreach (var level in levelLs)
            {
                runLevel = true;
                while (runLevel)
                {
                    PrintInstructions(); // done
                    Draw(level); // done
                    var keyInfo = Console.ReadKey();
                    MovePlayer(level, keyInfo.Key); // done
                    var validKey = KeyValidation(keyInfo.Key); // done
                    if (runLevel && validKey)
                    {
                        MoveEnemy(random, level); // done
                        SwitchTrap(level);
                    }
                }
            }
            Console.WriteLine();
            ClearLine();
            Console.Write("Well done, you win! Closing...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
        static void PrintInstructions()
        {
            Console.Clear();
            Console.WriteLine("Instructions:");
            Console.WriteLine("- press the arrow key to move;");
            Console.WriteLine("- collect the $;");
            Console.WriteLine("- avoid the others;");
            Console.WriteLine();
        }
        static void Draw(Level level)
        {
            foreach (var item in level.map)
            {
                if (item != null)
                {
                    Console.Write(item);
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
        static void MovePlayer(Level level, ConsoleKey key)
        {
            var newPosition = GetPlayerNewPosition(level, key); // done
            var validPosition = PlayerNewPositionValidation(level, newPosition); // done
            if (validPosition)
            {
                SetPlayerNewPosition(level, key); // done
            }
        }
        static string GetPlayerNewPosition(Level level, ConsoleKey key)
        {
            var y = level.playerPosition.y;
            var x = level.playerPosition.x;
            var map = level.map;
            switch (key)
            {
                default:
                    {
                        Console.WriteLine();
                        ClearLine();
                        Console.WriteLine();
                        Console.Write("Invalid input! The only arrow keys are allowed!");
                        Console.ReadKey(true);
                        return null;
                    }
                case ConsoleKey.UpArrow:
                    {
                        return map[y - 1, x];
                    }
                case ConsoleKey.DownArrow:
                    {
                        return map[y + 1, x];
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return map[y, x - 1];
                    }
                case ConsoleKey.RightArrow:
                    {
                        return map[y, x + 1];
                    }
            }
        }
        static bool PlayerNewPositionValidation(Level level, string newPosition)
        {
            var y = level.playerPosition.y;
            var x = level.playerPosition.x;
            switch (newPosition)
            {
                case " ":
                    {
                        return true;
                    }
                case "$":
                    {
                        Console.WriteLine();
                        Console.Write($"Level complete! Going next...");
                        Console.ReadKey(true);
                        runLevel = false;
                    }
                    break;
                case "#":
                    {
                        level.map[y, x] = "X";
                        PrintInstructions();
                        Draw(level);
                        Console.WriteLine();
                        Console.Write("It's a trap! You died!");
                        Console.ReadKey(true);
                        Console.WriteLine();
                        Environment.Exit(0);
                    }
                    break;
                case "☺":
                    {
                        level.map[y, x] = "X";
                        PrintInstructions();
                        Draw(level);
                        Console.WriteLine();
                        Console.Write("game");
                        Console.ReadKey(true);
                        Console.WriteLine();
                        Environment.Exit(0);
                    }
                    break;
            }
            return false;
        }
        static void SetPlayerNewPosition(Level level, ConsoleKey key)
        {
            var y = level.playerPosition.y;
            var x = level.playerPosition.x;
            var map = level.map;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    {
                        (map[y, x], map[y - 1, x]) = (map[y - 1, x], map[y, x]);
                        level.playerPosition.y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        (map[y, x], map[y + 1, x]) = (map[y + 1, x], map[y, x]);
                        level.playerPosition.y++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        (map[y, x], map[y, x - 1]) = (map[y, x - 1], map[y, x]);
                        level.playerPosition.x--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        (map[y, x], map[y, x + 1]) = (map[y, x + 1], map[y, x]);
                        level.playerPosition.x++;
                    }
                    break;
            }
        }
        static bool KeyValidation(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
            {
                return true;
            }
            return false;
        }
        static void MoveEnemy(Random random, Level level)
        {
            if (level.enemyArr != null)
            {
                foreach (var enemy in level.enemyArr)
                {
                    var d4 = random.Next(4);
                    var newPosition = GetEnemyNewPosition(level, enemy, d4); // done
                    var validPosition = EnemyNewPositionValidation(level, newPosition); // done
                    if (validPosition)
                    {
                        SetEnemyNewPosition(level, enemy, d4); // done
                    }
                }
            }
        }
        static string GetEnemyNewPosition(Level level, Position enemy, int d4)
        {
            var y = enemy.y;
            var x = enemy.x;
            var map = level.map;
            switch (d4)
            {
                case 0:
                    {
                        return map[y - 1, x];
                    }
                case 1:
                    {
                        return map[y + 1, x];
                    }
                case 2:
                    {
                        return map[y, x - 1];
                    }
                case 3:
                    {
                        return map[y, x + 1];
                    }
            }
            return null;
        }
        static bool EnemyNewPositionValidation(Level level, string newPosition)
        {
            switch (newPosition)
            {
                case " ":
                    {
                        return true;
                    }
                case "☻":
                    {
                        var y = level.playerPosition.y;
                        var x = level.playerPosition.x;
                        level.map[y, x] = "X";
                        PrintInstructions();
                        Draw(level);
                        Console.WriteLine();
                        Console.Write("You got caught by enemy! Game over!");
                        Console.ReadKey(true);
                        Console.WriteLine();
                        Environment.Exit(0);
                    }
                    break;
            }
            return false;
        }
        static void SetEnemyNewPosition(Level level, Position enemy, int d4)
        {
            var y = enemy.y;
            var x = enemy.x;
            var map = level.map;
            switch (d4)
            {
                case 0:
                    {
                        (map[y, x], map[y - 1, x]) = (map[y - 1, x], map[y, x]);
                        enemy.y--;
                    }
                    break;
                case 1:
                    {
                        (map[y, x], map[y + 1, x]) = (map[y + 1, x], map[y, x]);
                        enemy.y++;
                    }
                    break;
                case 2:
                    {
                        (map[y, x], map[y, x - 1]) = (map[y, x - 1], map[y, x]);
                        enemy.x--;
                    }
                    break;
                case 3:
                    {
                        (map[y, x], map[y, x + 1]) = (map[y, x + 1], map[y, x]);
                        enemy.x++;
                    }
                    break;
            }
        }
        static void SwitchTrap(Level level)
        {
            if (level.trapArr != null)
            {
                foreach (var trap in level.trapArr)
                {
                    var y = trap.y;
                    var x = trap.x;
                    var map = level.map;
                    switch (map[y, x])
                    {
                        case "#":
                            {
                                map[y, x] = " ";
                            }
                            break;
                        case " ":
                            {
                                map[y, x] = "#";
                            }
                            break;
                    }
                }
            }
        }
        static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}