namespace F74121246_practice_4_2
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tcChat = new System.Windows.Forms.TabControl();
            this.tpChat = new System.Windows.Forms.TabPage();
            this.flp1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flp2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnEmoji = new System.Windows.Forms.Button();
            this.tcChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcChat
            // 
            this.tcChat.Controls.Add(this.tpChat);
            this.tcChat.Controls.Add(this.tabPage2);
            this.tcChat.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tcChat.Location = new System.Drawing.Point(93, 74);
            this.tcChat.Name = "tcChat";
            this.tcChat.SelectedIndex = 0;
            this.tcChat.Size = new System.Drawing.Size(1216, 37);
            this.tcChat.TabIndex = 0;
            this.tcChat.SelectedIndexChanged += new System.EventHandler(this.tcChat_SelectedIndexChanged);
            // 
            // tpChat
            // 
            this.tpChat.Location = new System.Drawing.Point(4, 40);
            this.tpChat.Name = "tpChat";
            this.tpChat.Padding = new System.Windows.Forms.Padding(3);
            this.tpChat.Size = new System.Drawing.Size(1208, 0);
            this.tpChat.TabIndex = 0;
            this.tpChat.Text = "tabPage1";
            this.tpChat.UseVisualStyleBackColor = true;
            // 
            // flp1
            // 
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.flp1.Location = new System.Drawing.Point(93, 114);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(1202, 678);
            this.flp1.TabIndex = 0;
            this.flp1.WrapContents = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1208, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flp2
            // 
            this.flp2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.flp2.Location = new System.Drawing.Point(439, 59);
            this.flp2.Name = "flp2";
            this.flp2.Size = new System.Drawing.Size(1202, 678);
            this.flp2.TabIndex = 1;
            this.flp2.WrapContents = false;
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtChat.Location = new System.Drawing.Point(93, 804);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(1043, 39);
            this.txtChat.TabIndex = 1;
            // 
            // btnPass
            // 
            this.btnPass.AutoSize = true;
            this.btnPass.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPass.Location = new System.Drawing.Point(1188, 804);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(117, 41);
            this.btnPass.TabIndex = 2;
            this.btnPass.Text = "傳送";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnEmoji
            // 
            this.btnEmoji.BackgroundImage = global::F74121246_practice_4_2.Properties.Resources.button;
            this.btnEmoji.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmoji.Location = new System.Drawing.Point(1142, 804);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(40, 40);
            this.btnEmoji.TabIndex = 3;
            this.btnEmoji.UseVisualStyleBackColor = true;
            this.btnEmoji.Click += new System.EventHandler(this.btnEmoji_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.btnEmoji);
            this.Controls.Add(this.flp2);
            this.Controls.Add(this.flp1);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.tcChat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tcChat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcChat;
        private System.Windows.Forms.TabPage tpChat;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.FlowLayoutPanel flp2;
        private System.Windows.Forms.Button btnEmoji;
    }
}

