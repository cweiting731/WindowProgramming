using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_Practice_3_2
{
    public partial class Form1 : Form
    {
        private SignInPage signInPage;
        private MainPage mainPage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 700);
            LoadFrontPage();
            mainPage = new MainPage();
            mainPage.Dock = DockStyle.Fill;
            mainPage.AddOrder += MainPage_To_AddOrderPage;
            mainPage.SignOut += MainPage_To_SignInPage;
            mainPage.AddAccount += MainPage_To_AddAccountPage;
        }

        private void LoadFrontPage()
        {
            this.Controls.Clear();
            FrontPage frontPage = new FrontPage();
            frontPage.Dock = DockStyle.Fill;

            frontPage.OpenShopClicked += FrontPage_To_SignInPage;

            this.Controls.Add(frontPage);
        }

        private void FrontPage_To_SignInPage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            signInPage = new SignInPage();
            signInPage.Dock = DockStyle.Fill;

            signInPage.SignInCompleted += SignInPage_To_MainPage;

            this.Controls.Add(signInPage);
        }

        private void SignInPage_To_MainPage(object sender, NowUser e)
        {
            this.Controls.Clear();

            signInPage.Visible = false;
            mainPage.Visible = true;
            
            mainPage.ChangeUser(e.userAccount);

            this.Controls.Add(mainPage);
        }

        private void MainPage_To_SignInPage(object sender, EventArgs e)
        {
            this.Controls.Clear();

            mainPage.Visible = false;
            signInPage.Visible = true;

            this.Controls.Add(signInPage);
        }

        private void MainPage_To_AddOrderPage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            AddOrderPage addOrderPage = new AddOrderPage(mainPage.user);
            addOrderPage.Dock = DockStyle.Fill;

            mainPage.Visible = false;
            addOrderPage.Visible = true;

            addOrderPage.AddOrderCompleted += AddOrderPage_To_MainPage;

            this.Controls.Add(addOrderPage);
        }

        private void AddOrderPage_To_MainPage(Object sender, OrderNode e)
        {
            this.Controls.Clear();
            mainPage.Visible = true;

            mainPage.AddListOrder(e);

            this.Controls.Add(mainPage);
        }

        private void MainPage_To_AddAccountPage(object sender, EventArgs e)
        {
            this.Controls.Clear();
            mainPage.Visible = false;

            AddAccountPage addAccountPage = new AddAccountPage(signInPage.accounts);
            addAccountPage.Dock = DockStyle.Fill;
            addAccountPage.AddAccountCompleted += AddAccountPage_To_MainPage;

            this.Controls.Add(addAccountPage);
        }

        private void AddAccountPage_To_MainPage(object sender, NowUser e)
        {
            this.Controls.Clear();
            mainPage.Visible = true;

            signInPage.AddAccountList(e.userAccount, e.userPassword);
            mainPage.ChangeUser(e.userAccount);

            this.Controls.Add(mainPage);
        }
    }
}
