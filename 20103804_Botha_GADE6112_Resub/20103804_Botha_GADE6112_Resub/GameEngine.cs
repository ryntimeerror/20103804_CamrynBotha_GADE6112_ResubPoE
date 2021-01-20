/*Camryn Botha 2010384
 * GADE6112 PoE Resubmission
 * 19/01/2021*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace _20103804_Botha_GADE6112_Resub
{
    [System.Serializable]
    //Task 1 - Q3.3
    class GameEngine
    {
        const string SAVE_FILE_NAME = "gameSave.txt";
        Map map;

        public string View
        {
            get { return map.ToString(); }
        }

        public string HeroStats
        {
            get { return map.Hero.ToString(); }
        }

        public GameEngine()
        {
            map = new Map(10, 20, 10, 20, 10, 6);
        }

        public void Save()
        {
            FileStream outFile = new FileStream(
                SAVE_FILE_NAME, FileMode.Create, FileAccess.Write
                );

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(outFile, map);

            outFile.Close();
        }

        public void Load()
        {
            FileStream inFile = new FileStream(
                SAVE_FILE_NAME, FileMode.Open, FileAccess.Read
                );

            BinaryFormatter bf = new BinaryFormatter();

            map = (Map)bf.Deserialize(inFile);           

            inFile.Close();
        }

        public bool MovePlayer(Movement desiredMove)
        {
            Movement allowedMove = map.Hero.ReturnMove(desiredMove);
            map.Hero.Move(allowedMove);
            
            EnemiesMove();
            map.Update();
            EnemiesAttack();

            Item item = map.GetItemAtPosition(map.Hero.X, map.Hero.Y);

            if(item != null)
            {
                map.Hero.PickUp(item);
            }          

            if(allowedMove == Movement.NO_MOVEMENT)
            {
                return false;
            }

            return true;
        }

        public string PlayerAttack(AttackDirection direction)
        {
            //for some reason I can only attack up and down but not left and right?

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
                EnemiesAttack();
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

        void EnemiesMove()
        {
            foreach(Enemy enemy in map.Enemies)
            {
                if (enemy.isDead())
                {
                    continue;
                }

                Movement allowedMove = enemy.ReturnMove();
                enemy.Move(allowedMove);
            }
        }

        void EnemiesAttack()
        {
            foreach (Enemy enemy in map.Enemies)
            {
                for(int i = 0; i < enemy.Vision.Length; i++)
                {
                    //nothing there so skip
                    if(enemy.Vision[i] == null || enemy.isDead())
                    {
                        continue;
                    }

                    //gob attack - only attacks hero
                    if(enemy is Goblin && enemy.Vision[i] is Hero)
                    {
                        enemy.Attack(map.Hero);
                    }

                    //mage attack - attacks any character
                    if(enemy is Mage && enemy.Vision[i] is Character)
                    {
                        Character target = (Character)enemy.Vision[i];
                        enemy.Attack(target);
                    }
                }
            }
        }

    }
}
