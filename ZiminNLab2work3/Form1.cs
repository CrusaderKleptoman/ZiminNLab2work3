using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZiminNLab2work3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textWithSum.Text = Properties.Settings.Default.textWithSum.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textSum;
            try
            {
                textSum = this.textWithSum.Text;
            }
            catch (FormatException)
            {
                return;
            }

            Properties.Settings.Default.textWithSum = textSum;
            Properties.Settings.Default.Save();

            var sum = Logic.GetSum(textSum);
                
            this.rowSumLabel.Text = sum.ToString();
        }
    }

    public static class Logic
    {
        public static int GetSum(string rowSum)
        {

            string[] rowSumMembers = rowSum.Split('+', '-');

            char[] separators = new char[] { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            string[] memberSign = rowSum.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int sum = int.Parse(rowSumMembers[0]);

            for (int i = 1; i < rowSumMembers.Length; i++)
            {
                if (memberSign[i - 1].Equals("-"))
                {
                    sum -= int.Parse(rowSumMembers[i]);
                    continue;
                }

                sum += int.Parse(rowSumMembers[i]);
            }

            return sum;
        }
    }
}
