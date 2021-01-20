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
    //Task 1 - Q3.3
    class GameEngine
    {
        Map map;

        public string View
        {
            get { return map.ToString(); }
        }

        public GameEngine()
        {
            map = new Map(6, 12, 6, 12, 10);
        }

        public bool MovePlayer(Movement desiredMove)
        {
            Movement allowedMove = map.Hero.ReturnMove(desiredMove);
            map.Hero.Move(allowedMove);
            map.Update();

            if(allowedMove == Movement.NO_MOVEMENT)
            {
                return false;
            }

            return true;
        }

        public string PlayerAttack(AttackDirection direction)
        {
            int visionIndex = (int)direction;
            string failMessage = "Hero attack failed";

            if(map.Hero.Vision[visionIndex].Type == TileType.ENEMY)
            {
                Enemy enemy = (Enemy)map.Hero.Vision[visionIndex];
                if (enemy.isDead())
                {
                    return failMessage;
                }

                map.Hero.Attack(enemy);
                map.Update();

                if (enemy.isDead())
                {
                    return "Hero killed enemy!";
                }

                return "Hero attacked enemy \n"
                       + "Enemy HP: " + enemy.HP + "/" + enemy.MaxHP;
            }
            return failMessage;
        }

    }
}
