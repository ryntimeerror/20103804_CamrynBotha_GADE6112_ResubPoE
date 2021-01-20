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
    //Question 2.3 - PoE
    class RangedWeapon : Weapon
    {
        public RangedWeapon(RangedType ranType, int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;

            if (ranType == RangedType.RIFLE)
            {
                durability = 3;
                range = 3;
                cost = 7;
                damage = 5;
                weapName = "Rifle";
            }
            else if (ranType == RangedType.LONGBOW)
            {
                durability = 4;
                range = 2;
                cost = 6;
                damage = 4;
                weapName = "Longbow";
            }
        }

        public override string ToString()
        {
            return weapName;
        }

        public override int Range => base.Range;
    }
    public enum RangedType
    {
        RIFLE,
        LONGBOW
    }
}
