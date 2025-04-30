namespace case_1
{
    partial class Orders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NewOrderForm_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.order_richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Заказы";
            // 
            // NewOrderForm_button
            // 
            this.NewOrderForm_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewOrderForm_button.Location = new System.Drawing.Point(507, 49);
            this.NewOrderForm_button.Margin = new System.Windows.Forms.Padding(4);
            this.NewOrderForm_button.Name = "NewOrderForm_button";
            this.NewOrderForm_button.Size = new System.Drawing.Size(140, 44);
            this.NewOrderForm_button.TabIndex = 9;
            this.NewOrderForm_button.Text = "Новый заказ";
            this.NewOrderForm_button.UseVisualStyleBackColor = true;
            this.NewOrderForm_button.Click += new System.EventHandler(this.NewOrderForm_button_Click);
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(507, 101);
            this.back_button.Margin = new System.Windows.Forms.Padding(4);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(140, 44);
            this.back_button.TabIndex = 22;
            this.back_button.Text = "Назад";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // order_richTextBox
            // 
            this.order_richTextBox.Location = new System.Drawing.Point(17, 49);
            this.order_richTextBox.Name = "order_richTextBox";
            this.order_richTextBox.Size = new System.Drawing.Size(464, 150);
            this.order_richTextBox.TabIndex = 23;
            this.order_richTextBox.Text = "";
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(659, 228);
            this.Controls.Add(this.order_richTextBox);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.NewOrderForm_button);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Orders";
            this.Text = "Заказы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NewOrderForm_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.RichTextBox order_richTextBox;
    }
}