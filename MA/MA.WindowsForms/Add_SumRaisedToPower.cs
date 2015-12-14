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
    public partial class Add_SumRaisedToPower : Form, Interface_Limit_calculator
    {
        private SumRaisedToPower Sum_To_Power { get; set; }
        private Interface_Numerator Num_F { get; set; }

        private Stack<Summand> Stack_Sum= new Stack<Summand>();

        private Stack<int> Stack_Sum_Lenghts = new Stack<int>();

        public Add_SumRaisedToPower(Interface_Numerator num_f)
        {
            InitializeComponent();
            Num_F = num_f;
            Sum_To_Power = new SumRaisedToPower();
            this.Text = "New sum";
            SumTextBox.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_SumRaisedToPower_Load(object sender, EventArgs e)
        {

        }

        public void SetVisable(bool value)
        {
            this.Visible = value;
        }

        public void AddToNumeratorDe(Summand summ, bool index)
        {
            //if (Sum_To_Power.Sum == null)
            //    Sum_To_Power.Sum = new List<Summand>();
            Stack_Sum.Push(summ);
        }

        public void AddToNuDeText(string message, bool Index)
        {
            int n = 0;
                if (SumTextBox.Text != "")
                {
                    SumTextBox.Text += "+";
                    n = 1;
                }
                n += message.Length;
                Stack_Sum_Lenghts.Push(n);
                SumTextBox.Text += message;
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SumTextBox.Text) || string.IsNullOrWhiteSpace(Degree.Text))
            {
                ErrorBox.Text = "Fields can't be empty";
                return;
            }
            try
            {
                Sum_To_Power.Sum = Stack_Sum.ToList();
                Sum_To_Power.Degree = Convert.ToInt32(Degree.Text);
                Num_F.Add_SumRaisedToPower_To_Summand(Sum_To_Power);
                Num_F.AddToSumTextBox("(" + SumTextBox.Text + ")^" + Degree.Text);
                Num_F.SetVisable(true);
                this.Dispose();
            }
            catch(Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }

        private void Add_Summ_Button_Click(object sender, EventArgs e)
        {
            Numerator_Form num = new Numerator_Form(this, true, "Functions");
            num.Visible = true;
            this.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Num_F.SetVisable(true);
            base.OnFormClosing(e);

        }

        private void Remove_From_Sum_Click(object sender, EventArgs e)
        {
            if (Stack_Sum.Count != 0)
            {
                Stack_Sum.Pop();
                int n = Stack_Sum_Lenghts.Pop();
                SumTextBox.Text = SumTextBox.Text.Substring(0, SumTextBox.Text.Length - n);
            }
            else
            {
                ErrorBox.Text = "Element in denominator does not exist";
            }
        }
    }
}
