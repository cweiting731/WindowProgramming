using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_5_2
{
    public partial class FrontPage : UserControl
    {
        public event EventHandler startGame;
        public FrontPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startGame?.Invoke(this, EventArgs.Empty);
        }
    }
}
