/*Camryn Botha 2010384
 * GADE6112 PoE Resubmission
 * 20/01/2021*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20103804_Botha_GADE6112_Resub
{
    //Task 2 - Q2.1
    abstract class Item : Tile
    {
        public Item (int x, int y) : base (x, y, TileType.ITEM)
        {
            //empty constructor
        }

        //virtual methods can be overridden
        public abstract override string ToString();
    }
}
