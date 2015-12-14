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
    public partial class Add_Simple_X : Form
    {
        private Interface_Numerator Num_F { get; set; }
        public Add_Simple_X(Interface_Numerator num_f)
        {
            InitializeComponent();
            Num_F = num_f;
            this.Text = "Function";

        }

        private void Add_Simple_X_Load(object sender, EventArgs e)
        {

        }

        private void AddX_Click(object sender, EventArgs e)
        {
            try
            {
                int PolynomialDegree = Convert.ToInt32(XCoefficient.Text);

                Num_F.Add_Simple_X_To_Summand(PolynomialDegree);

                Num_F.AddToSumTextBox("(x^" + XCoefficient.Text + " )");
                Num_F.SetVisable(true);
                this.Dispose();
            }
            catch(Exception ex)
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
