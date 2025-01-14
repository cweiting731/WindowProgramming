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
    public partial class PickRolePage : UserControl
    {
        public event EventHandler<PickRolePackage> startFight;
        bool Cardigan = false, Myrtle = false, Melantha = false, Shaw = false;
        public PickRolePage()
        {
            InitializeComponent();
        }

        private void btnCardigan_Click(object sender, EventArgs e)
        {
            Cardigan = !Cardigan;
            btnCardigan.BackColor = Cardigan ? Color.LightGray : Color.White;
        }

        private void btnMyrtle_Click(object sender, EventArgs e)
        {
            Myrtle = !Myrtle;
            btnMyrtle.BackColor = Myrtle ? Color.LightGray : Color.White;
        }

        private void btnMelantha_Click(object sender, EventArgs e)
        {
            Melantha = !Melantha;
            btnMelantha.BackColor = Melantha ? Color.LightGray :Color.White;
        }

        private void btnShaw_Click(object sender, EventArgs e)
        {
            Shaw = !Shaw;
            btnShaw.BackColor = Shaw ? Color.LightGray : Color.White;
        }

        private void btnStartFight_Click(object sender, EventArgs e)
        {
            if (Cardigan || Myrtle ||  Melantha || Shaw)
            {
                startFight?.Invoke(this, new PickRolePackage(Cardigan, Myrtle, Melantha, Shaw));
            }
        }
    }

    public class PickRolePackage : EventArgs
    {
        public bool Cardigan, Myrtle, Melantha, Shaw;

        public PickRolePackage(bool cardigan, bool myrtle, bool melantha, bool shaw)
        {
            Cardigan = cardigan;
            Myrtle = myrtle;
            Melantha = melantha;
            Shaw = shaw;
        }
    }
}
