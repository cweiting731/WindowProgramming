namespace F74121246_Practice_3_2
{
    partial class AddOrderPage
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
            this.txtInfoGuide = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnPenguin = new System.Windows.Forms.Button();
            this.btnFriedPork = new System.Windows.Forms.Button();
            this.btnFriedShrimp = new System.Windows.Forms.Button();
            this.btnPassOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInfoGuide
            // 
            this.txtInfoGuide.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtInfoGuide.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtInfoGuide.Location = new System.Drawing.Point(140, 100);
            this.txtInfoGuide.Name = "txtInfoGuide";
            this.txtInfoGuide.ReadOnly = true;
            this.txtInfoGuide.Size = new System.Drawing.Size(700, 50);
            this.txtInfoGuide.TabIndex = 3;
            this.txtInfoGuide.TabStop = false;
            this.txtInfoGuide.Text = "輸入數量並選擇商品後，按下送出 !";
            this.txtInfoGuide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAmount.Location = new System.Drawing.Point(133, 180);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(177, 40);
            this.labelAmount.TabIndex = 4;
            this.labelAmount.Text = "請輸入數量";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAmount.Location = new System.Drawing.Point(310, 180);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(530, 50);
            this.txtAmount.TabIndex = 5;
            // 
            // btnPenguin
            // 
            this.btnPenguin.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPenguin.Location = new System.Drawing.Point(140, 313);
            this.btnPenguin.Name = "btnPenguin";
            this.btnPenguin.Size = new System.Drawing.Size(200, 150);
            this.btnPenguin.TabIndex = 6;
            this.btnPenguin.Text = "企鵝";
            this.btnPenguin.UseVisualStyleBackColor = true;
            this.btnPenguin.Click += new System.EventHandler(this.btnPenguin_Click);
            // 
            // btnFriedPork
            // 
            this.btnFriedPork.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFriedPork.Location = new System.Drawing.Point(385, 313);
            this.btnFriedPork.Name = "btnFriedPork";
            this.btnFriedPork.Size = new System.Drawing.Size(200, 150);
            this.btnFriedPork.TabIndex = 7;
            this.btnFriedPork.Text = "炸豬排";
            this.btnFriedPork.UseVisualStyleBackColor = true;
            this.btnFriedPork.Click += new System.EventHandler(this.btnFriedPork_Click);
            // 
            // btnFriedShrimp
            // 
            this.btnFriedShrimp.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFriedShrimp.Location = new System.Drawing.Point(640, 313);
            this.btnFriedShrimp.Name = "btnFriedShrimp";
            this.btnFriedShrimp.Size = new System.Drawing.Size(200, 150);
            this.btnFriedShrimp.TabIndex = 8;
            this.btnFriedShrimp.Text = "炸蝦";
            this.btnFriedShrimp.UseVisualStyleBackColor = true;
            this.btnFriedShrimp.Click += new System.EventHandler(this.btnFriedShrimp_Click);
            // 
            // btnPassOrder
            // 
            this.btnPassOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPassOrder.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPassOrder.Location = new System.Drawing.Point(385, 497);
            this.btnPassOrder.Name = "btnPassOrder";
            this.btnPassOrder.Size = new System.Drawing.Size(196, 140);
            this.btnPassOrder.TabIndex = 9;
            this.btnPassOrder.Text = "送出訂單";
            this.btnPassOrder.UseVisualStyleBackColor = false;
            this.btnPassOrder.Click += new System.EventHandler(this.btnPassOrder_Click);
            // 
            // AddOrderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPassOrder);
            this.Controls.Add(this.btnFriedShrimp);
            this.Controls.Add(this.btnFriedPork);
            this.Controls.Add(this.btnPenguin);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.txtInfoGuide);
            this.Name = "AddOrderPage";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Resize += new System.EventHandler(this.AddOrderPage_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfoGuide;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnPenguin;
        private System.Windows.Forms.Button btnFriedPork;
        private System.Windows.Forms.Button btnFriedShrimp;
        private System.Windows.Forms.Button btnPassOrder;
    }
}
