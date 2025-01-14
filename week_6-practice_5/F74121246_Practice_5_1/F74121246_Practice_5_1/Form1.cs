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
    
    public partial class Form1 : Form
    {
        FrontPage frontPage;
        private Timer movementTimer;
        private Timer fruitDropTimer;
        int speed;
        bool moveLeft = false, moveRight = false;
        List<Fruit> fruitList;
        int success = 0, fail = 0, score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            frontPage = new FrontPage();
            frontPage.Dock = DockStyle.Fill;
            frontPage.started += Game_Load;
            this.Controls.Add(frontPage);
            plate.Visible = false;
            plate.Top = this.ClientSize.Height / 5 * 4;
            lblSF.Visible = false;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.Controls.Remove(frontPage);
            this.Focus();

            plate.Visible = true;
            lblSF.Visible = true;
            lblSF.Text = String.Format("Receive: {0}\nLost: {1}\nScore: {2}", success, fail, score);

            plate.BackColor = Color.Red;
            speed = 10;
            movementTimer = new Timer();
            movementTimer.Interval = 10;
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();

            fruitList = new List<Fruit>();
            fruitDropTimer = new Timer();
            fruitDropTimer.Interval = 1000;
            fruitDropTimer.Tick += FruitDropTimer_Tick;
            fruitDropTimer.Start();
        }

        private void FruitDropTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int x = random.Next(0, this.ClientSize.Width - 30);
            Fruit newfruit = new Fruit(x, -40, random.Next(0, 3));
            this.Controls.Add(newfruit.fruit);
            fruitList.Add(newfruit);
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            if((moveLeft && !moveRight) || (!moveLeft && moveRight)) // xor
            {
                if (moveLeft && plate.Left > 0)
                {
                    if (plate.Left - speed < 0) plate.Left = 0;
                    else plate.Left -= speed;
                }
                if (moveRight && plate.Right < this.ClientSize.Width)
                {
                    if (plate.Right + speed > this.ClientSize.Width) plate.Left = this.ClientSize.Width - plate.Width;
                    else plate.Left += speed;
                }
            }

            int i = 0;
            while(i < fruitList.Count)
            {
                fruitList[i].fruit.Top += 5;
                if (fruitList[i].fruit.Top > this.ClientSize.Height)
                {
                    if (fruitList[i].addPoint) score--;
                    fail++;

                    this.Controls.Remove(fruitList[i].fruit);
                    fruitList.Remove(fruitList[i]);

                    lblSF.Text = String.Format("Receive: {0}\nLost: {1}\nScore: {2}", success, fail, score);
                }
                else if (((plate.Top < fruitList[i].fruit.Bottom && fruitList[i].fruit.Bottom < plate.Bottom) ||
                        (plate.Top < fruitList[i].fruit.Top && fruitList[i].fruit.Top < plate.Bottom))
                       &&
                       ((plate.Left < fruitList[i].fruit.Left && fruitList[i].fruit.Left < plate.Right) ||
                        (plate.Left < fruitList[i].fruit.Right && fruitList[i].fruit.Right < plate.Right)))
                {
                    if (fruitList[i].addPoint) score++;
                    else score -= 5;
                    success++;

                    this.Controls.Remove(fruitList[i].fruit);
                    fruitList.Remove(fruitList[i]);

                    lblSF.Text = String.Format("Receive: {0}\nLost: {1}\nScore: {2}", success, fail, score);
                }
                else i++;
            }
        }

        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("KeyDown");
            switch(e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    moveLeft = true;
                    break;
                case Keys.Right:
                case Keys.D:
                    moveRight = true;
                    break;
            }

            if (e.Shift) speed = 30;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    moveLeft = false;
                    break;
                case Keys.Right:
                case Keys.D:
                    moveRight = false;
                    break;
            }

            if (!e.Shift) speed = 10;
        }
    }

    class Fruit
    {
        public PictureBox fruit;
        public bool addPoint;
        public Fruit(int x, int y, int isZero) // 0 for true 1 2 for false
        {
            fruit = new PictureBox();
            fruit.Location = new Point(x, y);
            fruit.Size = new Size(30, 30);
            fruit.SizeMode = PictureBoxSizeMode.Zoom;
            String path = isZero == 0 ? "../../images/g1.png" : "../../images/g2.png";
            fruit.Image = Image.FromFile(path);
            addPoint = (isZero != 0);
        }
    }
}
