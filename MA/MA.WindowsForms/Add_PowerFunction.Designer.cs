namespace MA.WindowsForms
{
    partial class Add_PowerFunction
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
            this.Param_K_Text = new System.Windows.Forms.TextBox();
            this.Param_M_Text = new System.Windows.Forms.TextBox();
            this.Param_N_Text = new System.Windows.Forms.TextBox();
            this.Param_B_Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddX = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Param_K_Text
            // 
            this.Param_K_Text.Location = new System.Drawing.Point(39, 79);
            this.Param_K_Text.Name = "Param_K_Text";
            this.Param_K_Text.Size = new System.Drawing.Size(37, 20);
            this.Param_K_Text.TabIndex = 0;
            // 
            // Param_M_Text
            // 
            this.Param_M_Text.Location = new System.Drawing.Point(174, 51);
            this.Param_M_Text.Name = "Param_M_Text";
            this.Param_M_Text.Size = new System.Drawing.Size(54, 20);
            this.Param_M_Text.TabIndex = 1;
            // 
            // Param_N_Text
            // 
            this.Param_N_Text.Location = new System.Drawing.Point(176, 25);
            this.Param_N_Text.Name = "Param_N_Text";
            this.Param_N_Text.Size = new System.Drawing.Size(52, 20);
            this.Param_N_Text.TabIndex = 2;
            // 
            // Param_B_Text
            // 
            this.Param_B_Text.Location = new System.Drawing.Point(127, 79);
            this.Param_B_Text.Name = "Param_B_Text";
            this.Param_B_Text.Size = new System.Drawing.Size(38, 20);
            this.Param_B_Text.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "(";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "x +";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = ")";
            // 
            // AddX
            // 
            this.AddX.Location = new System.Drawing.Point(18, 105);
            this.AddX.Name = "AddX";
            this.AddX.Size = new System.Drawing.Size(209, 23);
            this.AddX.TabIndex = 7;
            this.AddX.Text = "Add";
            this.AddX.UseVisualStyleBackColor = true;
            this.AddX.Click += new System.EventHandler(this.AddX_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.AutoSize = true;
            this.ErrorBox.Location = new System.Drawing.Point(0, 149);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(46, 13);
            this.ErrorBox.TabIndex = 9;
            this.ErrorBox.Text = "Errors: 0";
            // 
            // Add_PowerFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 174);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.AddX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Param_B_Text);
            this.Controls.Add(this.Param_N_Text);
            this.Controls.Add(this.Param_M_Text);
            this.Controls.Add(this.Param_K_Text);
            this.Name = "Add_PowerFunction";
            this.Text = "Add_PowerFunction";
            this.Load += new System.EventHandler(this.Add_PowerFunction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Param_K_Text;
        private System.Windows.Forms.TextBox Param_M_Text;
        private System.Windows.Forms.TextBox Param_N_Text;
        private System.Windows.Forms.TextBox Param_B_Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddX;
        private System.Windows.Forms.Label ErrorBox;
    }
}