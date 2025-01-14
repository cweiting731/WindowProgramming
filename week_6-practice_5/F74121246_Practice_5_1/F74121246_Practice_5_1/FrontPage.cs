using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_Practice_5_1
{
    public partial class FrontPage : UserControl
    {
        public event EventHandler started;
        public FrontPage()
        {
            InitializeComponent();
            
            pbAdd.Image = Image.FromFile("../../images/g2.png");
            pbMinus.Image = Image.FromFile("../../images/g1.png");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            started?.Invoke(this, EventArgs.Empty);
        }

    }
}
