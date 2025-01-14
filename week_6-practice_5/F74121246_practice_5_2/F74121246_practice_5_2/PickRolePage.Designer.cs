namespace F74121246_practice_5_2
{
    partial class PickRolePage
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
            this.btnCardigan = new System.Windows.Forms.Button();
            this.btnMyrtle = new System.Windows.Forms.Button();
            this.btnMelantha = new System.Windows.Forms.Button();
            this.btnShaw = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.lblCardigan = new System.Windows.Forms.Label();
            this.lblMyrtle = new System.Windows.Forms.Label();
            this.lblMelantha = new System.Windows.Forms.Label();
            this.lblShaw = new System.Windows.Forms.Label();
            this.btnStartFight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCardigan
            // 
            this.btnCardigan.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardigan.Location = new System.Drawing.Point(228, 91);
            this.btnCardigan.Name = "btnCardigan";
            this.btnCardigan.Size = new System.Drawing.Size(200, 200);
            this.btnCardigan.TabIndex = 0;
            this.btnCardigan.Text = "Cardigan";
            this.btnCardigan.UseVisualStyleBackColor = true;
            this.btnCardigan.Click += new System.EventHandler(this.btnCardigan_Click);
            // 
            // btnMyrtle
            // 
            this.btnMyrtle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyrtle.Location = new System.Drawing.Point(228, 297);
            this.btnMyrtle.Name = "btnMyrtle";
            this.btnMyrtle.Size = new System.Drawing.Size(200, 200);
            this.btnMyrtle.TabIndex = 1;
            this.btnMyrtle.Text = "Myrtle";
            this.btnMyrtle.UseVisualStyleBackColor = true;
            this.btnMyrtle.Click += new System.EventHandler(this.btnMyrtle_Click);
            // 
            // btnMelantha
            // 
            this.btnMelantha.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMelantha.Location = new System.Drawing.Point(228, 503);
            this.btnMelantha.Name = "btnMelantha";
            this.btnMelantha.Size = new System.Drawing.Size(200, 200);
            this.btnMelantha.TabIndex = 2;
            this.btnMelantha.Text = "Melantha";
            this.btnMelantha.UseVisualStyleBackColor = true;
            this.btnMelantha.Click += new System.EventHandler(this.btnMelantha_Click);
            // 
            // btnShaw
            // 
            this.btnShaw.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShaw.Location = new System.Drawing.Point(228, 709);
            this.btnShaw.Name = "btnShaw";
            this.btnShaw.Size = new System.Drawing.Size(200, 200);
            this.btnShaw.TabIndex = 3;
            this.btnShaw.Text = "Shaw";
            this.btnShaw.UseVisualStyleBackColor = true;
            this.btnShaw.Click += new System.EventHandler(this.btnShaw_Click);
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblText.Location = new System.Drawing.Point(127, 91);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(57, 818);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "請選擇出戰角色";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardigan
            // 
            this.lblCardigan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCardigan.Location = new System.Drawing.Point(446, 91);
            this.lblCardigan.Name = "lblCardigan";
            this.lblCardigan.Size = new System.Drawing.Size(725, 200);
            this.lblCardigan.TabIndex = 5;
            this.lblCardigan.Text = "生命值: 2130\r\n攻擊力: 305\r\n防禦力: 475\r\n部署費用: 18\r\n技能冷卻時間: 20s\r\n技能說明: 能夠立即回覆 40% 的生命值 (不會超出" +
    "上限)\r\n";
            this.lblCardigan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMyrtle
            // 
            this.lblMyrtle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMyrtle.Location = new System.Drawing.Point(446, 297);
            this.lblMyrtle.Name = "lblMyrtle";
            this.lblMyrtle.Size = new System.Drawing.Size(725, 200);
            this.lblMyrtle.TabIndex = 6;
            this.lblMyrtle.Text = "生命值: 1565\r\n攻擊力: 520\r\n防禦力: 300\r\n部署費用: 10\r\n技能冷卻時間: 22s\r\n技能說明: 能夠立即獲得 14 點部署費用 (不會超出" +
    "上限)\r\n";
            this.lblMyrtle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMelantha
            // 
            this.lblMelantha.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMelantha.Location = new System.Drawing.Point(446, 503);
            this.lblMelantha.Name = "lblMelantha";
            this.lblMelantha.Size = new System.Drawing.Size(725, 200);
            this.lblMelantha.TabIndex = 7;
            this.lblMelantha.Text = "生命值: 2745\r\n攻擊力: 738\r\n防禦力: 155\r\n部署費用: 15\r\n技能冷卻時間: 40s\r\n技能說明: 對攻擊範圍內的敵人造成 2 倍傷害\r\n";
            this.lblMelantha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShaw
            // 
            this.lblShaw.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblShaw.Location = new System.Drawing.Point(446, 709);
            this.lblShaw.Name = "lblShaw";
            this.lblShaw.Size = new System.Drawing.Size(725, 200);
            this.lblShaw.TabIndex = 8;
            this.lblShaw.Text = "生命值: 1785\r\n攻擊力: 580\r\n防禦力: 365\r\n部署費用: 19\r\n技能冷卻時間: 5s\r\n技能說明: 對攻擊範圍內的所有敵人向前方推動一格\r\n";
            this.lblShaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartFight
            // 
            this.btnStartFight.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStartFight.Location = new System.Drawing.Point(1255, 91);
            this.btnStartFight.Name = "btnStartFight";
            this.btnStartFight.Size = new System.Drawing.Size(57, 818);
            this.btnStartFight.TabIndex = 9;
            this.btnStartFight.Text = "開始戰鬥";
            this.btnStartFight.UseVisualStyleBackColor = true;
            this.btnStartFight.Click += new System.EventHandler(this.btnStartFight_Click);
            // 
            // PickRolePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartFight);
            this.Controls.Add(this.lblShaw);
            this.Controls.Add(this.lblMelantha);
            this.Controls.Add(this.lblMyrtle);
            this.Controls.Add(this.lblCardigan);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnShaw);
            this.Controls.Add(this.btnMelantha);
            this.Controls.Add(this.btnMyrtle);
            this.Controls.Add(this.btnCardigan);
            this.Name = "PickRolePage";
            this.Size = new System.Drawing.Size(1500, 1000);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCardigan;
        private System.Windows.Forms.Button btnMyrtle;
        private System.Windows.Forms.Button btnMelantha;
        private System.Windows.Forms.Button btnShaw;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblCardigan;
        private System.Windows.Forms.Label lblMyrtle;
        private System.Windows.Forms.Label lblMelantha;
        private System.Windows.Forms.Label lblShaw;
        private System.Windows.Forms.Button btnStartFight;
    }
}
