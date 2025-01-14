using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F74121246_practice_5_2
{
    internal class Role
    {
        public string type; // 0 : Cardigan, 1 : Myrtle, 2 : Melantha, 3 : Shaw
        public int id;
        public int HP, MaxHp;
        public int ATK;
        public int DEF;
        public int cost;
        public int CD;
        public int CDnow;

        public Role(string type)
        {
            this.type = type;

            switch(type)
            {
                case "Cardigan":
                    id = 0;
                    HP = 2130; MaxHp = 2130;
                    ATK = 305;
                    DEF = 475;
                    cost = 18;
                    CD = 20; CDnow = 20;
                    break;
                case "Myrtle":
                    id = 1;
                    HP = 1565; MaxHp = 1565;
                    ATK = 520;
                    DEF = 300;
                    cost = 10;
                    CD = 22; CDnow = 22;
                    break;
                case "Melantha":
                    id = 2;
                    HP = 2745; MaxHp = 2745;
                    ATK = 738;
                    DEF = 155;
                    cost = 15;
                    CD = 40; CDnow = 40;
                    break;
                case "Shaw":
                    id = 3;
                    HP = 1785; MaxHp = 1785;
                    ATK = 580;
                    DEF = 365;
                    cost = 19;
                    CD = 5; CDnow = 5;
                    break;
            }
        }
    }
}
