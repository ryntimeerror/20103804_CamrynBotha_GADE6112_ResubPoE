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
    //Question 2.2 - PoE
    class MeleeWeapon : Weapon
    {
        public MeleeWeapon(MeleeType melType, int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;

            if (melType == MeleeType.DAGGER)
            {
                durability = 10;
                cost = 3;
                damage = 3;
                weapName = "Dagger";
            }
            else if (melType == MeleeType.LONGSWORD)
            {
                durability = 6;
                cost = 5;
                damage = 4;
                weapName = "Longsword";
            }
            range = 1;
        }

        public override string ToString()
        {
            return weapName;
        }
    }

    public enum MeleeType
    {
        DAGGER,
        LONGSWORD
    }
}