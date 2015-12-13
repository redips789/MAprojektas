using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MA.WindowsForms
{
    public partial class Add_ExponentialFunction : Form
    {
        private Interface_Numerator Num_F {get;set;}
        public Add_ExponentialFunction(Interface_Numerator num_f)
        {
            InitializeComponent();
            Num_F = num_f;
            this.Text = "Function";

        }

        private void AddX_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(Param_K.Text);
                double b = Convert.ToInt32(Param_B.Text);
                Num_F.Add_Exponential_To_Summand(a, b);
                Num_F.AddToSumTextBox("e^(" + Param_K.Text + "x+ " + Param_B.Text + " )");
                Num_F.SetVisable(true);
                this.Dispose();
            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Num_F.SetVisable(true);
            base.OnFormClosing(e);

        }
    }
}
