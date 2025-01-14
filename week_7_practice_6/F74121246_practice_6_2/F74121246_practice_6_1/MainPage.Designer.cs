namespace F74121246_practice_6_1
{
    partial class MainPage
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ground = new System.Windows.Forms.Panel();
            this.pbWater = new System.Windows.Forms.PictureBox();
            this.pbStone = new System.Windows.Forms.PictureBox();
            this.pbDust = new System.Windows.Forms.PictureBox();
            this.pbGrass = new System.Windows.Forms.PictureBox();
            this.pbSelectBar = new System.Windows.Forms.PictureBox();
            this.pbItemBar = new System.Windows.Forms.PictureBox();
            this.pausePage = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnKeepPlaying = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemBar)).BeginInit();
            this.pausePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ground
            // 
            this.ground.AutoScroll = true;
            this.ground.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ground.Location = new System.Drawing.Point(0, 0);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(366, 433);
            this.ground.TabIndex = 6;
            this.ground.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ground_MouseClick);
            // 
            // pbWater
            // 
            this.pbWater.Image = global::F74121246_practice_6_1.Properties.Resources.water;
            this.pbWater.Location = new System.Drawing.Point(725, 895);
            this.pbWater.Name = "pbWater";
            this.pbWater.Size = new System.Drawing.Size(65, 65);
            this.pbWater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWater.TabIndex = 5;
            this.pbWater.TabStop = false;
            // 
            // pbStone
            // 
            this.pbStone.Image = global::F74121246_practice_6_1.Properties.Resources.stone;
            this.pbStone.Location = new System.Drawing.Point(654, 895);
            this.pbStone.Name = "pbStone";
            this.pbStone.Size = new System.Drawing.Size(65, 65);
            this.pbStone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStone.TabIndex = 4;
            this.pbStone.TabStop = false;
            // 
            // pbDust
            // 
            this.pbDust.Image = global::F74121246_practice_6_1.Properties.Resources.dust;
            this.pbDust.Location = new System.Drawing.Point(583, 895);
            this.pbDust.Name = "pbDust";
            this.pbDust.Size = new System.Drawing.Size(65, 65);
            this.pbDust.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDust.TabIndex = 3;
            this.pbDust.TabStop = false;
            // 
            // pbGrass
            // 
            this.pbGrass.Image = global::F74121246_practice_6_1.Properties.Resources.grass;
            this.pbGrass.Location = new System.Drawing.Point(512, 895);
            this.pbGrass.Name = "pbGrass";
            this.pbGrass.Size = new System.Drawing.Size(65, 65);
            this.pbGrass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGrass.TabIndex = 2;
            this.pbGrass.TabStop = false;
            // 
            // pbSelectBar
            // 
            this.pbSelectBar.BackColor = System.Drawing.Color.Transparent;
            this.pbSelectBar.Image = global::F74121246_practice_6_1.Properties.Resources.selectItem;
            this.pbSelectBar.Location = new System.Drawing.Point(416, 895);
            this.pbSelectBar.Name = "pbSelectBar";
            this.pbSelectBar.Size = new System.Drawing.Size(90, 90);
            this.pbSelectBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectBar.TabIndex = 1;
            this.pbSelectBar.TabStop = false;
            // 
            // pbItemBar
            // 
            this.pbItemBar.BackColor = System.Drawing.Color.Transparent;
            this.pbItemBar.Image = global::F74121246_practice_6_1.Properties.Resources.itemBar;
            this.pbItemBar.Location = new System.Drawing.Point(416, 799);
            this.pbItemBar.Name = "pbItemBar";
            this.pbItemBar.Size = new System.Drawing.Size(742, 90);
            this.pbItemBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbItemBar.TabIndex = 0;
            this.pbItemBar.TabStop = false;
            // 
            // pausePage
            // 
            this.pausePage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pausePage.Controls.Add(this.btnBack);
            this.pausePage.Controls.Add(this.btnSave);
            this.pausePage.Controls.Add(this.btnKeepPlaying);
            this.pausePage.Location = new System.Drawing.Point(739, 116);
            this.pausePage.Name = "pausePage";
            this.pausePage.Size = new System.Drawing.Size(1500, 1000);
            this.pausePage.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBack.Location = new System.Drawing.Point(574, 578);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(352, 60);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "回到主畫面";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(574, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(352, 60);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "儲存並回到主畫面";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnKeepPlaying
            // 
            this.btnKeepPlaying.AutoSize = true;
            this.btnKeepPlaying.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnKeepPlaying.Location = new System.Drawing.Point(574, 221);
            this.btnKeepPlaying.Name = "btnKeepPlaying";
            this.btnKeepPlaying.Size = new System.Drawing.Size(352, 60);
            this.btnKeepPlaying.TabIndex = 0;
            this.btnKeepPlaying.Text = "回到遊戲";
            this.btnKeepPlaying.UseVisualStyleBackColor = true;
            this.btnKeepPlaying.Click += new System.EventHandler(this.btnKeepPlaying_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbWater);
            this.Controls.Add(this.pbItemBar);
            this.Controls.Add(this.pbStone);
            this.Controls.Add(this.pbSelectBar);
            this.Controls.Add(this.pbDust);
            this.Controls.Add(this.pbGrass);
            this.Controls.Add(this.pausePage);
            this.Controls.Add(this.ground);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1500, 1000);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyDown);
            this.Resize += new System.EventHandler(this.MainPage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemBar)).EndInit();
            this.pausePage.ResumeLayout(false);
            this.pausePage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbItemBar;
        private System.Windows.Forms.PictureBox pbSelectBar;
        private System.Windows.Forms.PictureBox pbGrass;
        private System.Windows.Forms.PictureBox pbDust;
        private System.Windows.Forms.PictureBox pbStone;
        private System.Windows.Forms.PictureBox pbWater;
        private System.Windows.Forms.Panel ground;
        private System.Windows.Forms.Panel pausePage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnKeepPlaying;
    }
}
