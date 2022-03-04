namespace Calculator
{

    using System;

    public class CalcEngine
    {
        //
        // Operation Constants.
        //
        public enum Operator : int
        {
            eUnknown = 0,
            eAdd = 1,
            eSubtract = 2,
            eMultiply = 3,
            eDivide = 4,
            eExponent = 5,
        }


        //
        // Module-Level Constants
        //

        private static double negativeConverter = -1;
        // TODO: Upgrade the version number to 3.0.1.1
        private static string versionInfo = "Calculator v2.0.1.1";

        //
        // Module-level Variables.
        //

        private static double numericAnswer;
        private static string stringAnswer;
        private static Operator calcOperation;
        private static double firstNumber;
        private static double secondNumber;
        private static bool secondNumberAdded;
        private static bool decimalAdded;
        private static double a;
        private static double b;
        private static double c;
        private static double x1;
        private static double x2;

        //
        // Class Constructor.
        //

        public CalcEngine()
        {
            decimalAdded = false;
            secondNumberAdded = false;
        }

        //
        // Returns the custom version string to the caller.
        //

        public static string GetVersion()
        {
            return (versionInfo);
        }
        //
        // Called when the Date key is pressed.
        //

        public static string GetDate()
        {
            DateTime curDate = new DateTime();
            curDate = DateTime.Now;

            stringAnswer = String.Concat(curDate.ToShortDateString(), " ", curDate.ToLongTimeString());

            return (stringAnswer);
        }

        //
        // Called when a number key is pressed on the keypad.
        //

        public static string CalcNumber(string KeyNumber)
        {
            stringAnswer = stringAnswer + KeyNumber;
            return (stringAnswer);
        }

        public static double CalcCoeffA(double A)
        {
            a = A;
            return a;
        }
        public static double CalcCoeffB(double B)
        {
            b = B;
            return a;
        }

        public static double CalcCoeffC(double C)
        {
            c = C;
            return a;
        }


        //
        // Called when an operator is selected (+, -, *, /)
        //

        public static void CalcOperation(Operator calcOper)
        {
            if (stringAnswer != "" && !secondNumberAdded)
            {
                firstNumber = System.Convert.ToDouble(stringAnswer);
                calcOperation = calcOper;
                stringAnswer = "";
                decimalAdded = false;
            }
        }

        //
        // Called when the +/- key is pressed.
        //

        public static string CalcSign()
        {
            double numHold;

            if (stringAnswer != "")
            {
                numHold = System.Convert.ToDouble(stringAnswer);
                stringAnswer = System.Convert.ToString(numHold * negativeConverter);
            }

            return (stringAnswer);
        }

        //
        // Called when the . key is pressed.
        //

        public static string CalcDecimal()
        {
            if (!decimalAdded && !secondNumberAdded)
            {
                if (stringAnswer != "")
                    stringAnswer = stringAnswer + ".";
                else
                    stringAnswer = "0.";

                decimalAdded = true;
            }

            return (stringAnswer);
        }

        //
        // Called when 1/x is pressed.
        //

        public static string CalcInverse()
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            numericAnswer = 1 / firstNumber;
            stringAnswer = System.Convert.ToString(numericAnswer);
            return (stringAnswer);
        }

        //
        // Called when SquareRoot is pressed.
        //

        public static string CalcSquareRoot()
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            numericAnswer = Math.Sqrt(firstNumber);
            stringAnswer = System.Convert.ToString(numericAnswer);
            return (stringAnswer);
        }

        public static string CalcSquare()
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            numericAnswer = Math.Pow(firstNumber, 2);
            stringAnswer = System.Convert.ToString(numericAnswer);
            return (stringAnswer);
        }

        public static string CalcFactorial()
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            if (firstNumber == 0)
            {
                numericAnswer = firstNumber;
            }
            else
            {
                numericAnswer = 1;
                for (int i = 1; i <= firstNumber; i++)
                {
                    numericAnswer *= i;
                }
            }
            stringAnswer = System.Convert.ToString(numericAnswer);
            return (stringAnswer);
        }

        public static string CalcCubeRoot()
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            numericAnswer = Math.Pow(firstNumber, 1.0 / 3.0);
            stringAnswer = System.Convert.ToString(numericAnswer);
            return (stringAnswer);
        }

        //
        // Called when = is pressed.
        //

        public static string CalcEqual()
        {
            bool validEquation = false;

            if (stringAnswer != "")
            {
                secondNumber = System.Convert.ToDouble(stringAnswer);
                secondNumberAdded = true;

                switch (calcOperation)
                {
                    case Operator.eUnknown:
                        validEquation = false;
                        break;

                    case Operator.eAdd:
                        numericAnswer = firstNumber + secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eSubtract:
                        numericAnswer = firstNumber - secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eMultiply:
                        numericAnswer = firstNumber * secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eDivide:
                        numericAnswer = firstNumber / secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eExponent:
                        numericAnswer = Math.Pow(firstNumber, secondNumber);
                        validEquation = true;
                        break;

                    default:
                        validEquation = false;
                        break;
                }

                if (validEquation)
                {
                    stringAnswer = System.Convert.ToString(numericAnswer);
                }

            }

            return (stringAnswer);
        }

        //
        // Resets the various module-level variables for the next calculation.
        //

        public static void CalcReset()
        {
            numericAnswer = 0;
            firstNumber = 0;
            secondNumber = 0;
            stringAnswer = "";
            calcOperation = Operator.eUnknown;
            decimalAdded = false;
            secondNumberAdded = false;
        }

        public static string CalcQuadratic()

        {
            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / 2 * a;
                x2 = (-b - Math.Sqrt(D)) / 2 * a;
                stringAnswer = "x1 = " + x1.ToString("N") + "; x2 = " + x2.ToString("N");

            }
            else if (D == 0)
            {
                x1 = -b / 2 * a;
                stringAnswer = "x1 = x2 = " + x1.ToString("N");
            }
            else
            {
                stringAnswer = "????????? ?? ????? ??????";

            }
            return stringAnswer;
        }
    }
}