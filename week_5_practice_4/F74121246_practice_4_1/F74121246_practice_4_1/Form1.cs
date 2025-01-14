using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace F74121246_practice_4_1
{
    public partial class Form1 : Form
    {
        List<string> content = new List<string>();
        Color zero = Color.White;
        Color one = Color.White;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeLocation();
            tabC.TabPages[0].Text = "斗哥";
            tabC.TabPages[1].Text = "楷特";
            tabC.SelectedIndex = 0;
            tabC_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void ChangeLocation()
        {
            tabC.Left = (this.ClientSize.Width - tabC.Width) / 2;
            tabC.Top = (this.ClientSize.Height - tabC.Height - flp0.Height - txtWord.Height) / 2;
            flp0.Left = tabC.Left;
            flp1.Left = tabC.Left;
            flp0.Top = tabC.Bottom;
            flp1.Top = tabC.Bottom;
            txtWord.Left = flp0.Left;
            txtWord.Top = flp0.Bottom;
            btnPass.Left = flp0.Right - btnPass.Width;
            btnPass.Top = flp0.Bottom;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }
        int nowHeight = 0;
        private void btnPass_Click(object sender, EventArgs e)
        {
            string text = txtWord.Text;
            if (text == "") return;

            text = "楷特: " + text;
            AddMessage(flp1, text, false, true);
            AddMessage(flp0, text, true, false);
            AddMessage(flp1, "斗哥: 汪!", true, true);
            AddMessage(flp0, "斗哥: 汪!", false, false);

            while (nowHeight > flp0.Height)
            {
                nowHeight -= flp0.Controls[0].Height + flp0.Controls[0].Margin.Vertical;
                flp0.Controls.RemoveAt(0);
                flp1.Controls.RemoveAt(0);
            }

            txtWord.Text = "";
        }
        
        private void AddMessage(FlowLayoutPanel panel, string message, bool isLeft, bool add)
        {
            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.AutoSize = false;
            messageLabel.Font = new Font("Microsoft JhengHei", 12);
            int labelHeight = messageLabel.GetPreferredSize(new Size(tabC.Width - 30, 0)).Height;
            messageLabel.Size = new Size(tabC.Width - 30, labelHeight);


            if (add) nowHeight += messageLabel.Height + messageLabel.Margin.Vertical;

            if (isLeft)
                messageLabel.TextAlign = ContentAlignment.MiddleLeft;
            else
                messageLabel.TextAlign = ContentAlignment.MiddleRight;

            panel.Controls.Add(messageLabel);
            panel.ScrollControlIntoView(messageLabel);
        }

        string tmpString = "";
        private void tabC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabC.SelectedIndex == 0)
            {
                tmpString = txtWord.Text;
                txtWord.Text = "";
                txtWord.Enabled = false;
                btnPass.Enabled = false;
                flp0.Visible = true;
                flp1.Visible = false;
                this.BackColor = zero;
            }
            else
            {
                txtWord.Text = tmpString;
                txtWord.Enabled = true;
                btnPass.Enabled = true;
                flp0.Visible = false;
                flp1.Visible = true;
                this.BackColor = one;
            }
        }

        bool formTwoOpen = false;
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (!formTwoOpen)
            {
                formTwoOpen = true;
                Color originalColor = this.BackColor;
                RandomColor randomColor = new RandomColor(this);
                DialogResult result = randomColor.ShowDialog();
                if (result != DialogResult.OK)
                {
                    this.BackColor = originalColor;
                }

                if (tabC.SelectedIndex == 0) zero = this.BackColor;
                else one = this.BackColor;
                formTwoOpen = false;
            }
        }
    }
}
