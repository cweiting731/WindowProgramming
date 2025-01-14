using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_4_2
{
    public partial class ChangeColorPage : Form
    {
        Form1 form1;
        public ChangeColorPage(Form1 form1, string name)
        {
            InitializeComponent();
            this.form1 = form1;
            labelName.Text = name + "的背景色";
        }

        private void ChangeColorPage_Load(object sender, EventArgs e)
        {
            ChangeLocation();
            
        }

        private void ChangeLocation()
        {
            labelName.Left = (this.ClientSize.Width - labelName.Width) / 2;
            btnCheck.Left = (this.ClientSize.Width - btnCheck.Width) / 2;
            labelName.Top = this.ClientSize.Height / 3;
            btnCheck.Top = labelName.Top * 2;
        }

        private void ChangeColorPage_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        private void ChangeColorPage_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            this.BackColor = color;
            form1.BackColor = color;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    
}
