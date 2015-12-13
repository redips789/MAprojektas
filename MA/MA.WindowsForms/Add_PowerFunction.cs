using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using MA.Limits;

namespace MA.WindowsForms
{
    public partial class Add_PowerFunction : Form
    {
        private Interface_Numerator Num_F { get; set; }
        public Add_PowerFunction(Interface_Numerator num_f)
        {
            InitializeComponent();
            Num_F = num_f;
            this.Text = "Function";
        }

        private void AddX_Click(object sender, EventArgs e)
        {
            try
            {

                double Aparam = Convert.ToDouble(Param_K_Text.Text);
                double Bparam = Convert.ToDouble(Param_B_Text.Text);
                int n = Convert.ToInt32(Param_N_Text.Text);
                int m = Convert.ToInt32(Param_M_Text.Text);

                Num_F.Add_PowerFunction_To_Summand(Aparam, Bparam, n, m);
                Num_F.AddToSumTextBox("(" + "(" + Param_K_Text.Text + "x+" + Param_B_Text.Text + ")^(" + Param_N_Text.Text + "/" + Param_M_Text.Text + ")" + ")");
                Num_F.SetVisable(true);
                this.Dispose();
            }
            catch(Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }

        private void Add_PowerFunction_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Num_F.SetVisable(true);
            base.OnFormClosing(e);

        }
    }
}
