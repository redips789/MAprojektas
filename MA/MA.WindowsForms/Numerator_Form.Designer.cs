namespace MA.WindowsForms
{
    partial class Numerator_Form
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
            this.Exit = new System.Windows.Forms.Button();
            this.SumTextBox = new System.Windows.Forms.TextBox();
            this.Add_X_From_Form = new System.Windows.Forms.Button();
            this.PowerFunctionButton = new System.Windows.Forms.Button();
            this.SineButton = new System.Windows.Forms.Button();
            this.CosineButton = new System.Windows.Forms.Button();
            this.ExponentialButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SumRaizedToPowerButton = new System.Windows.Forms.Button();
            this.Coefficient_Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(871, 27);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 22);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Add";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // SumTextBox
            // 
            this.SumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumTextBox.Location = new System.Drawing.Point(158, 29);
            this.SumTextBox.Name = "SumTextBox";
            this.SumTextBox.Size = new System.Drawing.Size(707, 20);
            this.SumTextBox.TabIndex = 1;
            this.SumTextBox.TextChanged += new System.EventHandler(this.SumTextBox_TextChanged);
            // 
            // Add_X_From_Form
            // 
            this.Add_X_From_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_X_From_Form.Location = new System.Drawing.Point(158, 55);
            this.Add_X_From_Form.Name = "Add_X_From_Form";
            this.Add_X_From_Form.Size = new System.Drawing.Size(100, 23);
            this.Add_X_From_Form.TabIndex = 7;
            this.Add_X_From_Form.Text = "x^b";
            this.Add_X_From_Form.UseVisualStyleBackColor = true;
            this.Add_X_From_Form.Click += new System.EventHandler(this.button1_Click);
            // 
            // PowerFunctionButton
            // 
            this.PowerFunctionButton.Location = new System.Drawing.Point(370, 55);
            this.PowerFunctionButton.Name = "PowerFunctionButton";
            this.PowerFunctionButton.Size = new System.Drawing.Size(100, 23);
            this.PowerFunctionButton.TabIndex = 8;
            this.PowerFunctionButton.Text = "(kx+b)^(n/m)";
            this.PowerFunctionButton.UseVisualStyleBackColor = true;
            this.PowerFunctionButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SineButton
            // 
            this.SineButton.Location = new System.Drawing.Point(264, 55);
            this.SineButton.Name = "SineButton";
            this.SineButton.Size = new System.Drawing.Size(100, 23);
            this.SineButton.TabIndex = 9;
            this.SineButton.Text = "sin(kx+b)";
            this.SineButton.UseVisualStyleBackColor = true;
            this.SineButton.Click += new System.EventHandler(this.SineButton_Click);
            // 
            // CosineButton
            // 
            this.CosineButton.Location = new System.Drawing.Point(476, 55);
            this.CosineButton.Name = "CosineButton";
            this.CosineButton.Size = new System.Drawing.Size(100, 23);
            this.CosineButton.TabIndex = 10;
            this.CosineButton.Text = "cos(kx+b)";
            this.CosineButton.UseVisualStyleBackColor = true;
            this.CosineButton.Click += new System.EventHandler(this.CosineButton_Click);
            // 
            // ExponentialButton
            // 
            this.ExponentialButton.Location = new System.Drawing.Point(582, 55);
            this.ExponentialButton.Name = "ExponentialButton";
            this.ExponentialButton.Size = new System.Drawing.Size(100, 23);
            this.ExponentialButton.TabIndex = 11;
            this.ExponentialButton.Text = "e^(kx+b)";
            this.ExponentialButton.UseVisualStyleBackColor = true;
            this.ExponentialButton.Click += new System.EventHandler(this.ExponentialButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(688, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "ln(kx+b)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SumRaizedToPowerButton
            // 
            this.SumRaizedToPowerButton.Location = new System.Drawing.Point(794, 55);
            this.SumRaizedToPowerButton.Name = "SumRaizedToPowerButton";
            this.SumRaizedToPowerButton.Size = new System.Drawing.Size(152, 23);
            this.SumRaizedToPowerButton.TabIndex = 13;
            this.SumRaizedToPowerButton.Text = "Sum raised";
            this.SumRaizedToPowerButton.UseVisualStyleBackColor = true;
            this.SumRaizedToPowerButton.Click += new System.EventHandler(this.SumRaizedToPowerButton_Click);
            // 
            // Coefficient_Text
            // 
            this.Coefficient_Text.Location = new System.Drawing.Point(16, 29);
            this.Coefficient_Text.Name = "Coefficient_Text";
            this.Coefficient_Text.Size = new System.Drawing.Size(110, 20);
            this.Coefficient_Text.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "*";
            // 
            // ErrorBox
            // 
            this.ErrorBox.AutoSize = true;
            this.ErrorBox.Location = new System.Drawing.Point(13, 83);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(46, 13);
            this.ErrorBox.TabIndex = 17;
            this.ErrorBox.Text = "Errors: 0";
            // 
            // Numerator_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 117);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Coefficient_Text);
            this.Controls.Add(this.SumRaizedToPowerButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ExponentialButton);
            this.Controls.Add(this.CosineButton);
            this.Controls.Add(this.SineButton);
            this.Controls.Add(this.PowerFunctionButton);
            this.Controls.Add(this.Add_X_From_Form);
            this.Controls.Add(this.SumTextBox);
            this.Controls.Add(this.Exit);
            this.Name = "Numerator_Form";
            this.Text = "Numerator";
            this.Load += new System.EventHandler(this.Numerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox SumTextBox;
        private System.Windows.Forms.Button Add_X_From_Form;
        private System.Windows.Forms.Button PowerFunctionButton;
        private System.Windows.Forms.Button SineButton;
        private System.Windows.Forms.Button CosineButton;
        private System.Windows.Forms.Button ExponentialButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button SumRaizedToPowerButton;
        private System.Windows.Forms.TextBox Coefficient_Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorBox;
    }
}