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
using Sets;

namespace _5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            triad = new Triad();
            ActualTriadBox.Text = triad.ToString();
        }
        bool handEnter;
        Triad triad;
        Triad oldTriad;
        private void CheckedHandEnter(object sender, RoutedEventArgs e)
        {
            handEnter = true;
            FirstNumberBox.IsEnabled = true;
            SecondNumberBox.IsEnabled = true;
            ThirdNumberBox.IsEnabled = true;
        }

        private void UncheckedHandEnter(object sender, RoutedEventArgs e)
        {
            handEnter = false;
            FirstNumberBox.IsEnabled = false;
            SecondNumberBox.IsEnabled = false;
            ThirdNumberBox.IsEnabled = false;
        }

        private void CreateTriad(object sender, RoutedEventArgs e)
        {
            CheckBox12.IsChecked = false;
            Compare12Box.Clear();
            CheckBox13.IsChecked = false;
            Compare13Box.Clear();
            CheckBox23.IsChecked = false;
            Compare23Box.Clear();
            PastTriadBox.Text = triad.ToString();
            oldTriad = triad;
            if (handEnter)
            {
                if(!int.TryParse(FirstNumberBox.Text, out int number1))
                {
                    MessageBox.Show("Некорректное 1 число!");
                    return;
                }
                if (!int.TryParse(SecondNumberBox.Text, out int number2))
                {
                    MessageBox.Show("Некорректное 2 число!");
                    return;
                }
                if (!int.TryParse(ThirdNumberBox.Text, out int number3))
                {
                    MessageBox.Show("Некорректное 3 число!");
                    return;
                }
                triad = new Triad(number1, number2, number3);
                ActualTriadBox.Text = triad.ToString();
                return;
            }
            triad = new Triad();
            ActualTriadBox.Text = triad.ToString();
        }

        private void AddNumber(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberBox.Text, out int number))
            {
                MessageBox.Show("Некорректное число!");
                return;
            }
            ActualTriadBox.Text = (triad += number).ToString();
        }
        private void AddTriad(object sender, RoutedEventArgs e)
        {
            if(oldTriad == null)
            {
                MessageBox.Show("Нет триады!");
                return;
            }
            ActualTriadBox.Text = (triad += oldTriad).ToString();
        }
        private void MultiplyNumber(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberBox.Text, out int number))
            {
                MessageBox.Show("Некорректное число!");
                return;
            }
            triad.Multiply(number);
            ActualTriadBox.Text = triad.ToString();
        }
        private void CheckedCompare12(object sender, RoutedEventArgs e)
        { 
            if(triad.Compare(1,2))
            {
                Compare12Box.Text = "Числа равны";
                return;
            }
            Compare12Box.Text = "Числа не равны";
        }

        private void UncheckedCompare12(object sender, RoutedEventArgs e)
        {
            Compare12Box.Clear();
        }

        private void CheckedCompare13(object sender, RoutedEventArgs e)
        {
            if (triad.Compare(1, 3))
            {
                Compare13Box.Text = "Числа равны";
                return;
            }
            Compare13Box.Text = "Числа не равны";
        }

        private void UncheckedCompare13(object sender, RoutedEventArgs e)
        {
            Compare13Box.Clear();
        }

        private void CheckedCompare23(object sender, RoutedEventArgs e)
        {
            if (triad.Compare(2, 3))
            {
                Compare23Box.Text = "Числа равны";
                return;
            }
            Compare23Box.Text = "Числа не равны";
        }

        private void UncheckedCompare23(object sender, RoutedEventArgs e)
        {
            Compare23Box.Clear();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Митин ИСП-31 Использовать класс Triad (тройка чисел). Разработать операцию для сложения \r\nтриады с числом. Разработать операцию для сложения элементов одой триады с \r\nдругой триадой.");
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
