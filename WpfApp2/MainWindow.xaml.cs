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

namespace WpfApp2
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int TriJednickyZaSebou()
        {
            int hranice = 100000000;
            int prvocislo = 0;
            int[] cisla = new int[hranice + 1];

            for (int i = 0; i < hranice; i++)
            {
                cisla[i] = 1;
            }

            for (int p = 2; p * p <= hranice; p++)
            {
                if (cisla[p] == 1)
                {
                    for (int i = p * p; i <= hranice; i += p)
                        cisla[i] = 0;
                }
            }

            for (int i = 2; i <= hranice; i++)
            {
                if (cisla[i] == 1 && i.ToString().Contains(111.ToString()))
                {
                    prvocislo = i;
                    break;
                }
            }
            return prvocislo;
        }
        public int PetJednickekZaSebou()
        {
            int hranice = 10000000;
            int prvocislo = 0;
            int[] cisla = new int[hranice + 1];

            for (int i = 0; i < hranice; i++)
            {
                cisla[i] = 1;
            }

            for (int p = 2; p * p <= hranice; p++)
            {
                if (cisla[p] == 1)
                {
                    for (int i = p * p; i <= hranice; i += p)
                        cisla[i] = 0;
                }
            }

            for (int i = 2; i <= hranice; i++)
            {
                if (cisla[i] == 1 && i.ToString().Contains(11111.ToString()))
                {
                    prvocislo = i;
                    break;
                }
            }
            return prvocislo;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // ThreadPool se nezablokuje
            // Task2 by měla trvat déle než task, ale netrvá, protože na sebe čekají, nechápu proč, nejsou na sobě závislé
            Task<int> task = new Task<int>(TriJednickyZaSebou);
            Task<int> task2 = new Task<int>(PetJednickekZaSebou);
            task.Start();
            task2.Start();
            text1.Text = "Probíhá operace...";
            text2.Text = "Probíhá operace...";
            int prvocislo = await task;        
            text1.Text = "Nejmenší prvočíslo podle zadaného kritéria : " + prvocislo.ToString();
            int prvocislo2 = await task2;
            text2.Text = "Nejmenší prvočíslo podle zadaného kritéria : " + prvocislo2.ToString();
        }
    }
}
