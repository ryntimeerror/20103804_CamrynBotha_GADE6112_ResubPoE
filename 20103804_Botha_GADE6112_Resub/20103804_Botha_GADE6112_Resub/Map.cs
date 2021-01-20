/*Camryn Botha 2010384
 * GADE6112 PoE Resubmission
 * 19/01/2021*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20103804_Botha_GADE6112_Resub
{
    //Task 1 - Q3.1
    class Map
    {
        Tile[,] map;
        Hero hero;
        Enemy[] enemies;

        int width;
        int height;

        Random random = new Random();

        public Hero Hero
        {
            get { return hero; }
        }

        //Task 1 - Q3.2
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies)
        {
            width = random.Next(minWidth, maxWidth + 1);
            height = random.Next(minHeight, maxHeight + 1);

            map = new Tile[width, height];
            enemies = new Enemy[numEnemies];

            InitializeMap();

            hero = (Hero)Create(TileType.HERO);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = (Enemy)Create(TileType.ENEMY);
            }

            UpdateVision();
        }

        private void InitializeMap()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        map[x, y] = new Obstacle(x, y);
                    }
                    else
                    {
                        map[x, y] = new EmptyTile(x, y);
                    }
                }
            }
        }

        private Tile Create(TileType type)
        {
            int x = random.Next(0, width);
            int y = random.Next(0, height);

            while (map[x, y].Type != TileType.EMPTY)
            {
                x = random.Next(0, width);
                y = random.Next(0, height);
            }

            if (type == TileType.HERO)
            {
                map[x, y] = new Hero(x, y, 10);
            }
            else if (type == TileType.ENEMY)
            {
                map[x, y] = new Goblin(x, y);
            }

            return map[x, y];
        }

        public void UpdateVision()
        {
            UpdateCharacterVision(hero);

            for (int i = 0; i < enemies.Length; i++)
            {
                UpdateCharacterVision(enemies[i]);
            }
        }

        private void UpdateCharacterVision(Character character)
        {
            Tile tileUp = null;
            Tile tileDown = null;
            Tile tileLeft = null;
            Tile tileRight = null;

            if (character.Y - 1 >= 0)
            {
                tileUp = map[character.X, character.Y - 1];
            }

            if (character.Y + 1 < height)
            {
                tileDown = map[character.X, character.Y + 1];
            }

            if (character.X + 1 < width)
            {
                tileRight = map[character.X + 1, character.Y];
            }

            if (character.X - 1 >= 0)
            {
                tileLeft = map[character.X - 1, character.Y];
            }

            character.SetVision(tileUp, tileDown, tileLeft, tileRight);
        }

        public void Update()
        {
            InitializeMap();

            map[hero.X, hero.Y] = hero;

            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy currentEnemy = enemies[i];
                map[currentEnemy.X, currentEnemy.Y] = enemies[i];
            }

            UpdateVision();
        }

        public override string ToString()
        {
            string mapString = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    TileType currentType = map[x, y].Type;

                    if (Hero.X == x && Hero.Y == y)
                    {
                        mapString += 'H';
                        continue;
                    }

                    if (currentType == TileType.ENEMY)
                    {
                        Enemy enemy = (Enemy)map[x, y];
                        if (enemy.isDead())
                        {
                            mapString += "\u2020";
                        }
                        else if (currentType == TileType.ENEMY)
                        {
                            mapString += 'G';
                        }
                    }                    
                    else if (currentType == TileType.EMPTY)
                    {
                        mapString += '.';
                    }
                    else if (currentType == TileType.OBSTACLE)
                    {
                        mapString += 'X';
                    }                    
                }
                mapString += "\n";
            }
            return mapString;
        }
    }
}

