using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        // Output Display Constants.
        private const string oneOut = "1";
        private const string twoOut = "2";
        private const string threeOut = "3";
        private const string fourOut = "4";
        private const string fiveOut = "5";
        private const string sixOut = "6";
        private const string sevenOut = "7";
        private const string eightOut = "8";
        private const string nineOut = "9";
        private const string zeroOut = "0";
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            OutputDisplay.Text = "0";
        }
        #endregion

        #region NormalView Buttons Methods
        private void KeyPlus_Click(object sender, RoutedEventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eAdd);
        }

        private void KeyMinus_Click(object sender, RoutedEventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eSubtract);
        }

        private void KeyMultiply_Click(object sender, RoutedEventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eMultiply);
        }

        private void KeyDivide_Click(object sender, RoutedEventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eDivide);
        }

        private void KeySign_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcSign();
        }

        private void KeyPoint_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcDecimal();
        }

        private void KeyDate_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.GetDate();
            CalcEngine.CalcReset();
        }

        private void KeyClear_Click(object sender, RoutedEventArgs e)
        {
            CalcEngine.CalcReset();
            OutputDisplay.Text = "0";
        }

        private void KeyEqual_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcEqual();
            CalcEngine.CalcReset();
        }

        private void KeyNine_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(nineOut);
        }

        private void KeyEight_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(eightOut);
        }

        private void KeySeven_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(sevenOut);
        }

        private void KeySix_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(sixOut);
        }

        private void KeyFive_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(fiveOut);
        }

        private void KeyFour_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(fourOut);
        }

        private void KeyThree_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(threeOut);
        }

        private void KeyTwo_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(twoOut);
        }

        private void KeyOne_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(oneOut);
        }

        private void KeyZero_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcNumber(zeroOut);
        }

        private void KeyExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KeySquareRoot_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcSquareRoot();
            CalcEngine.CalcReset();
        }
        #endregion

        #region View Setup
        private void ExtendedView_Click(object sender, RoutedEventArgs e)
        {
            if (MainDockPanel.Children.Count == 2)
            {
                this.Width = 267;
                Grid ExtendedGrid = new Grid();
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                RowDefinition row3 = new RowDefinition();
                RowDefinition row4 = new RowDefinition();
                RowDefinition row5 = new RowDefinition();
                ExtendedGrid.RowDefinitions.Add(row1);
                ExtendedGrid.RowDefinitions.Add(row2);
                ExtendedGrid.RowDefinitions.Add(row3);
                ExtendedGrid.RowDefinitions.Add(row4);
                ExtendedGrid.RowDefinitions.Add(row5);

                Button KeyExponentiation = new Button();
                KeyExponentiation.Content = "x^y";
                KeyExponentiation.ToolTip = "Возвести в степень";
                Grid.SetRow(KeyExponentiation, 3);
                KeyExponentiation.Click += new System.Windows.RoutedEventHandler(this.KeyExponentiation_Click);

                Button KeySquareRoot = new Button();
                KeySquareRoot.Content = "√";
                KeySquareRoot.ToolTip = "Вычислить квадратный корень";
                Grid.SetRow(KeySquareRoot, 2);
                KeySquareRoot.Click += new System.Windows.RoutedEventHandler(this.KeySquareRoot_Click);


                Button KeySqare = new Button();
                KeySqare.Content = "x^2";
                KeySqare.ToolTip = "Возвести в квадрат";
                Grid.SetRow(KeySqare, 4);
                KeySqare.Click += new System.Windows.RoutedEventHandler(this.KeySquare_Click);

                Button KeyCubeRoot = new Button();
                KeyCubeRoot.Content = "∛x";
                KeyCubeRoot.ToolTip = "Вычислить кубический корень";
                Grid.SetRow(KeyCubeRoot, 1);
                KeyCubeRoot.Click += new System.Windows.RoutedEventHandler(this.KeyCubeRoot_Click);

                Button KeyFactorial = new Button();
                KeyFactorial.Content = "n!";
                KeyFactorial.ToolTip = "Вычислить факториал";
                Grid.SetRow(KeyFactorial, 0);
                KeyFactorial.Click += new System.Windows.RoutedEventHandler(this.KeyFactorial_Click);


                ExtendedGrid.Children.Add(KeyExponentiation);
                ExtendedGrid.Children.Add(KeySquareRoot);
                ExtendedGrid.Children.Add(KeySqare);
                ExtendedGrid.Children.Add(KeyCubeRoot);
                ExtendedGrid.Children.Add(KeyFactorial);
                MainDockPanel.Children.Add(ExtendedGrid);
                MenuItemView.IsSubmenuOpen = false;
            }

        }

        private void NormalView_Click(object sender, RoutedEventArgs e)
        {
            if (MainDockPanel.Children.Count == 3)
            {
                MainDockPanel.Children.RemoveAt(2);
                this.Width = 225;
                MenuItemView.IsSubmenuOpen = false;
            }
        }
        #endregion

        #region ExtendedView Buttons Methods
        private void KeyInverse_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcInverse();
            CalcEngine.CalcReset();
        }

        private void KeySquare_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcSquare();
            CalcEngine.CalcReset();
        }

        private void KeyExponentiation_Click(object sender, RoutedEventArgs e)
        {
            CalcEngine.CalcOperation(CalcEngine.Operator.eExponent);
        }

        private void KeyCubeRoot_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcCubeRoot();
            CalcEngine.CalcReset();
        }

        private void KeyFactorial_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcFactorial();
            CalcEngine.CalcReset();
        }
        #endregion

        #region Quadratic Equation
        private void Quadratic_Click(object sender, RoutedEventArgs e)
        {
            QuadraticEqWindow quadraticWindow = new QuadraticEqWindow();
            if (quadraticWindow.ShowDialog() == true)
            {
                CalcEngine.CalcCoeffA(quadraticWindow.A);
                CalcEngine.CalcCoeffB(quadraticWindow.B);
                CalcEngine.CalcCoeffC(quadraticWindow.C);
                OutputDisplay.Text = CalcEngine.CalcQuadratic();
                CalcEngine.CalcReset();
            }
        }
        #endregion
    }
}
