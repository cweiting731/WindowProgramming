using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_Practice_3_2
{
    public partial class MainPage : UserControl
    {
        public string user;
        public event EventHandler AddOrder;
        public event EventHandler SignOut;
        public event EventHandler AddAccount;
        private List<OrderNode> listOrder = new List<OrderNode>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Resize(object sender, EventArgs e)
        {
            txtInfoGuide.Left = (this.ClientSize.Width - txtInfoGuide.Width) / 2;
            btnAddAccount.Left = txtInfoGuide.Left;
            btnAddOrder.Left = txtInfoGuide.Left;
            btnListOrder.Left = txtInfoGuide.Left;
            btnSignOut.Left = txtInfoGuide.Left;
            listBoxOrder.Top = btnAddOrder.Top;
            listBoxOrder.Left = btnAddOrder.Right;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            listBoxOrder.Items.Clear();
            AddOrder?.Invoke(this, EventArgs.Empty);
        }

        public void AddListOrder(OrderNode node)
        {
            listOrder.Add(node);
            txtInfoGuide.Text = "已新增訂單，訂單編號 " + (listOrder.Count + 999).ToString();
        }

        private void btnListOrder_Click(object sender, EventArgs e)
        {
            listBoxOrder.Items.Clear();
            listBoxOrder.Items.Add("訂單編號 - 商品名稱 - 數量 - 用戶");

            for (int i=0; i<listOrder.Count; i++)
            {
                string line = (i + 1000).ToString() + " - ";
                line += listOrder[i].commodityName + " - ";
                line += listOrder[i].amount.ToString() + " - ";
                line += listOrder[i].userName;
                listBoxOrder.Items.Add(line);
            }
        }
        public void ChangeUser(string userName)
        {
            user = userName;
            txtInfoGuide.Text = "歡迎 ! " + user;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            listBoxOrder.Items.Clear();
            SignOut?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            listBoxOrder.Items.Clear();
            AddAccount?.Invoke(this, EventArgs.Empty);
        }
    }

    public class OrderNode : EventArgs
    {
        public string commodityName;
        public int amount;
        public string userName;

        public OrderNode (string commodityName, int amount, string userName)
        {
            this.commodityName = commodityName;
            this.amount = amount;
            this.userName = userName;
        }
    }

    public class NowUser : EventArgs
    {
        public string userAccount;
        public string userPassword;

        public NowUser (string userAccount, string userPassword)
        {
            this.userAccount = userAccount;
            this.userPassword = userPassword;
        }
    }

}
