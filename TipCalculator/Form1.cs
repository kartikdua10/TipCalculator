using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // More than one decimal validation for field Bill
            string[] test = Bill.Text.Split('.');
            int decimalPos = Bill.Text.IndexOf('.');
            string billDecimal = Bill.Text.Substring(decimalPos+1);
            if (billDecimal.Contains('.'))
            {
                MessageBox.Show("Invalid Bill input");
                Bill.Clear();
                labelClear();
            }

            //decimal part greater than 3 validation for field bill
            else if (test.Length == 2 && test[1].Length >= 3)
            {
                MessageBox.Show("Bill cannot have more than 2 decimal places");
                Bill.Clear();
                labelClear();
            }

            // Null or empty validation for field Bill
            else if (!String.IsNullOrEmpty(Bill.Text) && Decimal.Parse(Bill.Text) != 0)
            {
                decimal billAmount = Decimal.Parse(Bill.Text);
                decimal tipAmount = billAmount * (tipPercent.Value / 100);

                decimal tipAmountPerPerson = Math.Round(tipAmount / numberOfPeople.Value, 2);
                decimal totalBillPerPerson = Math.Round((billAmount + tipAmount) / numberOfPeople.Value,2);

                label8.Text = "Rs " + tipAmountPerPerson.ToString();
                label9.Text = "Rs " + totalBillPerPerson.ToString();
            }
            else
            {
                MessageBox.Show("Bill cannot be empty or Zero.");
                Bill.Clear();
            }
            
        }

        // method for clearing labels
        private void labelClear()
        {
            label8.Text = "Rs 00.00";
            label9.Text = "Rs 00.00";
        }

        // Non-numeric validation for the field Bill.
        private void Bill_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals('.');
        }
    }
}
