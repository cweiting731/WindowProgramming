using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_5_2
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
            frontPage.startGame += Load_PickRolePage;
            this.Controls.Add(frontPage);
        }

        private void Load_PickRolePage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            PickRolePage pickRolePage = new PickRolePage();
            pickRolePage.Dock = DockStyle.Fill;
            pickRolePage.startFight += Load_MainPage;
            this.Controls.Add(pickRolePage);
        }

        private void Load_MainPage(object sender, PickRolePackage picked)
        {
            this.Controls.Clear();
            MainPage mainPage = new MainPage(picked.Cardigan, picked.Myrtle, picked.Melantha, picked.Shaw);
            mainPage.Dock = DockStyle.Fill;
            mainPage.winGame += Load_WinPage;
            mainPage.draw += Load_DrawPage;
            mainPage.loseGame += Load_LosePage;

            this.Controls.Add(mainPage);
        }

        private void Load_WinPage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            EndPage endPage = new EndPage("獲勝");
            endPage.Dock = DockStyle.Fill;
            this.Controls.Add(endPage);
        }

        private void Load_LosePage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            EndPage endPage = new EndPage("慘敗");
            endPage.Dock = DockStyle.Fill;
            this.Controls.Add(endPage);
        }

        private void Load_DrawPage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            EndPage endPage = new EndPage("平手");
            endPage.Dock = DockStyle.Fill;
            this.Controls.Add(endPage);
        }
    }
}
