using System;
using System.Windows.Forms;

namespace RedCell.App.Calculator.Example
{
    public partial class Form1 : Form
    {
        private double accumulator = 0;
        private char lastOperation;

        public Form1()
        {
            InitializeComponent();
        }

        private void Operator_Pressed(object sender, EventArgs e)
        {
            // An operator was pressed; perform the last operation and store the new operator.
            char operation = (sender as Button).Text[0];
            if (operation == 'C')
            {
                accumulator = 0;
            }
            else
            {
                double currentValue = double.Parse(Display.Text);
                switch (lastOperation)
                {
                    case '+': accumulator += currentValue; break;
                    case '-': accumulator -= currentValue; break;
                    case '×': accumulator *= currentValue; break;
                    case '÷': accumulator /= currentValue; break;
                    default: accumulator = currentValue; break;
                }
            }

            lastOperation = operation;
            Display.Text = operation == '=' ? accumulator.ToString() : "0";
        }

        private void Number_Pressed(object sender, EventArgs e)
        {
            // Extract the number from the button
            string number = (sender as Button).Text;
            //If the display text is 0 then delete it and display the extracted number
            //else display the extracted number next to the existed one.
            Display.Text = Display.Text == "0" ? number : Display.Text + number;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
