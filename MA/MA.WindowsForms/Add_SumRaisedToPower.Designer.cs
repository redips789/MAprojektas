namespace MA.WindowsForms
{
    partial class Add_SumRaisedToPower
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
            this.SumTextBox = new System.Windows.Forms.TextBox();
            this.Done_Button = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.Label();
            this.Add_Summ_Button = new System.Windows.Forms.Button();
            this.Degree = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SumTextBox
            // 
            this.SumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumTextBox.Location = new System.Drawing.Point(27, 39);
            this.SumTextBox.Name = "SumTextBox";
            this.SumTextBox.Size = new System.Drawing.Size(564, 20);
            this.SumTextBox.TabIndex = 3;
            // 
            // Done_Button
            // 
            this.Done_Button.Location = new System.Drawing.Point(417, 65);
            this.Done_Button.Name = "Done_Button";
            this.Done_Button.Size = new System.Drawing.Size(174, 39);
            this.Done_Button.TabIndex = 2;
            this.Done_Button.Text = "Done";
            this.Done_Button.UseVisualStyleBackColor = true;
            this.Done_Button.Click += new System.EventHandler(this.Done_Button_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.AutoSize = true;
            this.ErrorBox.Location = new System.Drawing.Point(12, 122);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(46, 13);
            this.ErrorBox.TabIndex = 14;
            this.ErrorBox.Text = "Errors: 0";
            // 
            // Add_Summ_Button
            // 
            this.Add_Summ_Button.Location = new System.Drawing.Point(27, 65);
            this.Add_Summ_Button.Name = "Add_Summ_Button";
            this.Add_Summ_Button.Size = new System.Drawing.Size(158, 39);
            this.Add_Summ_Button.TabIndex = 15;
            this.Add_Summ_Button.Text = "Add";
            this.Add_Summ_Button.UseVisualStyleBackColor = true;
            this.Add_Summ_Button.Click += new System.EventHandler(this.Add_Summ_Button_Click);
            // 
            // Degree
            // 
            this.Degree.Location = new System.Drawing.Point(603, 12);
            this.Degree.Name = "Degree";
            this.Degree.Size = new System.Drawing.Size(34, 20);
            this.Degree.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(598, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = ")";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "(";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Add_SumRaisedToPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 148);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Degree);
            this.Controls.Add(this.Add_Summ_Button);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.SumTextBox);
            this.Controls.Add(this.Done_Button);
            this.Name = "Add_SumRaisedToPower";
            this.Text = "Add_SumRaisedToPower";
            this.Load += new System.EventHandler(this.Add_SumRaisedToPower_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SumTextBox;
        private System.Windows.Forms.Button Done_Button;
        private System.Windows.Forms.Label ErrorBox;
        private System.Windows.Forms.Button Add_Summ_Button;
        private System.Windows.Forms.TextBox Degree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}