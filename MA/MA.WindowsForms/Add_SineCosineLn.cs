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
    public partial class Add_SineCosineLn : Form
    {
        private Interface_Numerator Num_F { get; set; }
        private int SinCosLn { get; set; }
        List<string> text_values;
        public Add_SineCosineLn(Interface_Numerator num_f, int sinCosLn)
        {
            InitializeComponent();
            Num_F = num_f;
            SinCosLn = sinCosLn;
            text_values = new List<string>();
            text_values.Add("sin (");
            text_values.Add("cos (");
            text_values.Add("ln (");
            SinCosLn_Text.Text = text_values[SinCosLn];
            this.Text = "Function";
        }

        private void AddX_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(Param_K.Text);
                double b = Convert.ToInt32(Param_B.Text);
                Num_F.Add_SinCosLn_To_Summand(a, b, SinCosLn);
                Num_F.AddToSumTextBox(text_values[SinCosLn] + Param_K.Text + "x+ " + Param_B.Text + " )");
                Num_F.SetVisable(true);
                this.Dispose();
            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }

        private void Add_SineCosineLn_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Num_F.SetVisable(true);
            base.OnFormClosing(e);

        }
    }
}
