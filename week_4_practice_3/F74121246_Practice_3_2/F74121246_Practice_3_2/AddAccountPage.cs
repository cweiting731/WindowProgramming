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
    public partial class AddAccountPage : UserControl
    {
        public Dictionary<string, string> accounts;
        public event EventHandler<NowUser> AddAccountCompleted;
        public AddAccountPage(Dictionary<string, string> accounts)
        {
            InitializeComponent();
            this.accounts = accounts;
        }

        private void AddAccountPage_Resize(object sender, EventArgs e)
        {
            txtInfoGuide.Left = (this.ClientSize.Width -  txtInfoGuide.Width) / 2;
            btnAdd.Left = (this.ClientSize.Width - btnAdd.Width) / 2;
            labelAccount.Left = txtInfoGuide.Left;
            labelPassword.Left = txtInfoGuide.Left;
            txtAccount.Left = labelAccount.Right;
            txtPassword.Left = labelPassword.Right;
            txtAccount.Top = labelAccount.Top;
            txtPassword.Top = labelPassword.Top;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text;
            string password = txtPassword.Text;

            txtAccount.Clear();
            txtPassword.Clear();

            if (account == "" || password == "")
            {
                txtInfoGuide.Text = "帳號或密碼不應為空 !";
                return;
            }
            else if (accounts.ContainsKey(account))
            {
                txtInfoGuide.Text = "此帳號已存在 !";
                return;
            }

            AddAccountCompleted?.Invoke(this, new NowUser(account, password));
        }

    }
}
