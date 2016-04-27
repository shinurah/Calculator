using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Calculator
{
    public partial class Calculator : Form
    {
        string input = string.Empty;
        string temperatureInput = string.Empty;
        string operation;
        double result = 0.0;

        List<string> operands = new List<string>();

        public Calculator()
        {
            InitializeComponent();
            BasicPanel.BringToFront();
            menuStrip1.BringToFront();
            TemperaturePanel.Enabled = false;
            BasicPanel.Enabled = true;
            SetDefault(equals);

            tempFromCombo.Items.Add("Celsius");
            tempFromCombo.Items.Add("Fahrenheit");
            tempFromCombo.Items.Add("Kelvin");
            tempFromCombo.SelectedItem = "Celsius";

            tempToCombo.Items.Add("Celsius");
            tempToCombo.Items.Add("Fahrenheit");
            tempToCombo.Items.Add("Kelvin");
            tempToCombo.SelectedItem = "Fahrenheit";
        }

        static class ConvertTemp
        {
            public static double ConvertCelsiusToFahrenheit(double c)
            {
                return ((9.0 / 5.0) * c) + 32;
            }
            public static double ConvertCelsiusToKelvin(double c)
            {
                return (c + 273.15);
            }
            public static double ConvertFahrenheitToCelsius(double f)
            {
                return (5.0 / 9.0) * (f - 32.0);
            }
            public static double ConvertFahrenheitToKelvin(double f)
            {
                return ((f + 459.67) * (5 / 9));
            }
            public static double ConvertKelvinToCelsius(double k)
            {
                return (k - 273.15);
            }
            public static double ConvertKelvinToFahrenheit(double k)
            {
                return ((k - 273.15) * 1.8000 + 32.0);
            }
        }
        // All digits and point "."
        private void btn_1_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "1";
            answerBox.Text += input;
        }

        private void btn_2_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "2";
            answerBox.Text += input;
        }

        private void btn_3_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "3";
            answerBox.Text += input;
        }

        private void btn_4_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "4";
            answerBox.Text += input;
        }

        private void btn_5_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "5";
            answerBox.Text += input;
        }

        private void btn_6_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "6";
            answerBox.Text += input;
        }

        private void btn_7_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "7";
            answerBox.Text += input;
        }

        private void btn_8_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "8";
            answerBox.Text += input;
        }

        private void btn_9_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "9";
            answerBox.Text += input;
        }

        private void btn_0_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += "0";
            answerBox.Text += input;
        }

        private void btn_point_click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            input += ",";
            answerBox.Text += input;
        }

        // Operations
        private void btn_plus_click(object sender, EventArgs e)
        {
            if (result != 0.0)
            {
                input = result.ToString();
                tempBox.Text = string.Empty;
            }

            operands.Add(input);
            operation = " + ";
            operands.Add(operation);
            tempBox.Text += input + operation;
            input = string.Empty;
        }

        private void btn_minus_click(object sender, EventArgs e)
        {
            if (result != 0.0)
            {
                input = result.ToString();
                tempBox.Text = string.Empty;
            }
            operands.Add(input);
            operation = " - ";
            operands.Add(operation);
            tempBox.Text += input + operation;
            input = string.Empty;
        }

        private void btn_multiply_click(object sender, EventArgs e)
        {
            if (result != 0.0)
            {
                input = result.ToString();
                tempBox.Text = string.Empty;
            }
            operands.Add(input);
            operation = " * ";
            operands.Add(operation);
            tempBox.Text += input + operation;
            input = string.Empty;
        }

        private void btn_divide_click(object sender, EventArgs e)
        {
            if (result != 0.0)
            {
                input = result.ToString();
                tempBox.Text = string.Empty;
            }
            operands.Add(input);
            operation = " / ";
            operands.Add(operation);
            tempBox.Text += input + operation;
            input = string.Empty;
        }

        private void btn_equals_click(object sender, EventArgs e)
        {
            //this.equals.DialogResult = System.Windows.Forms.DialogResult.OK;
            operands.Add(input);
            tempBox.Text += input;
            input = string.Empty;
            double num1, num2;

            for (int i = 0; i < operands.Count; i++)
            {
                if (operands[i] == " + ")
                {
                    double.TryParse(operands[i - 1], out num1);
                    double.TryParse(operands[i + 1], out num2);
                    result = num1 + num2;
                    operands[i + 1] = result.ToString();
                }
                else if (operands[i] == " - ")
                {
                    double.TryParse(operands[i - 1], out num1);
                    double.TryParse(operands[i + 1], out num2);
                    result = num1 - num2;
                    operands[i + 1] = result.ToString();
                }
                else if (operands[i] == " * ")
                {
                    double.TryParse(operands[i - 1], out num1);
                    double.TryParse(operands[i + 1], out num2);
                    result = num1 * num2;
                    operands[i + 1] = result.ToString();
                }
                else if (operands[i] == " / ")
                {
                    double.TryParse(operands[i - 1], out num1);
                    double.TryParse(operands[i + 1], out num2);
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        operands[i + 1] = result.ToString();
                    }
                    else
                    {
                        answerBox.Text = "DIV/Zero!";
                    }
                }
            }
            answerBox.Text = result.ToString();
        }

        private void btn_clearGlobal_click(object sender, EventArgs e)
        {
            result = 0.0;
            input = string.Empty;
            answerBox.Text = string.Empty;
            tempBox.Text = string.Empty;
            operands.Clear();
        }

        private void btn_clearEntry_click(object sender, EventArgs e)
        {
            input = string.Empty;
            answerBox.Text = string.Empty;
        }

        private void basicToolStripMenuItem_click(object sender, EventArgs e)
        {
            BasicPanel.BringToFront();
            menuStrip1.BringToFront();
            BasicPanel.Enabled = true;
            TemperaturePanel.Enabled = false;
            SetDefault(equals);
           // this.basicPanel = new BasicPanel();
           // basicContentPanel.Controls.Add(this.basicPanel);
        }

        private void temperatureToolStripMenuItem_click(object sender, EventArgs e)
        {
            TemperaturePanel.BringToFront();
            menuStrip1.BringToFront();
            TemperaturePanel.Enabled = true;
            BasicPanel.Enabled = false;
            SetDefault(tempBtnConvert);
        }

        private void lengthToolStripMenuItem_click(object sender, EventArgs e)
        {

        }

        private void weightToolStripMenuItem_click(object sender, EventArgs e)
        {

        }

        private void volumeToolStripMenuItem_click(object sender, EventArgs e)
        {

        }

        private void tempBtnNumOne_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "1";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumTwo_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "2";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumThree_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "3";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumFour_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "4";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumFive_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "5";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumSix_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "6";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumSeven_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "7";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumEight_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "8";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumNine_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "9";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnNumZero_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += "0";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnDecimal_Click(object sender, EventArgs e)
        {
            tempFromText.Text = "";
            temperatureInput += ",";
            tempFromText.Text += temperatureInput;
        }

        private void tempBtnClearEntry_Click(object sender, EventArgs e)
        {
            tempFromText.Text = string.Empty;
            temperatureInput = string.Empty;
        }

        private void tempBtnClear_Click(object sender, EventArgs e)
        {
            tempFromText.Text = string.Empty;
            tempToText.Text = string.Empty;
            temperatureInput = string.Empty;
        }


        private void tempBtnConvert_Click(object sender, EventArgs e)
        {
            double num;

            if (tempFromCombo.SelectedItem.ToString() == "Celsius")
            {
                if (tempToCombo.SelectedItem.ToString() == "Fahrenheit")
                {
                    double.TryParse(temperatureInput, out num);
                    result = ConvertTemp.ConvertCelsiusToFahrenheit(num);
                    tempToText.Text = result.ToString();
                }
                if (tempToCombo.SelectedItem.ToString() == "Kelvin")
                {
                    double.TryParse(temperatureInput, out num);
                    result = ConvertTemp.ConvertCelsiusToKelvin(num);
                    tempToText.Text = result.ToString();
                }
            }
            else if (tempFromCombo.SelectedItem.ToString() == "Fahrenheit")
            {
                if (tempToCombo.SelectedItem.ToString() == "Celsius")
                {
                    double.TryParse(temperatureInput, out num);
                    result = ConvertTemp.ConvertFahrenheitToCelsius(num);
                    tempToText.Text = result.ToString();
                }
                if (tempToCombo.SelectedItem.ToString() == "Kelvin")
                {
                    double.TryParse(temperatureInput, out num);
                    result = ConvertTemp.ConvertFahrenheitToKelvin(num);
                    tempToText.Text = result.ToString();
                }
            }
            else if (tempFromCombo.SelectedItem.ToString() == "Kelvin")
            {
                if (tempToCombo.SelectedItem.ToString() == "Celsius")
                {
                    double.TryParse(temperatureInput, out num);
                    result = ConvertTemp.ConvertKelvinToCelsius(num);
                    tempToText.Text = result.ToString();
                }
                if (tempToCombo.SelectedItem.ToString() == "Fahrenheit")
                {
                    double.TryParse(temperatureInput, out num);
                    result = ConvertTemp.ConvertKelvinToFahrenheit(num);
                    tempToText.Text = result.ToString();
                }
            }
        }

        private void SetDefault(Button myDefaultBtn)
        {
            this.AcceptButton = myDefaultBtn;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BasicPanel.Enabled == true)
                {
                    equals.PerformClick();
                }
                else if (TemperaturePanel.Enabled == true)
                {
                    tempBtnConvert.PerformClick();
                } 
            }
        }
    }
}
