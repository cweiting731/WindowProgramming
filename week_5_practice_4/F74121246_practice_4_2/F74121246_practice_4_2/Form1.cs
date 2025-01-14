using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace F74121246_practice_4_2
{
    public partial class Form1 : Form
    {
        Color one = Color.White;
        Color two = Color.White;
        public Form1()
        {
            InitializeComponent();
        }

        void ChangeLocation()
        {
            tcChat.Left = (this.ClientSize.Width - tcChat.Width) / 2;
            tcChat.Top = (this.ClientSize.Height - tcChat.Height - flp1.Height - txtChat.Height) / 2;
            flp1.Left = tcChat.Left;
            flp2.Left = tcChat.Left;
            flp1.Top = tcChat.Bottom;
            flp2.Top = tcChat.Bottom;
            txtChat.Left = tcChat.Left;
            btnPass.Left = tcChat.Right - btnPass.Width;
            btnEmoji.Left = btnPass.Left - btnEmoji.Width - 5;
            btnEmoji.Top = flp1.Bottom;
            txtChat.Top = flp1.Bottom;
            btnPass.Top = flp1.Bottom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeLocation();
            tcChat.TabPages[0].Text = "斗哥";
            tcChat.TabPages[1].Text = "楷特";
            tcChat.SelectedIndex = 0;
            flp1.Visible = true;
            flp2.Visible = false;
            this.BackColor = Color.White;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        string tmpOne = "";
        string tmpTwo = "";
        private void tcChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcChat.SelectedIndex == 0)
            {
                btnEmoji.Enabled = true;
                btnPass.Enabled = true;
                tmpTwo = txtChat.Text;
                txtChat.Text = tmpOne;
                flp1.Visible = true;
                flp2.Visible = false;
                this.BackColor = one;
            }
            else if (tcChat.SelectedIndex == 1)
            {
                if (isGameStarted)
                {
                    btnEmoji.Enabled = false;
                    btnPass.Enabled = false;
                }
                else
                {
                    btnPass.Enabled = true;
                    btnEmoji.Enabled = true;
                }
                tmpOne = txtChat.Text;
                txtChat.Text = tmpTwo;
                flp1.Visible = false;
                flp2.Visible = true;
                this.BackColor = two;
            }
        }

        bool isGameStarted = false;
        private void btnPass_Click(object sender, EventArgs e)
        {
            string text = txtChat.Text;

            if (text == "") return;
            if (text == "猜拳" && tcChat.SelectedIndex == 0 && !isGameStarted)
            {
                AddMessage(text, true);
                AddMessage("遊戲開始 !", false);
                isGameStarted = true;
                txtChat.Text = "";
                return;
            }
            if ((text == "汪！" || text == "汪!") && tcChat.SelectedIndex == 0)
            {
                AddMessage(text, true);
                AddMessage("喵", false);
                txtChat.Text = "";
                return;
            }
            if ((text == "喵！" || text == "喵!") && tcChat.SelectedIndex == 1)
            {
                AddMessage(text, false);
                AddMessage("汪", true);
                txtChat.Text = "";
                return;
            }


            if (!isGameStarted) // 遊戲未開始 開啟正常通訊
            {
                AddMessage(text, tcChat.SelectedIndex == 0);
            }
            else // 遊戲開始 僅接受遊戲資訊
            {
                if (tcChat.SelectedIndex == 0)
                {
                    if (text == "剪刀")
                    {
                        AddMessage(text, true);
                        AddMessage("布", false);
                        AddMessage("我贏了哈哈哈 loser~", true);
                        AddMessage("......", false);
                        isGameStarted = false;
                    }
                    else if(text == "石頭")
                    {
                        AddMessage(text, true);
                        AddMessage("剪刀", false);
                        AddMessage("我贏了哈哈哈 loser~", true);
                        AddMessage("......", false);
                        isGameStarted = false;
                    }
                    else if(text == "布")
                    {
                        AddMessage(text, true);
                        AddMessage("石頭", false);
                        AddMessage("我贏了哈哈哈 loser~", true);
                        AddMessage("......", false);
                        isGameStarted = false;
                    }
                }
            }
            txtChat.Text = "";
        }

        int nowHeight = 0;

        private void AddMessage(string text, bool isZero)
        {
            bool isLeft;
            if (isZero) isLeft = false; // left is other
            else isLeft = true;
            FlowLayoutPanel panel1 = CreateMessagePanel(text, isZero, isLeft, true);
            FlowLayoutPanel panel2 = CreateMessagePanel(text, isZero, !isLeft, false);

            while(nowHeight > flp1.Height)
            {
                nowHeight -= flp1.Controls[0].Height + flp1.Controls[0].Margin.Vertical;
                flp1.Controls.RemoveAt(0);
                flp2.Controls.RemoveAt(0);
            }

            flp1.Controls.Add(panel1);
            flp2.Controls.Add(panel2);
        }

        private FlowLayoutPanel CreateMessagePanel(string text, bool isZero, bool isLeft, bool add) // true 斗哥 false 楷特
        {

            PictureBox icon = new PictureBox();
            icon.Size = new Size(20, 20);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            string imagePath = isZero ? "../../Images/dog.png" : "../../Images/cat.png";
            icon.Image = System.Drawing.Image.FromFile(imagePath);

            Label label = new Label();
            label.Text = isZero ? "斗哥: " : "楷特: ";
            label.Text += text;
            label.Font = new Font("微軟正黑體", 12);
            label.AutoSize = true;
            label.MaximumSize = new Size(tcChat.Width - 90, 0);

            int labelHeight = label.GetPreferredSize(label.MaximumSize).Height; // 取label實際Height

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = new Size(tcChat.Width - 40, labelHeight + 10);
            panel.AutoSize = false;

            if (add) nowHeight += panel.Height + panel.Margin.Vertical;

            if (isLeft)
            {
                panel.FlowDirection = FlowDirection.LeftToRight;
                panel.Controls.Add(icon);
                panel.Controls.Add(label);
            }
            else
            {
                panel.FlowDirection = FlowDirection.RightToLeft;
                panel.Controls.Add(label);
                panel.Controls.Add(icon);
            }

            return panel;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            ChangeColorPage changeColorPage = new ChangeColorPage(this, tcChat.SelectedIndex == 0 ? "斗哥" : "楷特");
            DialogResult = changeColorPage.ShowDialog();

            if (DialogResult != DialogResult.OK)
            {
                this.BackColor = tcChat.SelectedIndex == 0 ? one : two;
                return;
            }

            if (tcChat.SelectedIndex == 0) one = this.BackColor;
            else two = this.BackColor;
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            EmojiPage emojiPage = new EmojiPage();
            DialogResult result= emojiPage.ShowDialog();
            if (result == DialogResult.OK && !isGameStarted)
            {
                AddEmojiMessage(emojiPage.selected, tcChat.SelectedIndex == 0);
            }
        }

        private void AddEmojiMessage(string imagePath, bool isZero)
        {
            imagePath = "../../Images/" + imagePath + ".png";
            bool isLeft;
            if (isZero) isLeft = false; // left is other
            else isLeft = true;
            FlowLayoutPanel panel1 = CreateEmojiMessage(imagePath, isZero, isLeft, true);
            FlowLayoutPanel panel2 = CreateEmojiMessage(imagePath, isZero, !isLeft, false);

            while (nowHeight > flp1.Height)
            {
                nowHeight -= flp1.Controls[0].Height + flp1.Controls[0].Margin.Vertical;
                flp1.Controls.RemoveAt(0);
                flp2.Controls.RemoveAt(0);
            }

            flp1.Controls.Add(panel1);
            flp2.Controls.Add(panel2);
        }

        private FlowLayoutPanel CreateEmojiMessage(string imagePath, bool isZero, bool isLeft, bool add)
        {
            PictureBox icon = new PictureBox();
            icon.Size = new Size(20, 20);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            string iconPath = isZero ? "../../Images/dog.png" : "../../Images/cat.png";
            icon.Image = System.Drawing.Image.FromFile(iconPath);

            Label label = new Label();
            label.Text = isZero ? "斗哥: " : "楷特: ";
            label.Font = new Font("微軟正黑體", 12);
            label.AutoSize = true;
            label.MaximumSize = new Size(tcChat.Width - 90, 0);

            int labelHeight = label.GetPreferredSize(label.MaximumSize).Height;

            PictureBox emoji = new PictureBox();
            emoji.Size = new Size(20, 20);
            emoji.SizeMode = PictureBoxSizeMode.Zoom;
            emoji.Image = System.Drawing.Image.FromFile(imagePath);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = new Size(tcChat.Width - 40, labelHeight + 10);
            panel.AutoSize = false;

            if (add) nowHeight += panel.Height + panel.Margin.Vertical;

            if (isLeft)
            {
                panel.FlowDirection = FlowDirection.LeftToRight;
                panel.Controls.Add(icon);
                panel.Controls.Add(label);
                panel.Controls.Add(emoji);
            }
            else
            {
                panel.FlowDirection = FlowDirection.RightToLeft;
                panel.Controls.Add(emoji);
                panel.Controls.Add(label);
                panel.Controls.Add(icon);
            }

            return panel;
        }
    }
}
