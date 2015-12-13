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
    public partial class Numerator_Form : Form, Interface_Numerator
    {
        private Interface_Limit_calculator Limits { get; set; }
        private Summand All_Functions { get; set; }

        private bool Index { get; set; }
        public Numerator_Form(Interface_Limit_calculator limit_calc, bool index, string formName)
        {
            InitializeComponent();
            Limits = limit_calc;
            SumTextBox.Enabled = false;
            All_Functions = new Summand();
            SumTextBox.Text = "";
            Index = index;
            this.Text = formName;
        }

        private void Numerator_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {

            Limits.AddToNumeratorDe(All_Functions, Index);
            Limits.AddToNuDeText(SumTextBox.Text, Index);
            Limits.SetVisable(true);
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddX_Click(object sender, EventArgs e)
        {
        
        }

        public void Add_Simple_X_To_Summand(double coefficient, int polynomialDegree)
        {
            All_Functions.Coefficient = coefficient;
            All_Functions.PolynomialDegree = polynomialDegree;
            Add_X_From_Form.Enabled = false;

        }
        public void Add_PowerFunction_To_Summand(double a, double b, int n, int m)
        {
            if (All_Functions.Multiplicands == null)
                All_Functions.Multiplicands = new List<IElementaryFunction>();
            All_Functions.Multiplicands.Add(new PowerFunction { Aparam = a, Bparam = b, PowerNumerator = n, PowerDenominator = m });
        }
        public void Add_SinCosLn_To_Summand(double a, double b, int index)
        {
            if (All_Functions.Multiplicands == null)
                All_Functions.Multiplicands = new List<IElementaryFunction>();
            if(index == 0)
                All_Functions.Multiplicands.Add(new Sine { Aparam = a, Bparam = b });
            if (index == 1)
                All_Functions.Multiplicands.Add(new Cosine { Aparam = a, Bparam = b });
            if (index == 2)
                All_Functions.Multiplicands.Add(new LogarithmicFunction { Aparam = a, Bparam = b });

        }
        public void Add_Exponential_To_Summand(double a, double b)
        {
            if (All_Functions.Multiplicands == null)
                All_Functions.Multiplicands = new List<IElementaryFunction>();
            All_Functions.Multiplicands.Add(new ExponentialFunction { Aparam = a, Bparam = b });
        }
        public void Add_SumRaisedToPower_To_Summand(SumRaisedToPower sum)
        {
            if (All_Functions.SumsRaisedToPower == null)
                All_Functions.SumsRaisedToPower = new List<SumRaisedToPower>();
            All_Functions.SumsRaisedToPower.Add(sum);
        }
        public void AddToSumTextBox(string message)
        {
            if (SumTextBox.Text != "")
                SumTextBox.Text += "*";
            SumTextBox.Text += message;
        }

        private void SumTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Simple_X add_x = new Add_Simple_X(this);
            add_x.Visible = true;
            this.Visible = false;
        }

        private void PowerFunctionButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_PowerFunction power = new Add_PowerFunction(this);
            power.Visible = true;
            this.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Limits.SetVisable(true);
            base.OnFormClosing(e);

        }

        private void SineButton_Click(object sender, EventArgs e)
        {
            Add_SineCosineLn sin = new Add_SineCosineLn(this, 0);
            sin.Visible = true;
            this.Visible = false;
        }

        private void CosineButton_Click(object sender, EventArgs e)
        {
            Add_SineCosineLn cos = new Add_SineCosineLn(this, 1);
            cos.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_SineCosineLn ln = new Add_SineCosineLn(this, 2);
            ln.Visible = true;
            this.Visible = false;
        }

        public void SetVisable(bool value)
        {
            this.Visible = value;
        }

        private void ExponentialButton_Click(object sender, EventArgs e)
        {
            Add_ExponentialFunction exp = new Add_ExponentialFunction(this);
            exp.Visible = true;
            this.Visible = false;
        }

        private void SumRaizedToPowerButton_Click(object sender, EventArgs e)
        {
            Add_SumRaisedToPower sum = new Add_SumRaisedToPower(this);
            sum.Visible = true;
            this.Visible = false;
        }
    }
}
