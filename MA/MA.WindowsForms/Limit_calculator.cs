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
    public partial class Limit_calculator : Form, Interface_Limit_calculator
    {
        private Numerator_Form Form_Numerator { get; set; }

        private Numerator_Form Form_Denominator { get; set; }

        private List<Summand> V_Numerator { get; set; }

        private List<Summand> V_Denominator { get; set; }
        public Limit_calculator()
        {
            InitializeComponent();
            V_Numerator = new List<Summand>();
            V_Denominator = new List<Summand>();
            NuText.Enabled = false;
            DeText.Enabled = false;
            NuText.Text = "";
            DeText.Text = "";
            XgoTo.Text = "";
            this.Text = "Limit calculator";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void CountLimit_Click(object sender, EventArgs e)
        {
            try
            {
                var normalizedFunction = new NormalizedFunction
                {
                    Numerator = V_Numerator,
                    Denominator = V_Denominator
                };
                var result = LimitCalculator.CalculateLimit(normalizedFunction, Convert.ToDouble(XgoTo.Text));
                if(result.LimitResultType == LimitResultType.RealNumber)
                     Limit_Answer.Text = Convert.ToString(result.Value);
                if (result.LimitResultType == LimitResultType.DoesNotExist)
                    Limit_Answer.Text = "Not exist";
                if (result.LimitResultType == LimitResultType.PositiveInfinity)
                    Limit_Answer.Text = "Positive infinity";
                if (result.LimitResultType == LimitResultType.NegativeInfinity)
                    Limit_Answer.Text = "Negative infinity";

                CountLimit.Enabled = false;
            }
            catch(Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }

        }

        private void AddToNu_Click(object sender, EventArgs e)
        {
            Form_Numerator = new Numerator_Form(this,true,"Numerator");
            this.Visible = false;
            Form_Numerator.Visible = true;
            ErrorBox.Text = "Errors: 0";

        }

        public void AddToNumeratorDe(Summand summ, bool index)
        {
            if(index)
            {
                V_Numerator.Add(summ);
            }
            else
            {
                V_Denominator.Add(summ);
            }
        }

        public void AddToNuDeText(string message, bool Index)
        {
            if (Index)
            {
                if (NuText.Text != "")
                {
                    NuText.Text += "+";
                }
                NuText.Text += message;
            }
            else
            {
                if (DeText.Text != "")
                {
                    DeText.Text += "+";
                }
                DeText.Text += message;
            }
        }

        private void AddToDe_Click(object sender, EventArgs e)
        {
            Form_Denominator = new Numerator_Form(this, false,"Denominator");
            this.Visible = false;
            Form_Denominator.Visible = true;
            ErrorBox.Text = "Errors: 0";
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            Limit_Answer.Text = "Limit";
            NuText.Text = "";
            DeText.Text = "";
            V_Numerator = new List<Summand>();
            V_Denominator = new List<Summand>();
            XgoTo.Text = "";
            CountLimit.Enabled = true;
        }

        private void Limit_Answer_Click(object sender, EventArgs e)
        {

        }

        public void SetVisable(bool value)
        {
            this.Visible = value;
        }
    }
}
