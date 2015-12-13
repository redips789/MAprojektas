namespace MA.WindowsForms
{
    partial class Add_ExponentialFunction
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
            this.ErrorBox = new System.Windows.Forms.Label();
            this.AddX = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SinCosLn_Text = new System.Windows.Forms.Label();
            this.Param_K = new System.Windows.Forms.TextBox();
            this.Param_B = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ErrorBox
            // 
            this.ErrorBox.AutoSize = true;
            this.ErrorBox.Location = new System.Drawing.Point(12, 130);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(46, 13);
            this.ErrorBox.TabIndex = 20;
            this.ErrorBox.Text = "Errors: 0";
            // 
            // AddX
            // 
            this.AddX.Location = new System.Drawing.Point(81, 96);
            this.AddX.Name = "AddX";
            this.AddX.Size = new System.Drawing.Size(118, 23);
            this.AddX.TabIndex = 19;
            this.AddX.Text = "Add";
            this.AddX.UseVisualStyleBackColor = true;
            this.AddX.Click += new System.EventHandler(this.AddX_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = ")";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "x+";
            // 
            // SinCosLn_Text
            // 
            this.SinCosLn_Text.AutoSize = true;
            this.SinCosLn_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SinCosLn_Text.Location = new System.Drawing.Point(46, 49);
            this.SinCosLn_Text.Name = "SinCosLn_Text";
            this.SinCosLn_Text.Size = new System.Drawing.Size(29, 31);
            this.SinCosLn_Text.TabIndex = 16;
            this.SinCosLn_Text.Text = "e";
            // 
            // Param_K
            // 
            this.Param_K.Location = new System.Drawing.Point(87, 35);
            this.Param_K.Name = "Param_K";
            this.Param_K.Size = new System.Drawing.Size(32, 20);
            this.Param_K.TabIndex = 15;
            // 
            // Param_B
            // 
            this.Param_B.Location = new System.Drawing.Point(165, 35);
            this.Param_B.Name = "Param_B";
            this.Param_B.Size = new System.Drawing.Size(34, 20);
            this.Param_B.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "(";
            // 
            // Add_ExponentialFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.AddX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SinCosLn_Text);
            this.Controls.Add(this.Param_K);
            this.Controls.Add(this.Param_B);
            this.Name = "Add_ExponentialFunction";
            this.Text = "Add_ExponentialFunction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ErrorBox;
        private System.Windows.Forms.Button AddX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SinCosLn_Text;
        private System.Windows.Forms.TextBox Param_K;
        private System.Windows.Forms.TextBox Param_B;
        private System.Windows.Forms.Label label1;
    }
}