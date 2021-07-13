using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SudokuSolver
{
    public class Opgave
    {
        public static int[,] opgaveArray = new int[9, 9];
        public Opgave(WrapPanel sudoku)
        {
            int rows = 0;
            int columns = 0;

            foreach (TextBox item in sudoku.Children)
            {
                int number;
                if (!int.TryParse(item.Text, out number))
                {
                    number = 0;
                    item.Foreground = Brushes.DarkBlue;
                }
                else
                {
                    number = int.Parse(item.Text);
                }
                if (columns == 9)
                {
                    columns = 0;
                    rows++;
                }
                opgaveArray[rows, columns] = number;
                columns++;
            }
        }
    }
}
