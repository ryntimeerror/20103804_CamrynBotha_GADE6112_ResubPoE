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

    //Question 2.1 - PoE
    abstract class Weapon : Item
    {
        protected int damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected string weapName;

        public int Damage
        {
            get { return damage; }
        }

        public virtual int Range
        {
            get { return range; }
        }

        public int Durability
        {
            get { return durability; }
        }

        public int Cost
        {
            get { return cost; }
        }

        public string WeapName
        {
            get { return weapName; }
        }

        public Weapon(int x, int y) : base(x, y)
        {
            this.type = TileType.WEAPON;
        }
    }
}
