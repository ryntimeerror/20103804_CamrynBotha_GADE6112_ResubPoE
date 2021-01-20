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
    //Task 1 - Q2.5
    class Goblin : Enemy
    {
        public Goblin(int x, int y) : base (x, y, 1, 10)
        {
            //empty constructor
        }

        public override Movement ReturnMove(Movement move = Movement.NO_MOVEMENT)
        {
            int dir = random.Next(1, 5);

            int maxTries = 10;
            int tries = 0;
            
            while(vision[dir-1].Type != TileType.EMPTY && tries < maxTries)
            {
                dir = random.Next(1, 5);
                tries++;

                if (tries == maxTries)
                {
                    return Movement.NO_MOVEMENT;
                }
            }

            return (Movement)dir; //cast integer to type
        }
    }
}
