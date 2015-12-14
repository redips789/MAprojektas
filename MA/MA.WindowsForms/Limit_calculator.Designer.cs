namespace MA.WindowsForms
{
    partial class Limit_calculator
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
            this.lim_label = new System.Windows.Forms.Label();
            this.x_goes_to_dont_touch = new System.Windows.Forms.Label();
            this.NuText = new System.Windows.Forms.TextBox();
            this.DeText = new System.Windows.Forms.TextBox();
            this.XgoTo = new System.Windows.Forms.TextBox();
            this.AddToNu = new System.Windows.Forms.Button();
            this.AddToDe = new System.Windows.Forms.Button();
            this.CountLimit = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.Label();
            this.Limit_Answer = new System.Windows.Forms.Label();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Remove_From_Numerator = new System.Windows.Forms.Button();
            this.Remove_From_Denominator = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lim_label
            // 
            this.lim_label.AutoSize = true;
            this.lim_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lim_label.Location = new System.Drawing.Point(13, 119);
            this.lim_label.Name = "lim_label";
            this.lim_label.Size = new System.Drawing.Size(71, 46);
            this.lim_label.TabIndex = 0;
            this.lim_label.Text = "lim";
            this.lim_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // x_goes_to_dont_touch
            // 
            this.x_goes_to_dont_touch.AutoSize = true;
            this.x_goes_to_dont_touch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_goes_to_dont_touch.Location = new System.Drawing.Point(16, 168);
            this.x_goes_to_dont_touch.Name = "x_goes_to_dont_touch";
            this.x_goes_to_dont_touch.Size = new System.Drawing.Size(41, 25);
            this.x_goes_to_dont_touch.TabIndex = 1;
            this.x_goes_to_dont_touch.Text = "x->";
            this.x_goes_to_dont_touch.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // NuText
            // 
            this.NuText.Location = new System.Drawing.Point(103, 119);
            this.NuText.Name = "NuText";
            this.NuText.Size = new System.Drawing.Size(549, 20);
            this.NuText.TabIndex = 2;
            // 
            // DeText
            // 
            this.DeText.Location = new System.Drawing.Point(103, 145);
            this.DeText.Name = "DeText";
            this.DeText.Size = new System.Drawing.Size(549, 20);
            this.DeText.TabIndex = 3;
            // 
            // XgoTo
            // 
            this.XgoTo.Location = new System.Drawing.Point(63, 168);
            this.XgoTo.Name = "XgoTo";
            this.XgoTo.Size = new System.Drawing.Size(34, 20);
            this.XgoTo.TabIndex = 4;
            // 
            // AddToNu
            // 
            this.AddToNu.Location = new System.Drawing.Point(658, 116);
            this.AddToNu.Name = "AddToNu";
            this.AddToNu.Size = new System.Drawing.Size(113, 23);
            this.AddToNu.TabIndex = 5;
            this.AddToNu.Text = "Add to Numerator";
            this.AddToNu.UseVisualStyleBackColor = true;
            this.AddToNu.Click += new System.EventHandler(this.AddToNu_Click);
            // 
            // AddToDe
            // 
            this.AddToDe.Location = new System.Drawing.Point(658, 145);
            this.AddToDe.Name = "AddToDe";
            this.AddToDe.Size = new System.Drawing.Size(113, 23);
            this.AddToDe.TabIndex = 6;
            this.AddToDe.Text = "Add to Denominator";
            this.AddToDe.UseVisualStyleBackColor = true;
            this.AddToDe.Click += new System.EventHandler(this.AddToDe_Click);
            // 
            // CountLimit
            // 
            this.CountLimit.Location = new System.Drawing.Point(620, 174);
            this.CountLimit.Name = "CountLimit";
            this.CountLimit.Size = new System.Drawing.Size(151, 74);
            this.CountLimit.TabIndex = 7;
            this.CountLimit.Text = "Count Limit";
            this.CountLimit.UseVisualStyleBackColor = true;
            this.CountLimit.Click += new System.EventHandler(this.CountLimit_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.AutoSize = true;
            this.ErrorBox.Location = new System.Drawing.Point(21, 280);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(46, 13);
            this.ErrorBox.TabIndex = 8;
            this.ErrorBox.Text = "Errors: 0";
            // 
            // Limit_Answer
            // 
            this.Limit_Answer.AutoSize = true;
            this.Limit_Answer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Limit_Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limit_Answer.Location = new System.Drawing.Point(97, 217);
            this.Limit_Answer.Name = "Limit_Answer";
            this.Limit_Answer.Size = new System.Drawing.Size(92, 31);
            this.Limit_Answer.TabIndex = 9;
            this.Limit_Answer.Text = "Result";
            this.Limit_Answer.Click += new System.EventHandler(this.Limit_Answer_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(620, 255);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(151, 23);
            this.Reset_Button.TabIndex = 10;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // Remove_From_Numerator
            // 
            this.Remove_From_Numerator.Location = new System.Drawing.Point(777, 116);
            this.Remove_From_Numerator.Name = "Remove_From_Numerator";
            this.Remove_From_Numerator.Size = new System.Drawing.Size(75, 23);
            this.Remove_From_Numerator.TabIndex = 11;
            this.Remove_From_Numerator.Text = "Remove last";
            this.Remove_From_Numerator.UseVisualStyleBackColor = true;
            this.Remove_From_Numerator.Click += new System.EventHandler(this.Remove_From_Numerator_Click);
            // 
            // Remove_From_Denominator
            // 
            this.Remove_From_Denominator.Location = new System.Drawing.Point(778, 145);
            this.Remove_From_Denominator.Name = "Remove_From_Denominator";
            this.Remove_From_Denominator.Size = new System.Drawing.Size(75, 23);
            this.Remove_From_Denominator.TabIndex = 12;
            this.Remove_From_Denominator.Text = "Remove last";
            this.Remove_From_Denominator.UseVisualStyleBackColor = true;
            this.Remove_From_Denominator.Click += new System.EventHandler(this.Remove_From_Denominator_Click);
            // 
            // Limit_calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 305);
            this.Controls.Add(this.Remove_From_Denominator);
            this.Controls.Add(this.Remove_From_Numerator);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Limit_Answer);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.CountLimit);
            this.Controls.Add(this.AddToDe);
            this.Controls.Add(this.AddToNu);
            this.Controls.Add(this.XgoTo);
            this.Controls.Add(this.DeText);
            this.Controls.Add(this.NuText);
            this.Controls.Add(this.x_goes_to_dont_touch);
            this.Controls.Add(this.lim_label);
            this.Name = "Limit_calculator";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lim_label;
        private System.Windows.Forms.Label x_goes_to_dont_touch;
        private System.Windows.Forms.TextBox NuText;
        private System.Windows.Forms.TextBox DeText;
        private System.Windows.Forms.TextBox XgoTo;
        private System.Windows.Forms.Button AddToNu;
        private System.Windows.Forms.Button AddToDe;
        private System.Windows.Forms.Button CountLimit;
        private System.Windows.Forms.Label ErrorBox;
        private System.Windows.Forms.Label Limit_Answer;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button Remove_From_Numerator;
        private System.Windows.Forms.Button Remove_From_Denominator;
    }
}

