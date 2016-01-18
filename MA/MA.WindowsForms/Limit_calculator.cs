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


        private Stack<Summand> Stack_Numerator = new Stack<Summand>();

        private Stack<Summand> Stack_Denominator = new Stack<Summand>();

        private Stack<int> Stack_Numerator_Lenghts = new Stack<int>();

        private Stack<int> Stack_Denominator_Lenghts = new Stack<int>();

        public Limit_calculator()
        {
            InitializeComponent();
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
            if (string.IsNullOrWhiteSpace(NuText.Text) || string.IsNullOrWhiteSpace(DeText.Text) || string.IsNullOrWhiteSpace(XgoTo.Text))
            {
                ErrorBox.Text = "Fields can't be empty";
                return;
            }
            try
            {
                var normalizedFunction = new NormalizedFunction
                {
                    Numerator = Stack_Numerator.ToList(),
                    Denominator = Stack_Denominator.ToList()
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

            }
            catch(LimitDoesNotExistException)
            {
                Limit_Answer.Text = "Not exist";
            }
            catch(Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
            finally
            {
                CountLimit.Enabled = false;
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
                Stack_Numerator.Push(summ);
            }
            else
            {
                Stack_Denominator.Push(summ);
            }
        }

        public void AddToNuDeText(string message, bool Index)
        {
            int n = 0;
            if (Index)
            {
                if (NuText.Text != "")
                {
                    NuText.Text += "+";
                    n = 1;
                }
                n += message.Length;
                Stack_Numerator_Lenghts.Push(n);
                NuText.Text += message;
            }
            else
            {
                if (DeText.Text != "")
                {
                    n = 1;
                    DeText.Text += "+";
                }
                n += message.Length;
                Stack_Denominator_Lenghts.Push(n);
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
            Limit_Answer.Text = "Result";
            NuText.Text = "";
            DeText.Text = "";
            Stack_Numerator = new Stack<Summand>();
            Stack_Denominator = new Stack<Summand>();
            Stack_Numerator_Lenghts = new Stack<int>();
            Stack_Denominator_Lenghts = new Stack<int>();
            XgoTo.Text = "";
            CountLimit.Enabled = true;
            ErrorBox.Text = "Errors: 0";
        }

        private void Limit_Answer_Click(object sender, EventArgs e)
        {

        }

        public void SetVisable(bool value)
        {
            this.Visible = value;
        }

        private void Remove_From_Numerator_Click(object sender, EventArgs e)
        {
            if (Stack_Numerator.Count!=0)
            {
                Stack_Numerator.Pop();
                int n = Stack_Numerator_Lenghts.Pop();
                NuText.Text = NuText.Text.Substring(0, NuText.Text.Length - n);
            }
            else
            {
                ErrorBox.Text = "Element in numerator does not exist";
            }
        }

        private void Remove_From_Denominator_Click(object sender, EventArgs e)
        {
            if (Stack_Denominator.Count != 0)
            {
                Stack_Denominator.Pop();
                int n = Stack_Denominator_Lenghts.Pop();
                DeText.Text = DeText.Text.Substring(0, DeText.Text.Length - n);
            }
            else
            {
                ErrorBox.Text = "Element in denominator does not exist";
            }
        }

        private void ErrorBox_Click(object sender, EventArgs e)
        {

        }
    }
}
