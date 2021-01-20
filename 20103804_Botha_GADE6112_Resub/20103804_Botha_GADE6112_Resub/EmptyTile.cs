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
    [System.Serializable]
    class EmptyTile : Tile
    {
        public EmptyTile (int x, int y) : base (x, y, TileType.EMPTY)
        {
            //empty constructor
        }
    }
}
