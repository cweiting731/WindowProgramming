using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_6_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            FrontPage frontPage = new FrontPage();
            frontPage.Dock = DockStyle.Fill;
            frontPage.gameStart += MainPage_Load;
            this.Controls.Add(frontPage);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            MainPage mainPage = new MainPage();
            mainPage.Dock = DockStyle.Fill;
            this.Controls.Add(mainPage);
        }
    }
}
