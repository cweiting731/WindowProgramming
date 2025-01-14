using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_5_2
{
    internal class Enemy
    {
        public Label label;
        public int HP;
        public int ATK;
        public int DEF;
        public bool isStop;

        public Enemy(int  HP, int left, int Top)
        {
            this.HP = HP;
            isStop = false;
            ATK = 600;
            DEF = 300;

            label = new Label();
            label.Text = HP.ToString();
            label.AutoSize = false;
            label.Size = new System.Drawing.Size(50, 50);
            label.Font = new System.Drawing.Font("微軟正黑體", 12);
            label.BackColor = System.Drawing.Color.Yellow;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Left = left - label.Width/2;
            label.Top = Top - label.Height/2;
            
        }
    }
}
