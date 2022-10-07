using MyDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FirstTime
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Hello_Click(object sender, EventArgs e)
        {
            string name = My_Dialogs.InputBox("Enter your name:");

            this.BackColor = Color.MediumPurple;

            MessageBox.Show("Hello " + name);

            this.BackColor = Color.MediumAquamarine;
        }

        private void btn_Seconds_Click(object sender, EventArgs e)
        {
            string hours, minutes, seconds;
            int result;
            // get hours from user
            hours = My_Dialogs.InputBox("Enter hours:");

            // get minutes from user
            minutes = My_Dialogs.InputBox("Enter minutes:");

            // get seconds from user
            seconds = My_Dialogs.InputBox("Enter seconds:");

            // calc answer
            result = (Convert.ToInt32(hours) * 60 * 60) + (Convert.ToInt32(minutes) * 60) + Convert.ToInt32(seconds);

            // display
            MessageBox.Show("Total in seconds: " + result);
        }

        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            // enter a number to be converted to a float
            string str_numberOne = My_Dialogs.InputBox("Enter a number:");
            float float_numberOne;
            while (!float.TryParse(str_numberOne, out float_numberOne))  // retry if a non float value is entered
            {
                str_numberOne = My_Dialogs.InputBox("Enter a number:");
            }

            // enter an operator
            string str_operation = My_Dialogs.InputBox("Enter an operation:");
            string[] operators = { "+", "-", "/", "*" };
            while (!operators.Contains(str_operation)) {  // check if the operator is valid
                str_operation = My_Dialogs.InputBox("Enter an operation:");  // try again
            }

            // enter a number to be converted to a float
            string str_numberTwo = My_Dialogs.InputBox("Enter a number:");
            float float_numberTwo;
            while (!float.TryParse(str_numberTwo, out float_numberTwo))  // retry if a non float value is entered
            {
                str_numberTwo = My_Dialogs.InputBox("Enter a number:");
            }

            float float_result;
            switch (str_operation)
            {
                case "+":
                    float_result = float_numberOne + float_numberTwo;
                    break;
                case "-":
                    float_result = float_numberOne - float_numberTwo;
                    break;
                case "*":
                    float_result = float_numberOne * float_numberTwo;
                    break;
                case "/":
                    float_result = float_numberOne / float_numberTwo;
                    break;
                default:
                    float_result = 0;
                    break;
            }

            MessageBox.Show("Result: " + float_result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const double pi = 3.141;
            int diameter = Convert.ToInt32(My_Dialogs.InputBox("Enter Pizza Diameter"));
            double share = (double)pi * Math.Pow((0.5 * diameter), 2);
            MessageBox.Show($"3 sharing each get {share} sq inches");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sqm = 3000;
            double edgeSize = Math.Sqrt(sqm);
            MessageBox.Show("Side length: " + edgeSize);
        }

        private void firstLastLetter_Click(object sender, EventArgs e)
        {
            string name = My_Dialogs.InputBox("What is your name: ");
            MessageBox.Show(name.Substring(0, 1));
            MessageBox.Show(name.Substring(name.Length-1));
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(My_Dialogs.InputBox("Enter a number:"));

            if (number < 0)
            {
                MessageBox.Show("You cannot square root negative numbers!");
                return;
            }

            MessageBox.Show(Math.Sqrt(number).ToString());
        }

        private void calcArea_Click(object sender, EventArgs e)
        {
            double length = Convert.ToDouble(My_Dialogs.InputBox("Enter the length:"));
            double width = Convert.ToDouble(My_Dialogs.InputBox("Enter the width:"));

            if (length < 0 || width < 0)
            {
                MessageBox.Show("Length and Width must both be positive!");
                return;
            }

            MessageBox.Show("Area is: " + length * width);
        }

        private void SmallerNumber_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(My_Dialogs.InputBox("Enter a number:"));
            int num2 = Convert.ToInt32(My_Dialogs.InputBox("Enter another number:"));

            if (num1 < num2)
            {
                MessageBox.Show(num1.ToString());
                MessageBox.Show(num2.ToString());
                return;
            }

            MessageBox.Show(num2.ToString());
            MessageBox.Show(num1.ToString());
        }

        private void LargestNumThree_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(My_Dialogs.InputBox("Enter a number:"));
            int num2 = Convert.ToInt32(My_Dialogs.InputBox("Enter another number:"));
            int num3 = Convert.ToInt32(My_Dialogs.InputBox("Enter another number:"));

            int largest = num1;
            if (num2 > largest) largest = num2;
            if (num3 > largest) largest = num3;

            MessageBox.Show(largest.ToString());
        }

        private void MarkToGrade_Click(object sender, EventArgs e)
        {
            int mark = Convert.ToInt32(My_Dialogs.InputBox("Enter a mark:"));

            if (70 <= mark && mark <= 100)
            {
                MessageBox.Show("Distinction");
            }
            else if (60 <= mark && mark <= 69)
            {
                MessageBox.Show("Merit");
            }
            else if (40 <= mark && mark <= 59)
            {
                MessageBox.Show("Pass");
            }
            else if (0 <= mark && mark <= 39)
            {
                MessageBox.Show("Fail");
            }
            else
            {
                MessageBox.Show("Impossible Mark");
            }
        }

        private void ShapeArea_Click(object sender, EventArgs e)
        {
            string shape = My_Dialogs.InputBox("Enter 'square', 'triangle', or 'rectangle':");

            double area;
            if (shape == "square")
            {
                double sideLength = Convert.ToDouble(My_Dialogs.InputBox("Enter side length:"));
                area = sideLength * sideLength;
            }
            else if (shape == "triangle")
            {
                double sideA = Convert.ToDouble(My_Dialogs.InputBox("Enter side a length:"));
                double sideB = Convert.ToDouble(My_Dialogs.InputBox("Enter side b length:"));
                double angleC = Convert.ToDouble(My_Dialogs.InputBox("Enter angle C in degrees:"));
                angleC *= Math.PI / 180;  // convert to radians
                area = 0.5 * sideA * sideB * Math.Sin(angleC);
            }
            else if (shape == "rectangle")
            {
                double length = Convert.ToDouble(My_Dialogs.InputBox("Enter the length:"));
                double width = Convert.ToDouble(My_Dialogs.InputBox("Enter the width:"));
                area = length * width;
            }
            else
            {
                MessageBox.Show(shape + " is not a valid shape!");
                return;
            }

            MessageBox.Show("The area is " + area.ToString() + " units");
        }

        private void IsInBox_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(My_Dialogs.InputBox("Enter x1:"));
            double y1 = Convert.ToDouble(My_Dialogs.InputBox("Enter y1:"));
            double x2 = Convert.ToDouble(My_Dialogs.InputBox("Enter x2:"));
            double y2 = Convert.ToDouble(My_Dialogs.InputBox("Enter y2:"));
            double x3 = Convert.ToDouble(My_Dialogs.InputBox("Enter x3:"));
            double y3 = Convert.ToDouble(My_Dialogs.InputBox("Enter y3:"));

            if ((y2 <= y3 && y3 <= y1) && (x1 <= x3 && x3 <= x2))
            {
                MessageBox.Show($"({x3},{y3}) is within the area of ({x1}, {y1}),({x2}, {y2})");
                return;
            }

            MessageBox.Show($"({x3},{y3}) is NOT within the area of ({x1}, {y1}),({x2}, {y2})");
        }

        private void LetterInName_Click(object sender, EventArgs e)
        {
            string letter = My_Dialogs.InputBox("Enter a letter:").Substring(0, 1);
            string name = My_Dialogs.InputBox("Enter your name:");

            Regex regex = new Regex(letter);
            int count = regex.Matches(name).Count;

            MessageBox.Show($"'{letter}' occurs in your name {count} time(s)");
        }

        private void CoffeeSizePrice_Click(object sender, EventArgs e)
        {
            string size = My_Dialogs.InputBox("Enter a Coffee size:");

            float price;
            switch (size)
            {
                case "1": case "small":
                    price = 1.50f;
                    break;

                case "2": case "medium":
                    price = 1.80f;
                    break;

                case "3": case "large":
                    price = 2.20f;
                    break;

                default:
                    MessageBox.Show("This size is invalid!");
                    return;
            }

            MessageBox.Show("Price: " + price);
        }

        private void PasswordLoop_Click(object sender, EventArgs e)
        {
            String attempt;
            int incorrectCount = 0;
            attempt = My_Dialogs.InputBox("Please enter the Password: ");
            while (attempt != "basic")
            {
                incorrectCount++;
                MessageBox.Show("Incorrect [" + incorrectCount + "]\nWrong! - try again.");
                attempt = My_Dialogs.InputBox("Please enter the Password: ");
            }
            MessageBox.Show("Welcome to the program!");
        }

        private void SecondsCheck_Click(object sender, EventArgs e)
        {
            string hours, minutes, seconds;
            int result;
            // get hours from user
            int int_hours;
            do
            {
                hours = My_Dialogs.InputBox("Enter hours:");
                int_hours = Convert.ToInt32(hours);
            } while (!(0 <= int_hours && int_hours <= 23));

            // get minutes from user
            int int_mins;
            do
            {
                minutes = My_Dialogs.InputBox("Enter mins:");
                int_mins = Convert.ToInt32(minutes);
            } while (!(0 <= int_mins && int_mins <= 59));

            // get seconds from user
            seconds = My_Dialogs.InputBox("Enter seconds:");

            // calc answer
            result = (Convert.ToInt32(hours) * 60 * 60) + (Convert.ToInt32(minutes) * 60) + Convert.ToInt32(seconds);

            // display
            MessageBox.Show("Total in seconds: " + result);
        }

        private void SquareWhile_Click(object sender, EventArgs e)
        {
            int count = 1;
            do
            {
                MessageBox.Show($"Square of {count} is {count * count}");
                count++;
            } while (count < 11);
        }

        private void TenMarks_Click(object sender, EventArgs e)
        {
            List<double> scores = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                scores.Add(Convert.ToDouble(My_Dialogs.InputBox($"Enter a score ({i+1}):")));
            }

            MessageBox.Show($"The total is {scores.Sum()}");
            MessageBox.Show($"The mean average is {scores.Sum()/scores.Count}");

            int count = 0;
            foreach  (double dbl in scores)
            {
                if (dbl < 40) count++;
            }
            MessageBox.Show($"There was {count} fails");
        }

        private void LowestOverdraft_Click(object sender, EventArgs e)
        {
            double input;
            double lowest = double.MaxValue;
            do
            {
                input = Convert.ToDouble(My_Dialogs.InputBox("Enter an overdraft amount:"));
                if (input == -999) break;
                if (input < lowest) lowest = input;

            } while (input != -999);

            MessageBox.Show($"The lowest overdraft is {lowest}");
        }

        private void MethodsButton_Click(object sender, EventArgs e)
        {
            NameAndTown();
            NameAndTown();
        }

        private void NameAndTown()
        {
            string name = My_Dialogs.InputBox("Enter your name:");
            string town = My_Dialogs.InputBox("Enter your town:");

            MessageBox.Show($"Your name is {name}");
            MessageBox.Show($"Your town is {town}");
        }
    }
}
