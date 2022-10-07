using MyDialogs;
using System;
using System.Collections.Generic;
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
            // get hours from user
            string hours = My_Dialogs.InputBox("Enter hours:");

            // get minutes from user
            string minutes = My_Dialogs.InputBox("Enter minutes:");

            // get seconds from user
            string seconds = My_Dialogs.InputBox("Enter seconds:");

            // calc answer
            int result = (Convert.ToInt32(hours) * 60 * 60) + (Convert.ToInt32(minutes) * 60) + Convert.ToInt32(seconds);

            // display
            MessageBox.Show("Total in seconds: " + result);
        }

        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            // enter a number to be converted to a float
            string strNumberOne = My_Dialogs.InputBox("Enter a number:");
            float floatNumberOne;
            while (!float.TryParse(strNumberOne, out floatNumberOne))  // retry if a non float value is entered
            {
                strNumberOne = My_Dialogs.InputBox("Enter a number:");
            }

            // enter an operator
            string strOperation = My_Dialogs.InputBox("Enter an operation:");
            string[] operators = { "+", "-", "/", "*" };
            while (!operators.Contains(strOperation)) {  // check if the operator is valid
                strOperation = My_Dialogs.InputBox("Enter an operation:");  // try again
            }

            // enter a number to be converted to a float
            string strNumberTwo = My_Dialogs.InputBox("Enter a number:");
            float floatNumberTwo;
            while (!float.TryParse(strNumberTwo, out floatNumberTwo))  // retry if a non float value is entered
            {
                strNumberTwo = My_Dialogs.InputBox("Enter a number:");
            }

            float floatResult = strOperation switch
            {
                "+" => floatNumberOne + floatNumberTwo,
                "-" => floatNumberOne - floatNumberTwo,
                "*" => floatNumberOne * floatNumberTwo,
                "/" => floatNumberOne / floatNumberTwo,
                _ => 0
            };

            MessageBox.Show("Result: " + floatResult);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const double pi = 3.141;
            int diameter = Convert.ToInt32(My_Dialogs.InputBox("Enter Pizza Diameter"));
            double share = pi * Math.Pow((0.5 * diameter), 2);
            MessageBox.Show($"3 sharing each get {share} sq inches");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const double sqm = 3000;
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

            switch (mark)
            {
                case >= 70 and <= 100:
                    MessageBox.Show("Distinction");
                    break;
                case >= 60 and <= 69:
                    MessageBox.Show("Merit");
                    break;
                case >= 40 and <= 59:
                    MessageBox.Show("Pass");
                    break;
                case >= 0 and <= 39:
                    MessageBox.Show("Fail");
                    break;
                default:
                    MessageBox.Show("Impossible Mark");
                    break;
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
            int incorrectCount = 0;
            string attempt = My_Dialogs.InputBox("Please enter the Password: ");
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
            string hours, minutes;
            // get hours from user
            int intHours;
            do
            {
                hours = My_Dialogs.InputBox("Enter hours:");
                intHours = Convert.ToInt32(hours);
            } while (!(intHours is >= 0 and <= 23));

            // get minutes from user
            int intMinutes;
            do
            {
                minutes = My_Dialogs.InputBox("Enter minutes:");
                intMinutes = Convert.ToInt32(minutes);
            } while (intMinutes is not (>= 0 and <= 59));

            // get seconds from user
            string seconds = My_Dialogs.InputBox("Enter seconds:");

            // calc answer
            int result = (Convert.ToInt32(hours) * 60 * 60) + (Convert.ToInt32(minutes) * 60) + Convert.ToInt32(seconds);

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

        private static void NameAndTown()
        {
            string name = My_Dialogs.InputBox("Enter your name:");
            string town = My_Dialogs.InputBox("Enter your town:");

            MessageBox.Show($"Your name is {name}");
            MessageBox.Show($"Your town is {town}");
        }
        
        private void MinutesAndSeconds_Click(object sender, EventArgs e)
        {
            // Gets Minutes
            int total = GetValueMinutes("minutes") * 60;
            // Gets Seconds
            total = total + GetValueMinutes("seconds");
            MessageBox.Show("The total number of seconds is: " + Convert.ToString(total));
        }

        private static int GetValueMinutes(string type)
        {
            // getValue
            int reply = Convert.ToInt16(My_Dialogs.InputBox("type " + type));
            while (reply is < 0 or > 59)
            {
                MessageBox.Show("Wrong");
                reply = Convert.ToInt32(
                My_Dialogs.InputBox("Value must be between 0 and 59"));
            }
            return reply;
        }

        private void MinutesSecondsHoursMethod_Click(object sender, EventArgs e)
        {
            // Gets Minutes
            int total = GetValueHours("minutes") * 60;
            // Gets Seconds
            total += GetValueHours("seconds");
            // Gets Hours
            total += GetValueHours("hours") * 60 * 60;
            MessageBox.Show("The total number of seconds is: " + Convert.ToString(total));
        }

        private static int GetValueHours(string type)
        {
            // getValue
            int reply = Convert.ToInt16(My_Dialogs.InputBox("type " + type));
            int maxSize = 59;
            if (type == "hours") maxSize = 23;
            while (reply < 0 || reply > maxSize)
            {
                MessageBox.Show("Wrong");
                reply = Convert.ToInt32(
                My_Dialogs.InputBox("Value must be between 0 and 59"));
            }
            return reply;
        }

        private void RectangleTriangleSize_Click(object sender, EventArgs e)
        {
            string calc;
            do
            {
                string shape = GetShape();

                double area = shape == "rectangle" ? AreaRectangle() : AreaTriangle();
                MessageBox.Show("Area is " + area);
                calc = My_Dialogs.InputBox("Do you want to calculate area again? (y/n)");
            } while (calc is "y" or "");
        }

        private static string GetShape()
        {
            string inp;
            do
            {
                inp = My_Dialogs.InputBox("Input shape type:");
            } while (inp is not ("rectangle" or "triangle"));
            return inp;
        }

        private static double AreaTriangle()
        {
            double itsBase = Convert.ToDouble(My_Dialogs.InputBox("Enter base:"));
            double itsHeight = Convert.ToDouble(My_Dialogs.InputBox("Enter height:"));

            return 0.5 * itsBase * itsHeight;
        }

        private static double AreaRectangle()
        {
            double itsWidth = Convert.ToDouble(My_Dialogs.InputBox("Enter width:"));
            double itsHeight = Convert.ToDouble(My_Dialogs.InputBox("Enter height:"));

            return itsWidth * itsHeight;
        }

        private void ReadValueDouble_Click(object sender, EventArgs e)
        {
            double limit = Convert.ToDouble(My_Dialogs.InputBox("Enter a limit:"));
            string prompt = My_Dialogs.InputBox("Enter a prompt:");
            double returnValue = ReadValueAndReturn(limit, prompt);
            MessageBox.Show(Convert.ToString(returnValue));
        }

        private static double ReadValueAndReturn(double limit, string prompt)
        {
            double userReply = Convert.ToDouble(My_Dialogs.InputBox("Type " + prompt + ":"));
            while ((userReply < 0) || (userReply > limit))
            {
                MessageBox.Show(prompt + " Too Big! – Try Again");
                userReply = Convert.ToDouble(My_Dialogs.InputBox("Type " + prompt + ":"));
            }
            return userReply;
        }

        private static int ReadValue(double limit, string prompt)
        {
            int userReply = Convert.ToInt32(My_Dialogs.InputBox("Type " + prompt + ":"));
            while ((userReply < 0) || (userReply > limit))
            {
                MessageBox.Show(prompt + " Too Big! – Try Again");
                userReply = Convert.ToInt32(My_Dialogs.InputBox("Type " + prompt + ":"));
            }
            return userReply;
        }

        private void TotalMarks_Click(object sender, EventArgs e)
        {
            int mark1 = ReadValue(100, "First Mark");
            int mark2 = ReadValue(100, "Second Mark");
            int total = TotalMark(mark1, mark2);
            MessageBox.Show(total.ToString());
        }

        private static int TotalMark(int mark1, int mark2)
        {
            return (int)(mark1 * 0.4 + mark2 * 0.6);
        }

        private void SmallerNumber2_Click(object sender, EventArgs e)
        {
            int smaller = GetSmallerInt(7, 2);
            MessageBox.Show(smaller.ToString());
        }

        private static int GetSmallerInt(int num1, int num2)
        {
            return num1 < num2 ? num1 : num2;
        }

        private void SmallerOfThree_Click(object sender, EventArgs e)
        {
            int smaller = GetSmallerOfThree(1, 5, 2);
            MessageBox.Show(smaller.ToString());
        }

        private static int GetSmallerOfThree(int num1, int num2, int num3)
        {
            return GetSmallerInt(GetSmallerInt(num1, num2), num3);
        }
    }
}
