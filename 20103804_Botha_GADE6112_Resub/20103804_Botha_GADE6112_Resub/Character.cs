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
    //Task 1 - Q2.2
    abstract class Character : Tile
    {
        protected int hp;
        protected int maxHP;
        protected int damage;
        protected Tile[] vision;
        protected Movement movement;
        protected int goldPurse = 0;

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int MaxHP
        {
            get { return maxHP; }
        }

        public Tile[] Vision
        {
            get { return vision; }
        }

        public int GoldPurse
        {
            get { return goldPurse; }
            //set { goldPurse = value; }
        }

        public Character(int x, int y, TileType type):base(x, y, type)
        {
            vision = new Tile[4]; // 0 = up, 1 = down, 2 = left, 3 = right
        }

        //Task 1 - Q2.3
        public virtual void Attack(Character target)
        {
            target.HP -= this.damage;
        }

        public bool isDead()
        {
            return hp <= 0;
        }

        public virtual bool CheckRange(Character target)
        {
            return DistanceTo(target) <= 1;
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(x - target.X) + Math.Abs(y - target.Y);
        }

        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.UP: y -= 1; 
                    break;
                case Movement.DOWN: y += 1; 
                    break;
                case Movement.LEFT: x -= 1;
                    break;
                case Movement.RIGHT: x += 1;
                    break;
            }
            //break jumps t0 this part of our method
        }

        public void SetVision(Tile up, Tile down, Tile left, Tile right)
        {
            vision[0] = up;
            vision[1] = down;
            vision[2] = left;
            vision[3] = right;
        }

        public void PickUp(Item item)
        {
            if(item is Gold)
            {
                Gold gold = (Gold)item;
                goldPurse += gold.GoldAmount;
            }
        }

        public abstract Movement ReturnMove(Movement move = 0);

        public abstract override string ToString();
    }

    //Task 1 - Q2.2
    public enum Movement
    {
        NO_MOVEMENT, //0
        UP, //1
        DOWN, //2
        LEFT, //3
        RIGHT //4
    }

    public enum AttackDirection
    {
        UP, //0
        DOWN, //1
        LEFT, //2
        RIGHT //3
    }

}
