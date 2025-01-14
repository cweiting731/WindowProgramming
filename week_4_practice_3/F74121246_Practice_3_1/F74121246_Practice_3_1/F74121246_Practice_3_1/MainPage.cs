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
    public partial class MainPage : UserControl
    {
        List<OrderNode> listOrder = new List<OrderNode>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void ChangeLocation()
        {
            txtInfoGuide.Left = (this.ClientSize.Width - txtInfoGuide.Width) / 2;
            btnAddOrder.Left = txtInfoGuide.Left;
            btnListOrder.Left = txtInfoGuide.Left;
            listBoxOrder.Left = btnListOrder.Right;
        }

        private void MainPage_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        public event EventHandler OnAddOrderClicked;
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OnAddOrderClicked?.Invoke(this, EventArgs.Empty);
        }

        public void AddListOrder(OrderNode node)
        {
            listOrder.Add(node);
            txtInfoGuide.Text = "新增訂單成功，訂單編號 " + (listOrder.Count + 999).ToString();
        }

        private void btnListOrder_Click(object sender, EventArgs e)
        {
            listBoxOrder.Items.Clear();
            for (int i=0; i<listOrder.Count; i++)
            {
                string line = "訂單編號: ";
                line += (i + 1000).ToString();
                line += " 購買了 " + listOrder[i].amount.ToString() + " 個 " + listOrder[i].commodityName;

                listBoxOrder.Items.Add(line);
            }
        }
    }

    public class OrderNode : EventArgs
    {
        public string commodityName;
        public int amount;

        public OrderNode(string commodityName, int amount)
        {
            this.commodityName = commodityName;
            this.amount = amount;
        }
    }
}
