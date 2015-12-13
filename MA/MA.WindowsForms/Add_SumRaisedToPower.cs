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

        public Add_SumRaisedToPower(Interface_Numerator num_f)
        {
            InitializeComponent();
            Num_F = num_f;
            Sum_To_Power = new SumRaisedToPower();
            this.Text = "New sum";
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
            if (Sum_To_Power.Sum == null)
                Sum_To_Power.Sum = new List<Summand>();
            Sum_To_Power.Sum.Add(summ);
        }

        public void AddToNuDeText(string message, bool Index)
        {
                if (SumTextBox.Text != "")
                {
                    SumTextBox.Text += "+";
                }
                SumTextBox.Text += message;
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            try
            {
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
    }
}
