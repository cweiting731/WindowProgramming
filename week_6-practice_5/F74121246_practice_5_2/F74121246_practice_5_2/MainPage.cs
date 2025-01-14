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
    public partial class MainPage : UserControl
    {
        bool Cardigan, Myrtle, Melantha, Shaw;
        Timer perSecond;
        Timer enemySpawn;
        Timer enemyMovement;
        int deployPoint = 20;
        short health = 3;
        short enemyAmount = 10;
        short enemyExist = 10;

        List<Label> labelList = new List<Label>(33);
        List<Role> roleList = new List<Role>(33);
        List<WaitingRoleNode> waitingRoleList = new List<WaitingRoleNode>();
        List<Enemy> enemies = new List<Enemy>();

        public event EventHandler loseGame, winGame, draw;

        public MainPage(bool Cardigan, bool Myrtle, bool Melantha, bool Shaw)
        {
            InitializeComponent();
            // get picked
            this.Cardigan = Cardigan;
            this.Myrtle = Myrtle;
            this.Melantha = Melantha;
            this.Shaw = Shaw;

            // init perSecond timer
            perSecond = new Timer();
            perSecond.Interval = 1000;
            perSecond.Tick += PerSecond_Tick1;
            perSecond.Start();

            enemySpawn = new Timer();
            enemySpawn.Interval = 10000;
            enemySpawn.Tick += EnemySpawn_Tick;
            enemySpawn.Start();

            enemyMovement = new Timer();
            enemyMovement.Interval = 10;
            enemyMovement.Tick += EnemyMovement_Tick;
            enemyMovement.Start();
            
            // init labelList
            labelList.Add(label1); labelList.Add(label2); labelList.Add(label3); labelList.Add(label4); labelList.Add(label5); labelList.Add(label6); labelList.Add(label7); labelList.Add(label8); labelList.Add(label9); labelList.Add(label10); labelList.Add(label11);
            labelList.Add(null); labelList.Add(label13); labelList.Add(label14); labelList.Add(label15); labelList.Add(label16); labelList.Add(label17); labelList.Add(label18); labelList.Add(label19); labelList.Add(label20); labelList.Add(label21); labelList.Add(null);
            labelList.Add(label23); labelList.Add(label24); labelList.Add(label25); labelList.Add(label26); labelList.Add(label27); labelList.Add(label28); labelList.Add(label29); labelList.Add(label30); labelList.Add(label31); labelList.Add(label32); labelList.Add(label33);
            for (int i = 0; i < labelList.Count; i++)
            {
                if (labelList[i] != null)
                {
                    labelList[i].Font = new Font("微軟正黑體", 10);
                    labelList[i].TextAlign = ContentAlignment.MiddleCenter;
                    labelList[i].MouseDown += label1_MouseDown;
                    labelList[i].MouseMove += label1_MouseMove;
                }
                roleList.Add(null);
            }

            // init waiting role
            if (Cardigan) CreateWaitingRole(0);
            if (Myrtle) CreateWaitingRole(1);
            if (Melantha) CreateWaitingRole(2);
            if (Shaw) CreateWaitingRole(3);

            Update_WaitingRoleList();
            Update_healthAndEnemyAmount();
            Update_deployPoint();
        }

        private void CloseAllTimer()
        {
            perSecond.Stop();
            enemySpawn.Stop();
            enemyMovement.Stop();
        }

        private void EnemyMovement_Tick(object sender, EventArgs e)
        {
            int i = 0;
            while (i < enemies.Count) 
            {
                // 一個enemy
                int enemyCenter = enemies[i].label.Left + (enemies[i].label.Width / 2);
                if (!enemies[i].isStop) enemies[i].label.Left += 1; // enemy 速度
                if (enemyCenter == Home.Left) // 砸進家裡
                {
                    health--; enemyAmount--;
                    this.Controls.Remove(enemies[i].label);
                    enemies.RemoveAt(i);
                    Update_healthAndEnemyAmount();

                    if (health == 0 && enemyAmount == 0) { draw?.Invoke(this, EventArgs.Empty); CloseAllTimer(); }
                    else if (health == 0) { loseGame?.Invoke(this, EventArgs.Empty); CloseAllTimer(); }
                    else if (enemyAmount == 0) { winGame?.Invoke(this, EventArgs.Empty); CloseAllTimer(); }
                    continue;
                }

                enemies[i].isStop = false;
                for (int j = 12; j < 21; j++)
                {
                    if (roleList[j] != null) // 有部署
                    {
                        if (labelList[j].Left < enemyCenter && enemyCenter < labelList[j].Right)
                        {
                            enemies[i].isStop = true;
                            break;
                        }
                    }
                }
                if (i > 0 && enemies[i].label.Right == enemies[i - 1].label.Left)
                {
                    enemies[i].isStop = true;
                }
                i++;
            }
        }

        private void EnemySpawn_Tick(object sender, EventArgs e)
        {
            if (enemyExist > 0) // 仍須派出敵人
            {
                Random random = new Random();
                Enemy enemy = new Enemy(2000, EnemyHome.Left + (EnemyHome.Width/2), EnemyHome.Top + (EnemyHome.Height/2));
                enemies.Add(enemy);
                this.Controls.Add(enemy.label);
                enemy.label.BringToFront();
                enemyExist--;
            }
            else
            {
                enemySpawn.Stop();
            }
        }

        private void PerSecond_Tick1(object sender, EventArgs e)
        {
            // update deployPoint
            if (deployPoint < 99)
            {
                deployPoint++;
                Update_deployPoint();
            }

            // update role CD
            for (int j = 0; j < roleList.Count; j++)
            {
                if (roleList[j] != null && roleList[j].CDnow > 0)
                {
                    roleList[j].CDnow--;
                }
            }

            int i = 0;
            while(i < enemies.Count)
            { 
                int judgePlace = enemies[i].label.Left + enemies[i].label.Width/2 - 4;
                int enemyIndex = 0; // 找到敵人的判定點所處的label index
                if (EnemyHome.Left < judgePlace && judgePlace < EnemyHome.Right) enemyIndex = 11; // 在紅框框內
                else
                {
                    for (int j = 12; j < 21; j++)
                    {
                        if (labelList[j].Left < judgePlace && judgePlace < labelList[j].Right)
                        {
                            enemyIndex = j; break;
                        }
                    }
                }
                //try
                //{
                // Console.WriteLine(String.Format("{0}, {1}, {2}, {3} | {4}", enemyIndex, enemyIndex-11, enemyIndex+11, enemyIndex+1, i));
                if (11 <= enemyIndex && enemyIndex <= 21)
                {
                    bool isDisappear = false;
                    if (roleList[enemyIndex] != null) // enemy 所處位置
                    {
                        isDisappear = DMG_To_Enemy(enemies[i], enemyIndex);
                        if (isDisappear) continue;
                        DMG_To_Role(enemies[i], enemyIndex);
                    }
                    if (roleList[enemyIndex - 11] != null) // enemy 上面一格
                    {
                        isDisappear = DMG_To_Enemy(enemies[i], enemyIndex - 11);
                        if (isDisappear) continue;
                    }
                    if (roleList[enemyIndex + 11] != null) // enemy 下面一格
                    {
                        isDisappear = DMG_To_Enemy(enemies[i], enemyIndex + 11);
                        if (isDisappear) continue;
                    }
                    if (roleList[enemyIndex + 1] != null) // enemy 右邊一格
                    {
                        isDisappear = DMG_To_Enemy(enemies[i], enemyIndex + 1);
                        if (isDisappear) continue;
                        DMG_To_Role(enemies[i], enemyIndex + 1);
                    }
                    if (!isDisappear) i++;
                }
                    
                //} catch (Exception except)
                //{
                //    Console.WriteLine(enemyIndex);
                //}
                
            }

            Update_labelList();
            Update_healthAndEnemyAmount();
        }

        private bool DMG_To_Enemy(Enemy enemy, int attackerIndex)
        {
            enemy.HP -= roleList[attackerIndex].ATK - enemy.DEF;
            enemy.label.Text = enemy.HP.ToString();
            if (enemy.HP <= 0)
            {
                enemies.Remove(enemy);
                this.Controls.Remove(enemy.label);
                enemyAmount--;
                if (enemyAmount == 0) { winGame?.Invoke(this, EventArgs.Empty); CloseAllTimer(); }
                return true;
            }
            return false;
        }

        private void DMG_To_Role(Enemy enemy, int roleIndex)
        {
            roleList[roleIndex].HP -= enemy.ATK - roleList[roleIndex].DEF;
            if (roleList[roleIndex].HP <= 0)
            {
                RemoveRole(roleIndex);
            }
        }

        private void RemoveRole(int index)
        {
            if (roleList[index] == null) return;
            int waitingListIndex = waitingRoleList.FindIndex(node => node.type == roleList[index].id);
            waitingRoleList[waitingListIndex].isWaiting = true;
            roleList[index] = null;
            Update_labelList();
            Update_WaitingRoleList();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Label tmp = (Label)sender;
            int index = labelList.IndexOf(tmp);
            if (e.Button == MouseButtons.Right)
            {
                RemoveRole(index);
            }
            else if (e.Button == MouseButtons.Left)
            {
                UsingSkill(index);
            }
        }

        private void UsingSkill(int index)
        {
            int judge = -1;
            if (roleList[index] == null || roleList[index].CDnow != 0) return;
            switch (roleList[index].type)
            {
                case "Cardigan":
                    if (roleList[index].HP == roleList[index].MaxHp) return;
                    if (roleList[index].HP + 852 >= 2130) roleList[index].HP = roleList[index].MaxHp;
                    else roleList[index].HP += 852;
                    break;
                case "Myrtle":
                    if (deployPoint == 99) return;
                    if (deployPoint + 14 > 99) deployPoint = 99;
                    else deployPoint += 14;
                    break;
                case "Melantha":
                    judge = Malentha_Skill(index);
                    if (judge == 0) return; 
                    break;
                case "Shaw":
                    judge = Shaw_Skill(index);
                    if (judge == 0) return;
                    break;
            }
            roleList[index].CDnow = roleList[index].CD;
            Update_deployPoint();
            Update_healthAndEnemyAmount();
            Update_labelList();
        }

        private bool DMG_To_Enemy(int doubleATK, Enemy enemy)
        {
            enemy.HP -= doubleATK - enemy.DEF;
            enemy.label.Text = enemy.HP.ToString();
            if (enemy.HP <= 0)
            {
                enemies.Remove(enemy);
                this.Controls.Remove(enemy.label);
                enemyAmount--;
                if (enemyAmount == 0) { winGame?.Invoke(this, EventArgs.Empty); CloseAllTimer(); }
                return true;
            }
            return false;
        }

        private int Malentha_Skill(int index)
        {
            int i = 0;
            int count = 0;
            while (i < enemies.Count)
            {
                int judgePlace = enemies[i].label.Left + enemies[i].label.Width / 2 - 4;
                int enemyIndex = 0; // 找到敵人的判定點所處的label index
                if (EnemyHome.Left < judgePlace && judgePlace < EnemyHome.Right) enemyIndex = 11; // 在紅框框內
                else
                {
                    for (int j = 12; j < 21; j++)
                    {
                        if (labelList[j].Left < judgePlace && judgePlace < labelList[j].Right)
                        {
                            enemyIndex = j; break;
                        }
                    }
                }
                bool isDisappear = false;
                if (enemyIndex == index || enemyIndex - 11 == index || enemyIndex + 11 == index || enemyIndex + 1 == index) // enemy 所處位置 上面一格 下面一格 右邊一格
                {
                    count++;
                    isDisappear = DMG_To_Enemy(1476, enemies[i]);
                    if (isDisappear) continue;
                }
                if (!isDisappear) i++;
            }
            return count;
        }

        private int Shaw_Skill(int index)
        {
            int i = 0;
            int count = 0;
            while (i < enemies.Count)
            {
                int judgePlace = enemies[i].label.Left + enemies[i].label.Width / 2 - 4;
                int enemyIndex = 0; // 找到敵人的判定點所處的label index
                if (EnemyHome.Left < judgePlace && judgePlace < EnemyHome.Right) enemyIndex = 11; // 在紅框框內
                else
                {
                    for (int j = 12; j < 21; j++)
                    {
                        if (labelList[j].Left < judgePlace && judgePlace < labelList[j].Right)
                        {
                            enemyIndex = j; break;
                        }
                    }
                }
                if (enemyIndex == index || enemyIndex - 11 == index || enemyIndex + 11 == index || enemyIndex + 1 == index) // enemy 所處位置 上面一格 下面一格 右邊一格
                {
                    count++;
                    enemies[i].label.Left -= labelList[index].Width;
                }
                i++;
            }
            return count;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Label tmp = (Label)sender;
            int index = labelList.IndexOf(tmp);
            if (roleList[index] != null)
            {
                lblInfo.Text = String.Format("{0}\nHP: {1} / {2}\nATK: {3}\nDEF: {4}\nCost: {5}\nCD: {6}",
                    roleList[index].type,
                    roleList[index].HP, roleList[index].MaxHp,
                    roleList[index].ATK,
                    roleList[index].DEF,
                    roleList[index].cost,
                    roleList[index].CD);
            }
        }

        private void CreateWaitingRole(short type)
        {
            short cost = 0; string roleName = "";
            switch (type)
            {
                case 0: cost = 18; roleName = "Cardigan";
                    break;
                case 1: cost = 10; roleName = "Myrtle";
                    break;
                case 2: cost = 15; roleName = "Melantha";
                    break;
                case 3: cost = 19; roleName = "Shaw";
                    break;
            }

            Label label = new Label();
            label.Text = String.Format("{0}\n{1}", roleName, cost);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;
            label.BackColor = Color.White;
            label.Font = new Font("微軟正黑體", 12);
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Size = new Size(85, 85);

            label.MouseDown += WaitingRoleLabel_MouseDown;
            label.MouseMove += WaitingRoleLabel_MouseMove;
            label.MouseUp += WaitingRoleLabel_MouseUp;

            waitingRoleList.Add(new WaitingRoleNode(label, type));
        }

        bool isDragging = false;
        int Mx, My;
        Label dragLabel; int dragLabelIndex;
        private void WaitingRoleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragLabel = (Label)sender;
                dragLabelIndex = waitingRoleList.FindIndex(node => node.label.Equals(dragLabel));
                waitingRoleList[dragLabelIndex].isWaiting = false;
                Update_WaitingRoleList();
                this.Controls.Add(dragLabel);
                dragLabel.BringToFront();
                dragLabel.Location = new Point(e.X, e.Y);
                Mx = e.X; My = e.Y;
            }
        }

        private void WaitingRoleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && dragLabel != null)
            {
                int newLeft = dragLabel.Left + (e.X - Mx);
                int newTop = dragLabel.Top + (e.Y - My);

                if (newLeft < 0) newLeft = 0;
                if (newLeft + dragLabel.Width > this.Width) newLeft = this.Width - dragLabel.Width;
                if (newTop < 0) newTop = 0;
                if (newTop + dragLabel.Height > this.Height) newTop = this.Height - dragLabel.Height;

                dragLabel.Left = newLeft;
                dragLabel.Top = newTop;
            }
        }

        private void WaitingRoleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            lblInfo.Text = "";
            if (isDragging)
            {
                isDragging = false;
                this.Controls.Remove(dragLabel);
                bool backToWait = true;
                
                Point mousePosition = this.PointToClient(Cursor.Position);

                for (int i = 0; i < labelList.Count; i++)
                {
                    // 判斷index不是11 and 21, 當地沒有角色在, 滑鼠座標在label範圍內
                    if (labelList[i] != null && roleList[i] == null)
                    {
                        if (labelList[i].Bounds.Contains(mousePosition))
                        {
                            string[] str = dragLabel.Text.Split('\n');
                            string roleName = str[0];
                            int cost = 0;
                            try { cost = int.Parse(str[1]); } catch (Exception except) { Console.WriteLine(except); }
                            if (deployPoint - cost < 0)
                            {
                                lblInfo.Text = "部署點數不足";
                                break;
                            }

                            backToWait = false;
                            deployPoint -= cost;
                            roleList[i] = new Role(roleName);
                            Update_deployPoint();
                            Update_labelList();
                            break;
                        } 
                    }
                }

                if (backToWait)
                {
                    waitingRoleList[dragLabelIndex].isWaiting = true;
                    Update_WaitingRoleList();
                }
                dragLabel = null;
            }
        }

        private void Update_labelList()
        {
            for (int i = 0; i < labelList.Count; i++)
            {
                if (labelList[i] != null)
                {
                    // Console.WriteLine(roleList[i].type);
                    if (roleList[i] == null)
                    {
                        labelList[i].Text = "";
                        labelList[i].BackColor = Color.White;
                    }
                    else
                    {
                        labelList[i].Text = String.Format("{0}\n{1}/{2}\n{3}", roleList[i].type, roleList[i].HP, roleList[i].MaxHp, roleList[i].CDnow);
                        labelList[i].BackColor = roleList[i].CDnow == 0 ? Color.LightGreen : Color.LightGray;
                    }
                }
            }
        }
        private void Update_healthAndEnemyAmount()
        {
            healthAndEnemyAmount.Text = String.Format("我方剩餘血量: {0}\n敵方剩餘敵人: {1}", health, enemyAmount);
        }
        private void Update_deployPoint()
        {
            lblDeployPoint.Text = String.Format("部署點數:\n{0} / 99", deployPoint);
        }
        private void Update_WaitingRoleList()
        {
            flpWaitDeploy.Controls.Clear();
            foreach (WaitingRoleNode node in waitingRoleList)
            {
                if (node.isWaiting) flpWaitDeploy.Controls.Add(node.label);
            }
        }
    }
}
