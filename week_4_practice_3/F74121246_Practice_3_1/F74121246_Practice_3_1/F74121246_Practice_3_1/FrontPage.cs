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
    public partial class FrontPage : UserControl
    {
        public FrontPage()
        {
            InitializeComponent();
        }
        private void FrontPage_Load(object sender, EventArgs e)
        {
            ChangeLocation();
            ActiveControl = btnOpenShop;
        }

        private void BtnOpenShop_Click(object sender, EventArgs e)
        {
            OnOpenShopClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnOpenShopClicked;

        private void ChangeLocation()
        {
            btnOpenShop.Left = (this.ClientSize.Width - btnOpenShop.Width) / 2;
            infoGuide.Left = (this.ClientSize.Width - infoGuide.Width) / 2;
        }

        private void FrontPage_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }
    }
}
