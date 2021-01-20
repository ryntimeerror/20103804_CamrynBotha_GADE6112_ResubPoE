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
    //Task 2 - Q2.2
    [System.Serializable]
    class Gold : Item
    {
        //backing field aka member var aka field
        int goldAmount;
        static Random random = new Random();

        //accessor aka property aka getter and setter
        public int GoldAmount
        {
            get { return goldAmount; }
        }

        public Gold (int x, int y) : base (x, y)
        {
            //random maxVal is exclusive
            goldAmount = random.Next(1, 6);
        }

        public override string ToString()
        {
            return "";
        }
    }
}
