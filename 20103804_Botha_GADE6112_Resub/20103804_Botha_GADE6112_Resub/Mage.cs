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
    //Task 2 - Q2.3
    [System.Serializable]
    class Mage : Enemy
    {
        public Mage(int x, int y) : base (x, y, 5, 5)
        {
            //empty constructor
        }

        public override Movement ReturnMove(Movement move = Movement.NO_MOVEMENT)
        {
            return Movement.NO_MOVEMENT;
        }

        public override bool CheckRange(Character target)
        {
            //x = -1, 0, 1
            for (int tx = -1; tx <=1; tx++)
            {
                //y = -1, 0, 1
                for (int ty = -1; ty<=1; ty++)
                {
                    //won't check mage's position
                    if(tx == x && ty == y)
                    {
                        continue;
                    }

                    //if target matches the tile position
                    if(target.X == x + tx && target.Y == y + ty)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
