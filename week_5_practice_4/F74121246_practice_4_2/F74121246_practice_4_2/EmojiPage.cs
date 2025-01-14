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
    public partial class EmojiPage : Form
    {
        public string selected = "0";
        public EmojiPage()
        {
            InitializeComponent();
        }
        private void EmojiPage_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdb0.Checked) selected = "0";
            else if (rdb1.Checked) selected = "1";
            else if (rdb2.Checked) selected = "2";
            else if (rdb3.Checked) selected = "3";
            else if (rdb4.Checked) selected = "4";
            else if (rdb5.Checked) selected = "5";

            this.DialogResult = DialogResult.OK;
        }

    }
}
