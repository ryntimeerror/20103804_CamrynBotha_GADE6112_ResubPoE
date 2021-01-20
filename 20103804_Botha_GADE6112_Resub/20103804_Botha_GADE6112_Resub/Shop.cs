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
    //Question 2.5 - PoE


    class Shop
    {
        private Weapon[] weapArry = new Weapon[2];
        private Random rando;
        private Character character;
        Weapon weapon;

        public Shop(Character character)
        {
            character = this.character;
            int randoNum = 0;

            for (int i = 0; i > 3; i++)
            {
                rando = new Random();
                randoNum = rando.Next(1, 5);

                // weapArry[i] = RandomWeapon((Weapon)randoNum); //why isn't it working? grr
            }
        }

        private string RandomWeapon(int weapReference)
        {
            //I can't figure this out but I'm tired and I have a migraine.
            string weapon;

            switch (weapReference)
            {
                case 1:
                    weapon = "Dagger";
                    break;
                case 2:
                    weapon = "Longsword";
                    break;
                case 3:
                    weaponString = "Rifle";
                    break;
                case 4:
                    weaponString = "Longbow";
                    break;
                default:
                    weaponString = "Error 404";
                    break;
            }

            return weaponString;
        }

        public bool CanBuy(int num) // * cries in C# * - but i think it's right tho?
        {
            Gold gold = new Gold(0, 0);
            MeleeType meleeType;
            RangedType rangedType;

            if (weapArry[num] == "Dagger")
            {
                meleeType = MeleeType.DAGGER;
                MeleeWeapon meleeWeapon = new MeleeWeapon(0, 0, (int)meleeType);
                weapon = meleeWeapon;

                if (meleeWeapon.Cost < gold.GoldAmount)
                {
                    return true;
                }
            }
            else if (weapArry[num] == "Longsword")
            {
                meleeType = MeleeType.LONGSWORD;
                MeleeWeapon meleeWeapon = new MeleeWeapon(0, 0, (int)meleeType);
                weapon = meleeWeapon;

                if (meleeWeapon.Cost < gold.GoldAmount)
                {
                    return true;
                }
            }
            else if (weapArry[num] == "Rifle")
            {
                rangedType = RangedType.RIFLE;
                RangedWeapon rangedWeapon = new RangedWeapon(0, 0, (int)rangedType);
                weapon = rangedWeapon;

                if (rangedWeapon.Cost < gold.GoldAmount)
                {
                    return true;
                }
            }
            else if (weapArry[num] == "Longbow")
            {
                rangedType = RangedType.LONGBOW;
                RangedWeapon rangedWeapon = new RangedWeapon(0, 0, (int)rangedType);
                weapon = rangedWeapon;

                if (rangedWeapon.Cost < gold.GoldAmount)
                {
                    return true;
                }
            }
            return false;
        }

        /*public void Buy(int num) //i am aware that none of this is correct but i'm trying, ok?
        {
            //how to know what weapon they're trying to buy? wtf?

            num = weapon.Cost; //i'm almost certain this isn't what i'm supposed to do...

            Gold gold = new Gold(0, 0);

            gold.GoldAmount -= num; //had to add a setter to the Gold class to change the purse am

            //updating the label? idk
            //lblGoldPurse.Caption = Convert.ToString(gold.GoldAm);

            //how tf do i pickup?
            // * is definitely not crying* 
        }*/
    }
}
