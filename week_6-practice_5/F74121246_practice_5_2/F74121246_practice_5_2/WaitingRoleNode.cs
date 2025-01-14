using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace F74121246_practice_5_2
{
    internal class WaitingRoleNode
    {
        public bool isWaiting;
        public int type;
        public Label label;
       
        public WaitingRoleNode(Label label, int type)
        {
            isWaiting = true;
            this.label = label;
            this.type = type;
        }
    }
}
