/*Camryn Botha 2010384
 * GADE6112 PoE Resubmission
 * 04/01/2021*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20103804_Botha_GADE6112_Resub
{
    //Task 1 - Q2.1
    abstract class Tile
    {
        protected int x;
        protected int y;
        protected TileType type;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public TileType Type
        {
            get { return type; }
        }

        public Tile(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }
    }

    public enum TileType
    {
        HERO,
        ENEMY,
        GOLD,
        WEAPON,
        OBSTACLE,
        ITEM,
        EMPTY
    }
}
