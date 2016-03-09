using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureConverterCalculator
{
    public partial class TempCalculator : Form
    {
        public TempCalculator()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }


        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
            textBox1.Focus();
            textBox1.Select(50, 0);
        }


        private void button3_Click(object sender, EventArgs e)  //convert button
        {
            double userValue;

            if (Double.TryParse(textBox1.Text, out userValue) == false)
            {
                MessageBox.Show("Please type a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                if (fTocButton.Checked)  //convert from F to C
                {
                    Calculate(((userValue - 32) / (1.8)), "°C");
                    
                }
                else if (kTocButton.Checked)  //convert from K to C
                {
                    Calculate(userValue - 273.15, "°C");
                }
                else if (cTofButton.Checked)  //convert from C to F
                {
                    Calculate(((userValue * 9 / 5) + 32),"°F");
                }
                else if (kTofButton.Checked)  //convert from K to F
                {
                    Calculate(((userValue - 273.15) * 9 / 5 + 32),"°F");
                }
                else if (fTokButton.Checked)  //convert from F to K
                {
                    Calculate(((userValue - 32) * 5 / 9 + 273.15), " K");
                }
                else if (cTokButton.Checked)  //convert from C to K
                {
                    Calculate((userValue + 273.15)," K");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);  //exits the program with an exit code of 0.
        }
        


        public void Calculate(double answer, string symbol)
        {
            answer = Math.Round(answer, 2);
             label1.Text = answer.ToString() + symbol;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Type in a number, choose the option to convert it as you wish, and "+
            "simply hit the Convert button to see the result.", 
            "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutTempCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Temperature Calculator is created by Chris Korokous and available for "
            +"viewing on GitHub.",
            "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        
        
    }
   
}
