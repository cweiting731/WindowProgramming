using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace F74121246_practice_6_1
{
    public partial class Form1 : Form
    {
        private string filepath = "../../save.xml";
        public Form1()
        {
            InitializeComponent();
            //if (File.Exists(filepath))
            //{
            //    File.Delete(filepath);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            FrontPage frontPage = new FrontPage();
            frontPage.Dock = DockStyle.Fill;
            frontPage.newgameStart += MainPage_Load;
            frontPage.lastgameStart += MainPage_LastGameLoad;
            frontPage.exit += Exit;
            this.Controls.Add(frontPage);
        }

        private void MainPage_LastGameLoad(object sender, EventArgs e)
        {
            this.Controls.Clear();
            MainPage mainPage = new MainPage(false);
            mainPage.Dock = DockStyle.Fill;
            mainPage.backToFrontPage += Form1_Load;
            this.Controls.Add(mainPage);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            MainPage mainPage = new MainPage(true);
            mainPage.Dock = DockStyle.Fill;
            mainPage.backToFrontPage += Form1_Load;
            this.Controls.Add(mainPage);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
