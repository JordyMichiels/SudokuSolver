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

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 81; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Text = string.Empty;
                textBox.Width = 60;
                textBox.Height = 60;
                textBox.VerticalContentAlignment = VerticalAlignment.Center;
                textBox.HorizontalContentAlignment = HorizontalAlignment.Center;
                textBox.FontSize = 36;
                textBox.FontWeight = FontWeights.Bold;
                Sudoku.Children.Add(textBox);
            }
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {            
            Opgave opgave = new Opgave(Sudoku);
            Solve();
                        
        }

        private bool Validate(int row, int column, int number)
        {
            bool result = true;

            for (int i = 0; i < 9; i++)
            {
                if (Opgave.opgaveArray[row, i] == number)
                {
                    result = false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (Opgave.opgaveArray[i, column] == number)
                {
                    result = false;
                }
            }

            var x0 = (column / 3) * 3;
            var y0 = (row / 3) * 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Opgave.opgaveArray[y0 + i, x0 + j] == number)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        private void Solve()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Opgave.opgaveArray[i,j] == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            if (Validate(i,j,k))
                            {
                                Opgave.opgaveArray[i, j] = k;
                                Solve();
                                Opgave.opgaveArray[i, j] = 0;
                            }
                        }
                        return;
                    }
                }
            }

            int rows = 0;
            int columns = 0;

            foreach (TextBox textBox in Sudoku.Children)
            {
                textBox.Text = Opgave.opgaveArray[rows, columns].ToString();
                columns++;
                if (columns == 9)
                {
                    columns = 0;
                    rows++;
                }
            }

        }
    }
}
