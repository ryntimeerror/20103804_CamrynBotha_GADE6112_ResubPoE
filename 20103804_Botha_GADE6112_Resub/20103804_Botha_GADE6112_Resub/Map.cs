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
    [System.Serializable]
    class Map
    {
        Tile[,] map;
        Hero hero;
        Enemy[] enemies;
        Item[] items;

        int width;
        int height;

        Random random = new Random();

        public Hero Hero
        {
            get { return hero; }
        }

        public Enemy[] Enemies
        {
            get { return enemies; }
        }
        //Task 1 - Q3.2
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numItems)
        {
            width = random.Next(minWidth, maxWidth + 1);
            height = random.Next(minHeight, maxHeight + 1);

            map = new Tile[width, height];
            enemies = new Enemy[numEnemies];
            items = new Item[numItems];

            InitializeMap();

            //create hero
            hero = (Hero)Create(TileType.HERO);

            //create enemies (gob/mage/leader)
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = (Enemy)Create(TileType.ENEMY);
            }

            //create items (gold)
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = (Item)Create(TileType.GOLD);
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
                if (random.Next(0,2) == 1)
                {
                    map[x, y] = new Goblin(x, y);
                }
                else
                {
                    map[x, y] = new Mage(x, y);
                }                
            }
            else if(type == TileType.GOLD)
            {
                map[x, y] = new Gold(x, y);
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

            for(int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                
                if(item != null)
                {
                    map[item.X, item.Y] = items[i];
                }
                
            }

            UpdateVision();
        }

        public Item GetItemAtPosition(int x, int y)
        {
            //[g, g, null, g, g, null] >> example array

            for(int i = 0; i < items.Length; i++)
            {    
                //enure we don't try to use null as an item
                if (items[i] == null)
                {
                    continue;
                }

                //have we found the item that we're looking for
                if (items[i].X == x && items[i].Y == y)
                {
                    Item tempItem = items[i];
                    items[i] = null;
                    return tempItem;

                    /* ^^ have to put item into temp var so as 
                     * not to return null while still setting 
                     * the item to null*/
                }
            }

            return null;
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
                        else
                        {
                            if (enemy is Goblin)
                            {
                                mapString += 'G';
                            }
                            else if(enemy is Mage)
                            {
                                mapString += 'M';
                            }
                        }
                    }
                    else if(currentType == TileType.ITEM)
                    {
                        if(map[x,y] is Gold)
                        {
                            //explicit cast from Tile to Gold
                            Gold gold = (Gold)map[x, y];
                            mapString += gold.GoldAmount;
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

