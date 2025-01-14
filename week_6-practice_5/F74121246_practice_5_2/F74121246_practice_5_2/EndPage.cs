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
    public partial class EndPage : UserControl
    {
        public EndPage(string txt)
        {
            InitializeComponent();
            label1.Text = txt;

        }
    }
}
