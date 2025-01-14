using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_4_1
{
    public partial class RandomColor : Form
    {
        public Form1 Form1;
        public RandomColor(Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
        }

        void ChangeLocation()
        {
            btnCheck.Left = (this.ClientSize.Width - btnCheck.Width) / 2;
            btnCheck.Top = (this.ClientSize.Height - btnCheck.Height) / 2;
        }

        private void RandomColor_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            this.BackColor = randomColor;
            Form1.BackColor = randomColor;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
