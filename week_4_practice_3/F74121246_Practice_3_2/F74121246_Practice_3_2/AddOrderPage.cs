using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_Practice_3_2
{
    public partial class AddOrderPage : UserControl
    {
        string user;
        int selected = 3; // 0 for penguin // 1 for friedPork // 2 for friedShrimp
        public event EventHandler<OrderNode> AddOrderCompleted;
        public AddOrderPage(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ClearSelected()
        {
            btnPenguin.Text = "企鵝";
            btnFriedPork.Text = "炸豬排";
            btnFriedShrimp.Text = "炸蝦";
        }

        private void AddOrderPage_Resize(object sender, EventArgs e)
        {
            txtInfoGuide.Left = (this.ClientSize.Width - txtInfoGuide.Width) / 2;
            btnFriedPork.Left = (this.ClientSize.Width - btnFriedPork.Width) / 2;
            btnPassOrder.Left = (this.ClientSize.Width - btnPassOrder.Width) / 2;
            labelAmount.Left = txtInfoGuide.Left;
            btnPenguin.Left = txtInfoGuide.Left;
            btnFriedShrimp.Left = txtInfoGuide.Right - btnFriedShrimp.Width;
            txtAmount.Left = labelAmount.Right;
        }

        private void btnPenguin_Click(object sender, EventArgs e)
        {
            ClearSelected();
            selected = 0;
            btnPenguin.Text += "\n(已選擇)";
        }

        private void btnFriedPork_Click(object sender, EventArgs e)
        {
            ClearSelected();
            selected = 1;
            btnFriedPork.Text += "\n(已選擇)";
        }

        private void btnFriedShrimp_Click(object sender, EventArgs e)
        {
            ClearSelected();
            selected = 2;
            btnFriedShrimp.Text += "\n(已選擇)";
        }

        private void btnPassOrder_Click(object sender, EventArgs e)
        {
            if (selected == 3)
            {
                txtInfoGuide.Text = "請選擇商品 !";
                return;
            }
            
            try
            {
                int amount = int.Parse(txtAmount.Text);
                string commodityName;
                if (amount <= 0)
                {
                    txtInfoGuide.Text = "請輸入正整數 !";
                    return;
                }

                if (selected == 0) { commodityName = "企鵝"; }
                else if (selected == 1) { commodityName = "炸豬排"; }
                else { commodityName = "炸蝦"; }

                AddOrderCompleted?.Invoke(this, new OrderNode(commodityName, amount, user));
            }
            catch (FormatException)
            {
                txtInfoGuide.Text = "請輸入數字 !";
                return;
            }
            catch (OverflowException)
            {
                txtInfoGuide.Text = "輸入值太大，請分批輸入 !";
                return;
            }
        }
    }
}
