using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_6_1
{
    public partial class FrontPage : UserControl
    {
        public event EventHandler gameStart;
        public FrontPage()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            gameStart?.Invoke(this, EventArgs.Empty);
        }

        private void FrontPage_Resize(object sender, EventArgs e)
        {
            pbTitle.Left = (this.ClientSize.Width - pbTitle.Width) / 2;
            pbTitle.Top = (this.ClientSize.Height - pbTitle.Height) / 4;
            btnStart.Left = (this.ClientSize.Width - btnStart.Width) / 2;
            btnStart.Top = pbTitle.Top * 3;
        }
    }
}
