using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_Practice_3_1
{

    public partial class Form1 : Form
    {
        private MainPage mainPage;
        private AddOrderPage addOrderPage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 700);
            LoadFrontPage();
        }

        private void LoadFrontPage()
        {
            this.Controls.Clear();
            FrontPage frontPage = new FrontPage();
            frontPage.Dock = DockStyle.Fill;

            frontPage.OnOpenShopClicked += FrontPage_OpenShopClick;

            this.Controls.Add(frontPage);
        }

        private void FrontPage_OpenShopClick(object sender, EventArgs e)
        {
            this.Controls.Clear();
            SignInPage signInPage = new SignInPage();
            signInPage.Dock = DockStyle.Fill;

            signInPage.OnChangeToMainPage += SignInPage_ChangeToMainPage;

            this.Controls.Add(signInPage);
        }

        private void SignInPage_ChangeToMainPage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            mainPage = new MainPage();
            mainPage.Dock = DockStyle.Fill;

            mainPage.OnAddOrderClicked += MainPage_ChangeToAddOrderPage;

            this.Controls.Add(mainPage);
        }

        private void MainPage_ChangeToAddOrderPage(object sender, EventArgs e)
        {
            addOrderPage = new AddOrderPage();
            addOrderPage.Dock = DockStyle.Fill;

            addOrderPage.CompletedOrder += AddOrderPage_BackToMainPage;

            mainPage.Visible = false;
            addOrderPage.Visible = true;

            this.Controls.Add(addOrderPage);
        }

        private void AddOrderPage_BackToMainPage(Object sender, OrderNode e)
        {
            addOrderPage.Visible = false;
            mainPage.Visible = true;

            mainPage.AddListOrder(e);

            this.Controls.Add(mainPage);
        }
    }

}
