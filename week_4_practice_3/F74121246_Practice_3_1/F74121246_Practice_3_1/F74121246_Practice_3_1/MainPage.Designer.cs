﻿namespace F74121246_Practice_3_1
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
            this.txtInfoGuide = new System.Windows.Forms.TextBox();
            this.listBoxOrder = new System.Windows.Forms.ListBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnListOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInfoGuide
            // 
            this.txtInfoGuide.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtInfoGuide.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtInfoGuide.Location = new System.Drawing.Point(132, 79);
            this.txtInfoGuide.Name = "txtInfoGuide";
            this.txtInfoGuide.ReadOnly = true;
            this.txtInfoGuide.Size = new System.Drawing.Size(700, 50);
            this.txtInfoGuide.TabIndex = 0;
            this.txtInfoGuide.Text = "歡迎登入 admin !";
            this.txtInfoGuide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxOrder
            // 
            this.listBoxOrder.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxOrder.FormattingEnabled = true;
            this.listBoxOrder.ItemHeight = 35;
            this.listBoxOrder.Location = new System.Drawing.Point(283, 165);
            this.listBoxOrder.Name = "listBoxOrder";
            this.listBoxOrder.Size = new System.Drawing.Size(549, 389);
            this.listBoxOrder.TabIndex = 1;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.AutoSize = true;
            this.btnAddOrder.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddOrder.Location = new System.Drawing.Point(132, 165);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(155, 50);
            this.btnAddOrder.TabIndex = 2;
            this.btnAddOrder.Text = "新增訂單";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnListOrder
            // 
            this.btnListOrder.AutoSize = true;
            this.btnListOrder.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnListOrder.Location = new System.Drawing.Point(132, 221);
            this.btnListOrder.Name = "btnListOrder";
            this.btnListOrder.Size = new System.Drawing.Size(155, 50);
            this.btnListOrder.TabIndex = 3;
            this.btnListOrder.Text = "列出訂單";
            this.btnListOrder.UseVisualStyleBackColor = true;
            this.btnListOrder.Click += new System.EventHandler(this.btnListOrder_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnListOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.listBoxOrder);
            this.Controls.Add(this.txtInfoGuide);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Resize += new System.EventHandler(this.MainPage_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfoGuide;
        private System.Windows.Forms.ListBox listBoxOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnListOrder;
    }
}
