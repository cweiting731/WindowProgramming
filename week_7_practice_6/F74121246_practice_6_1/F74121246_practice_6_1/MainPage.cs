using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using F74121246_practice_6_1;
using F74121246_practice_6_1.Properties;

namespace F74121246_practice_6_1
{
    public partial class MainPage : UserControl
    {
        private int selected = 0;
        private int widthCount = 30;
        private int heightCount = 15;
        private Block[,] blocks;
        private int size = 64;
        private int panelHeight;
        private int panelWidth;

        public MainPage()
        {
            InitializeComponent();
            this.MouseWheel += MainPage_MouseWheel;

            blocks = new Block[heightCount, widthCount];
            Random random = new Random();
            panelHeight = heightCount * size;
            panelWidth = widthCount * size;
            ground.Size = new Size(panelHeight, panelWidth);

            PictureBox player = new PictureBox();
            player.Image = Resources.steve;
            player.Height = 114;
            player.Width = 64;
            player.SizeMode = PictureBoxSizeMode.Zoom;
            int playerYPosition = random.Next(0, widthCount);
            //Console.WriteLine(playerYPosition.ToString()); // test

            for (int y=0; y<widthCount; y++)
            {
                float n = GetNoise1D(y / 3f);
                int grassLayer = (int)(n * 3) + 2;
                int stoneLayer = grassLayer + random.Next(0, 5);
                // Console.WriteLine(String.Format("{0}, {1} | {2}", grassLayer, stoneLayer, n));
                
                for (int x=0;  x<heightCount; x++)
                {
                    if (x == grassLayer)
                    {
                        if (y == playerYPosition)
                        {
                            player.Location = new Point(y*size ,x*size - player.Height);
                            ground.Controls.Add(player);
                        }
                        blocks[x, y] = new Block(Block.BlockType.Grass);
                    }
                    else if (grassLayer < x && x <= stoneLayer) blocks[x, y] = new Block(Block.BlockType.Dust);
                    else if (stoneLayer < x) blocks[x, y] = new Block(Block.BlockType.Stone);
                }
            }

            for (int y=0; y<widthCount; y++)
            {
                for (int x=0; x<heightCount; x++)
                {
                    if (blocks[x, y] != null) CreateAllBlockPicture(x, y, blocks[x, y]);
                }
            }
            
        }

        private void CreateAllBlockPicture(int x, int y, Block block)
        {
            if (block.picture == null)
            {
                block.picture = new PictureBox();
                switch(block.Type)
                {
                    case Block.BlockType.Grass:
                        block.picture.Image = Resources.grass;
                        break;
                    case Block.BlockType.Dust:
                        block.picture.Image = Resources.dust;
                        break;
                    case Block.BlockType.Stone:
                        block.picture.Image = Resources.stone;
                        break;
                    case Block.BlockType.Water:
                        block.picture.Image = Resources.water;
                        break;
                    default:
                        break;
                }
            }
            block.picture.Visible = true;
            block.picture.Enabled = false;
            block.picture.Size = new Size(size, size);
            block.picture.SizeMode = PictureBoxSizeMode.Zoom;

            int adjustY = y * size;
            int adjustX = x * size;

            block.picture.Location = new Point(adjustY, adjustX);
            ground.Controls.Add(block.picture);
        }


        private void MainPage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) // roll up
            {
                selected--;
                if (selected < 0) selected += 9;
            }
            if (e.Delta < 0) // roll down 
            {
                selected++;
                if (selected > 8) selected -= 9;
            }
            Update_ItemBar();
        }

        private void MainPage_Resize(object sender, EventArgs e)
        {
            Update_ItemBar();
            ground.Width = this.ClientSize.Width;
            ground.Height = this.ClientSize.Height;
        }

        private void Update_ItemBar()
        {
            pbItemBar.Left = (this.ClientRectangle.Width - pbItemBar.Width) / 2;
            pbItemBar.Top = (this.ClientRectangle.Height - 100);

            pbSelectBar.Top = pbItemBar.Top;
            pbSelectBar.Left = pbItemBar.Left + (pbItemBar.Width / 9 * selected);

            pbGrass.Top = pbDust.Top = pbStone.Top = pbWater.Top = (pbItemBar.Top + (pbItemBar.Height - pbGrass.Height)/2);
            pbGrass.Left = pbItemBar.Left + 9; 
            pbDust.Left = pbGrass.Left + pbDust.Width + 11;
            pbStone.Left = pbDust.Left + pbStone.Width + 11;
            pbWater.Left = pbStone.Left + pbWater.Width + 11;

            pbGrass.BringToFront();
            pbDust.BringToFront();
            pbStone.BringToFront();
            pbWater.BringToFront();
        }

        private static float GetNoise1D(float x) { return (float)(Math.Sin(2 * x) + Math.Sin(Math.PI * x)) / 4 + 0.5f; }

        private void ground_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (e.Y - ground.AutoScrollPosition.Y) / size;
            int y = (e.X - ground.AutoScrollPosition.X) / size;
            //Console.WriteLine(String.Format($"{x}, {y}"));
            if (e.Button == MouseButtons.Left)
            {
                Remove_Block(x, y);
            }
            if (e.Button == MouseButtons.Right)
            {
                switch (selected)
                {
                    case 0:
                        Place_Block(x, y, Block.BlockType.Grass);
                        break;
                    case 1:
                        Place_Block(x, y, Block.BlockType.Dust);
                        break;
                    case 2:
                        Place_Block(x, y, Block.BlockType.Stone);
                        break;
                    case 3:
                        Place_Block(x, y, Block.BlockType.Water);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Place_Block(int x, int y, Block.BlockType type)
        {
            if (blocks[x, y] == null)
            {
                Block block = new Block(type);
                int blockX = x * size + ground.AutoScrollPosition.Y;
                int blockY = y * size + ground.AutoScrollPosition.X;
                block.picture = new PictureBox();
                switch (block.Type)
                {
                    case Block.BlockType.Grass:
                        block.picture.Image = Resources.grass;
                        break;
                    case Block.BlockType.Dust:
                        block.picture.Image = Resources.dust;
                        break;
                    case Block.BlockType.Stone:
                        block.picture.Image = Resources.stone;
                        break;
                    case Block.BlockType.Water:
                        block.picture.Image = Resources.water;
                        break;
                    default:
                        break;
                }
                block.picture.Visible = true;
                block.picture.Enabled = false;
                block.picture.Size = new Size(size, size);
                block.picture.SizeMode = PictureBoxSizeMode.Zoom;
                block.picture.Location = new Point(blockY, blockX);
                blocks[x, y] = block;
                ground.Controls.Add(block.picture);
            }
        }

        private void Remove_Block(int x, int y)
        {
            if (blocks[x, y] == null) return;
            else
            {
                ground.Controls.Remove(blocks[x, y].picture);
                blocks[x, y].picture = null;
                blocks[x, y] = null;
            }
        }

        private void ground_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            //{
            //    // 垂直滾動時使用 NewValue 來控制滾動位置
            //    ground.AutoScrollPosition = new Point(0, (e.NewValue / size) * size);
            //}
            //else
            //{
            //    // 水平滾動時使用 NewValue 來控制滾動位置
            //    ground.AutoScrollPosition = new Point((e.NewValue / size) * size, 0);
            //}
        }
    }
}
