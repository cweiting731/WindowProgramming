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
    public partial class AddOrderPage : UserControl
    {
        int selected = 3; // 0 for penguin // 1 for friedPork // 2 for friedShrimp

        public AddOrderPage()
        {
            InitializeComponent();
        }

        private void ChangeLocation()
        {
            txtInfoGuide.Left = (this.ClientSize.Width - txtInfoGuide.Width) / 2;
            labelAmount.Left = txtInfoGuide.Left;
            txtAmount.Left = labelAmount.Right;
            btnPenguin.Left = txtInfoGuide.Left;
            btnFriedPork.Left = (this.ClientSize.Width - btnFriedPork.Width) / 2;
            btnFriedShrimp.Left = txtInfoGuide.Right - btnFriedShrimp.Width;
            btnPassOrder.Left = (this.ClientSize.Width - btnPassOrder.Width) / 2;
        }

        private void ClearAllSelected()
        {
            selected = 3;
        }

        private void AddOrderPage_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        public event EventHandler<OrderNode> CompletedOrder;

        private void btnPenguin_Click(object sender, EventArgs e)
        {
            ClearAllSelected();
            selected = 0;
        }

        private void btnFriedPork_Click(object sender, EventArgs e)
        {
            ClearAllSelected();
            selected = 1;
        }

        private void btnFriedShrimp_Click(object sender, EventArgs e)
        {
            ClearAllSelected();
            selected = 2;
        }

        private void btnPassOrder_Click(object sender, EventArgs e)
        {
            if ( selected == 3 )
            {
                txtInfoGuide.Text = "請選擇一項商品 !";
                return;
            }
            else if (txtAmount.Text == "")
            {
                txtInfoGuide.Text = "請輸入數量 !";
                return;
            }

            try
            {
                int amount = int.Parse(txtAmount.Text);
                string commodityName;
                if ( amount <= 0 )
                {
                    txtInfoGuide.Text = "請輸入正整數 !";
                    return;
                }
                switch(selected)
                {
                    case 0:
                        commodityName = "企鵝";
                        break;
                    case 1:
                        commodityName = "炸豬排";
                        break;
                    case 2:
                        commodityName = "炸蝦";
                        break;
                    default:
                        commodityName = "";
                        break;
                }

                CompletedOrder?.Invoke(this, new OrderNode(commodityName, amount));
            }
            catch (FormatException)
            {
                txtInfoGuide.Text = "請輸入正整數 !";
                return;
            }
            catch (OverflowException)
            {
                txtInfoGuide.Text = "數量太大，請分批輸入 !";
                return;
            }
        }
    }
}
