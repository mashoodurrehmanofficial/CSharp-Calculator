using System.Runtime.InteropServices;
using System;
using System.Data;
using System.Linq.Expressions;

namespace C__Calculator
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string Name = ((Form)sender).Name;
            Console.WriteLine(Name);
            string[] buttons = { "button1", "button2", "button3", "button4", "button5", "button6", "button7", "button8", "button9", "button10", "button11", "button12", "button13", "button14", "button17","button18","button19", };
            foreach (string button in buttons)
            { 
                var b = this.Controls[button];
                b.Click += new EventHandler(updateEquation);

            }

        }
        private void updateEquation(object sender, EventArgs e)
        {  
            string text = ((Button)sender).Text;
            text = text.Replace("(", " (").Replace(")", ") "); 
            resultBox.Text += text;
        }

        private void clearResultsBox(object sender, EventArgs e)
        {
            resultBox.Text = "";
        }
        private void evalteResults(object sender, EventArgs e)
        {
            string equation = resultBox.Text; 
            DataTable dt = new DataTable();
            try
            {
                var results = dt.Compute(equation, "");
                resultBox.Text = Convert.ToString(results);
            }
            catch
            {
                MessageBox.Show("Invalid Equation :(");
            }

        }
    }
}
