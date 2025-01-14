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
    public partial class FrontPage : UserControl
    {
        public event EventHandler OpenShopClicked;
        public FrontPage()
        {
            InitializeComponent();
        }

        private void FrontPage_Resize(object sender, EventArgs e)
        {
            txtInfoGuide.Left = (this.ClientSize.Width - txtInfoGuide.Width) / 2;
            btnOpenShop.Left = (this.ClientSize.Width - btnOpenShop.Width) / 2;
        }

        private void btnOpenShop_Click(object sender, EventArgs e)
        {
            OpenShopClicked?.Invoke(this, EventArgs.Empty);
        }

        private void FrontPage_Load(object sender, EventArgs e)
        {
            ActiveControl = btnOpenShop;
        }
    }
}
