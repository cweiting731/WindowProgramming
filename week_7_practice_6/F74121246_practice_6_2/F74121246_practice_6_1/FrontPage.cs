using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace F74121246_practice_6_1
{
    public partial class FrontPage : UserControl
    {
        public event EventHandler newgameStart;
        public event EventHandler lastgameStart;
        public event EventHandler exit;
        private string filepath = "../../save.xml";
        public FrontPage()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            newgameStart?.Invoke(this, EventArgs.Empty);
        }

        private void FrontPage_Resize(object sender, EventArgs e)
        {
            pbTitle.Left = (this.ClientSize.Width - pbTitle.Width) / 2;
            pbTitle.Top = (this.ClientSize.Height - pbTitle.Height) / 4;
            btnStart.Left = (this.ClientSize.Width - btnStart.Width) / 2;
            btnStart.Top = pbTitle.Top * 3;
            btnLastPlay.Left = btnStart.Left;
            btnLastPlay.Top = btnStart.Top + 50;
            btnExit.Left = btnStart.Left;
            btnExit.Top = btnLastPlay.Top + 50;
        }

        private void btnLastPlay_Click(object sender, EventArgs e)
        {
            if (File.Exists(filepath))
            {
                lastgameStart?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            exit?.Invoke(this, EventArgs.Empty);
        }
    }
}
