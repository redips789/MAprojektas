namespace MA.WindowsForms
{
    partial class Add_Simple_X
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
            this.XCoefficient = new System.Windows.Forms.TextBox();
            this.Poli = new System.Windows.Forms.Label();
            this.AddX = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // XCoefficient
            // 
            this.XCoefficient.Location = new System.Drawing.Point(130, 20);
            this.XCoefficient.Name = "XCoefficient";
            this.XCoefficient.Size = new System.Drawing.Size(26, 20);
            this.XCoefficient.TabIndex = 11;
            // 
            // Poli
            // 
            this.Poli.AutoSize = true;
            this.Poli.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Poli.Location = new System.Drawing.Point(85, 30);
            this.Poli.Name = "Poli";
            this.Poli.Size = new System.Drawing.Size(27, 31);
            this.Poli.TabIndex = 10;
            this.Poli.Text = "x";
            // 
            // AddX
            // 
            this.AddX.Location = new System.Drawing.Point(38, 81);
            this.AddX.Name = "AddX";
            this.AddX.Size = new System.Drawing.Size(118, 23);
            this.AddX.TabIndex = 7;
            this.AddX.Text = "Add";
            this.AddX.UseVisualStyleBackColor = true;
            this.AddX.Click += new System.EventHandler(this.AddX_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.AutoSize = true;
            this.ErrorBox.Location = new System.Drawing.Point(9, 107);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(46, 13);
            this.ErrorBox.TabIndex = 12;
            this.ErrorBox.Text = "Errors: 0";
            // 
            // Add_Simple_X
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 132);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.XCoefficient);
            this.Controls.Add(this.Poli);
            this.Controls.Add(this.AddX);
            this.Name = "Add_Simple_X";
            this.Text = "Add_Simple_X";
            this.Load += new System.EventHandler(this.Add_Simple_X_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox XCoefficient;
        private System.Windows.Forms.Label Poli;
        private System.Windows.Forms.Button AddX;
        private System.Windows.Forms.Label ErrorBox;
    }
}