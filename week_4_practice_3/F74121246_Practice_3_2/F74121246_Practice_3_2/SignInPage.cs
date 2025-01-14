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
    public partial class SignInPage : UserControl
    {
        public event EventHandler<NowUser> SignInCompleted;
        public Dictionary<string, string> accounts = new Dictionary<string, string>();

        public SignInPage()
        {
            InitializeComponent();
            accounts.Add("admin", "admin");
        }

        private void SignInPage_Resize(object sender, EventArgs e)
        {
            txtInfoGuide.Left = (this.ClientSize.Width -  txtInfoGuide.Width) / 2;
            labelAccount.Left = txtInfoGuide.Left;
            labelPassword.Left = txtInfoGuide.Left;
            txtAccount.Left = labelAccount.Right;
            txtPassword.Left = labelPassword.Right;
            txtAccount.Top = labelAccount.Top;
            txtPassword.Top = labelPassword.Top;
            btnSignIn.Left = (this.ClientSize.Width - btnSignIn.Width) / 2;
        }
        private void SignInPage_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text;
            string password = txtPassword.Text;

            txtAccount.Clear();
            txtPassword.Clear();

            if (account == "" || password == "")
            {
                txtInfoGuide.Text = "帳號與密碼不可為空 !";
                return;
            }
            else if (!accounts.ContainsKey(account))
            {
                txtInfoGuide.Text = "此帳號不存在 !";
                return;
            }
            else if (accounts[account] != password)
            {
                txtInfoGuide.Text = "帳號或密碼錯誤 !";
                return;
            }
            txtInfoGuide.Text = "歡迎光臨，請登入 !";
            SignInCompleted?.Invoke(this, new NowUser(account, password));
        }

        public void AddAccountList(string account, string password)
        {
            accounts.Add(account, password);
        }
    }
}
