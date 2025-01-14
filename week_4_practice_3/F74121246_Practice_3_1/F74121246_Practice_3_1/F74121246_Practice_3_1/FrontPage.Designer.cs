namespace F74121246_Practice_3_1
{
    partial class FrontPage
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
            this.infoGuide = new System.Windows.Forms.TextBox();
            this.btnOpenShop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoGuide
            // 
            this.infoGuide.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.infoGuide.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infoGuide.Location = new System.Drawing.Point(133, 79);
            this.infoGuide.Name = "infoGuide";
            this.infoGuide.ReadOnly = true;
            this.infoGuide.Size = new System.Drawing.Size(700, 50);
            this.infoGuide.TabIndex = 0;
            this.infoGuide.Text = "歡迎來到角落生物商店 !";
            this.infoGuide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOpenShop
            // 
            this.btnOpenShop.AutoSize = true;
            this.btnOpenShop.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpenShop.Location = new System.Drawing.Point(355, 293);
            this.btnOpenShop.Name = "btnOpenShop";
            this.btnOpenShop.Size = new System.Drawing.Size(250, 250);
            this.btnOpenShop.TabIndex = 1;
            this.btnOpenShop.Text = "開店";
            this.btnOpenShop.UseVisualStyleBackColor = true;
            this.btnOpenShop.Click += new System.EventHandler(this.BtnOpenShop_Click);
            // 
            // FrontPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpenShop);
            this.Controls.Add(this.infoGuide);
            this.Name = "FrontPage";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.FrontPage_Load);
            this.Resize += new System.EventHandler(this.FrontPage_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox infoGuide;
        private System.Windows.Forms.Button btnOpenShop;
    }
}
