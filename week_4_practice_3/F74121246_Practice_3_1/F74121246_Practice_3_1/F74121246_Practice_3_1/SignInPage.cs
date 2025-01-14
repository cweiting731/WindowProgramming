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
    public partial class SignInPage : UserControl
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void ChangeLocation()
        {
            txtInfoGuide.Left = (this.ClientSize.Width - txtInfoGuide.Width) / 2;
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
            ActiveControl = txtAccount;
        }

        private void SignInPage_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        public event EventHandler OnChangeToMainPage;

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text ==  "admin" && txtPassword.Text == "admin")
            {
                OnChangeToMainPage?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                txtInfoGuide.Text = "帳號或密碼錯誤";
                txtAccount.Clear();
                txtPassword.Clear();
            }
        }
    }
}
