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
    //Task 1 - Q2.4
    [System.Serializable]
    abstract class Enemy : Character
    {
        static protected Random random;

        public Enemy(int x, int y, int damage, int hp) : base(x, y, TileType.ENEMY)
        {
            this.damage = damage;
            this.hp = hp;
            this.maxHP = hp; //maxHP will be equal to intial HP value
            random = new Random();
        }

        public override string ToString()
        {
            return GetType() + " at [ " + x + "," + y + " ] ( " + damage + " )";
        }
    }
}
