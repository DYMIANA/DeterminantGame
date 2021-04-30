using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DeterminantGame
{
    /// <summary>
    /// Логика взаимодействия для Names.xaml
    /// </summary>
    public partial class Names : Window
    {
       internal List<Button> Det;
       internal List<Button> B;
       internal List<Button> C;
       internal int a=-1;
       internal int c=-1;
       internal int b=-1;
       internal bool P = false;
       internal bool N = false;
        public Names()
        {
            InitializeComponent();
        }

        public void A_Click1(object sender, RoutedEventArgs e)
        {
            var cell = (Button)sender;
            string name = cell.Name;
            int a1=int.Parse(name[1].ToString())-1;
            a = a1;
            if (P && b != -1)
            {
                Det[a1].Foreground = new SolidColorBrush(Color.FromRgb(255, 151, 204));
                Det[a1].Content = b;
                B[b - 1].IsEnabled = false;
                C[b - 1].IsEnabled = false;
                Det[a1].IsEnabled = false;
                P = false;
                N = true;
                foreach (var i in C)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 153, 255));
                }
                foreach (var i in B)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 204, 204));
                }
                b = -1;
                a = -1;
            }
            else if (N && c != -1)
            {
                Det[a1].Foreground = new SolidColorBrush(Color.FromRgb(102, 153, 255));
                Det[a1].Content = c;
                B[c - 1].IsEnabled = false;
                C[c - 1].IsEnabled = false;
                Det[a1].IsEnabled = false;
                P = true;
                N = false;
                foreach (var i in B)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 153, 255));
                }
                foreach (var i in C)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 204, 204));
                }
                c = -1;
                a = -1;
            }


        }

        public void B_Click1(object sender, RoutedEventArgs e)
        {
            var cell = (Button)sender;
            string name = cell.Name;
            int b1= int.Parse(name[1].ToString());
            if (P)
            {
                foreach (var i in B)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 153, 255));
                }
                b = b1;
                B[b1 - 1].Background = new SolidColorBrush(Color.FromRgb(102, 102, 102));
            }
        }

        public void C_Click1(object sender, RoutedEventArgs e)
        {
            var cell = (Button)sender;
            string name = cell.Name;
            int c1 = int.Parse(name[1].ToString());
            if (N)
            {
                foreach (var i in C)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 153, 255));
                }
                c = c1;
                C[c1 - 1].Background = new SolidColorBrush(Color.FromRgb(102, 102, 102));
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (this.PozitiveName.Text.Length > 0 && this.NegativeName.Text.Length > 0)
            {
                P = true;
                Det = new List<Button>
                {
                this.a1,
                this.a2,
                this.a3,
                this.a4,
                this.a5,
                this.a6,
                this.a7,
                this.a8,
                this.a9
                };
                B = new List<Button>
            {
                this.b1,
                this.b2,
                this.b3,
                this.b4,
                this.b5,
                this.b6,
                this.b7,
                this.b8,
                this.b9
            };
                C = new List<Button>
            {
                this.c1,
                this.c2,
                this.c3,
                this.c4,
                this.c5,
                this.c6,
                this.c7,
                this.c8,
                this.c9
            };
                foreach (var i in B)
                {
                    i.IsEnabled = true;
                }
                foreach (var i in C)
                {
                    i.IsEnabled = true;
                }
                this.next.IsEnabled = false;
                this.names.IsEnabled = false;
                this.games.IsEnabled = false;
                this.names.Visibility = Visibility.Hidden;
                this.games.Visibility = Visibility.Hidden;
                this.next.Visibility = Visibility.Hidden;
                this.DET.Visibility = Visibility.Visible;
                this.next.IsEnabled = false;
                this.PozitiveName.IsEnabled = false;
                this.NegativeName.IsEnabled = false;

                foreach (var i in B)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 153, 255));
                }
            }
            else
            {
                MessageBox.Show("Введите свои имена!");
            }

        }
        private void DET_Click(object sender, RoutedEventArgs e)
        {
            bool bol = true;
            foreach (var i in Det)
            {
                if (i.IsEnabled)
                {
                    bol = false;
                }
            }
            if (bol)
            {
                int Plus = (int)Det[0].Content* (int)Det[4].Content* (int)Det[8].Content + (int)Det[2].Content * (int)Det[3].Content * (int)Det[7].Content + (int)Det[1].Content * (int)Det[5].Content * (int)Det[6].Content;
                int Minus = (int)Det[2].Content * (int)Det[4].Content * (int)Det[6].Content + (int)Det[1].Content * (int)Det[3].Content * (int)Det[8].Content + (int)Det[0].Content * (int)Det[5].Content * (int)Det[7].Content;

                Determinant D = new Determinant();
                D.Poz1.Text = Plus.ToString();
                D.Neg1.Text = Minus.ToString();
                int det = Plus - Minus;
                D.Determinant1.Text = det.ToString();
                if (det < 0)
                {
                    D.End.Text = "Победил " + this.NegativeName.Text + ", с результатом " + det;
                    D.Name1.Text = this.NegativeName.Text;
                }
                else if (det > 0)
                {
                    D.End.Text = "Победил " + this.PozitiveName.Text + ", с результатом " + det;
                    D.Name1.Text = this.PozitiveName.Text;
                }
                else
                {
                    D.End.Text = "Ничья!!!";
                }

                
                if (D.ShowDialog() == true)
                {
                    D.Close();
                    this.Close();
                }
            }

        }
    }
}
