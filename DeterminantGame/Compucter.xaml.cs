using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DeterminantGame
{
    /// <summary>
    /// Логика взаимодействия для Compucter.xaml
    /// </summary>
    public partial class Compucter : Window

    {
        public Compucter()
        {
            InitializeComponent();
        }

        internal List<Button> Det;
        internal int[]AA=new int[9];
        internal List<Button> B;
        internal int b = -1;
        internal SortedSet<int> list=new SortedSet<int>();

        private void MotionComputer(int i,int cnt)
        {
            Det[cnt].Foreground = new SolidColorBrush(Color.FromRgb(102, 153, 255));
            Det[cnt].Content = i + 1;
            AA[cnt] = i + 1;
            Det[cnt].IsEnabled = false;
            B[i].IsEnabled = false;
        }

        public void A_Click1(object sender, RoutedEventArgs e)
        {
            var cell = (Button)sender;
            string name = cell.Name;
            int a1 = int.Parse(name[1].ToString()) - 1;
            if (b != -1)
            {
                Det[a1].Foreground = new SolidColorBrush(Color.FromRgb(204, 153, 51));
                Det[a1].Content = b;
                AA[a1] = b;
                list.Remove(b);
                B[b - 1].IsEnabled = false;
                Det[a1].IsEnabled = false;
                b = -1;

                Random R = new Random();
                int rand = R.Next(0, 2);

                if (rand == 0)
                {
                    for (int i = 8; i >= 0; i--)
                    {
                        if (B[i].IsEnabled)
                        {

                            int A1 = AA[2] * AA[4] * AA[6];
                            int A2 = AA[0] * AA[5] * AA[7];
                            int A3 = AA[1] * AA[3] * AA[8];
                            if (A1 >= A2 && A1 >= A3)
                            {
                                if (Det[2].IsEnabled)
                                {
                                    MotionComputer(i, 2);
                                    break;
                                }
                                if (Det[4].IsEnabled)
                                {
                                    MotionComputer(i, 4);
                                    break;
                                }
                                if (Det[6].IsEnabled)
                                {
                                    MotionComputer(i, 6);
                                    break;
                                }
                                if (A2 >= A3)
                                {
                                    if (Det[0].IsEnabled)
                                    {
                                        MotionComputer(i, 0);
                                        break;
                                    }
                                    if (Det[5].IsEnabled)
                                    {
                                        MotionComputer(i, 5);
                                        break;
                                    }
                                    if (Det[7].IsEnabled)
                                    {
                                        MotionComputer(i, 7);
                                        break;
                                    }
                                }
                                if (Det[1].IsEnabled)
                                {
                                    MotionComputer(i, 1);
                                    break;
                                }
                                if (Det[3].IsEnabled)
                                {
                                    MotionComputer(i, 3);
                                    break;
                                }
                                if (Det[8].IsEnabled)
                                {
                                    MotionComputer(i, 8);
                                    break;
                                }
                            }

                            if (A2 >= A1 && A2 >= A3)
                            {
                                if (Det[0].IsEnabled)
                                {
                                    MotionComputer(i, 0);
                                    break;
                                }
                                if (Det[5].IsEnabled)
                                {
                                    MotionComputer(i, 5);
                                    break;
                                }
                                if (Det[7].IsEnabled)
                                {
                                    MotionComputer(i, 7);
                                    break;
                                }
                                if (A1 >= A3)
                                {
                                    if (Det[2].IsEnabled)
                                    {
                                        MotionComputer(i, 2);
                                        break;
                                    }
                                    if (Det[4].IsEnabled)
                                    {
                                        MotionComputer(i, 4);
                                        break;
                                    }
                                    if (Det[6].IsEnabled)
                                    {
                                        MotionComputer(i, 6);
                                        break;
                                    }
                                }
                                if (Det[1].IsEnabled)
                                {
                                    MotionComputer(i, 1);
                                    break;
                                }
                                if (Det[3].IsEnabled)
                                {
                                    MotionComputer(i, 3);
                                    break;
                                }
                                if (Det[8].IsEnabled)
                                {
                                    MotionComputer(i, 8);
                                    break;
                                }
                            }

                            if (A3 >= A1 && A3 >= A2)
                            {
                                if (Det[1].IsEnabled)
                                {
                                    MotionComputer(i, 1);
                                    break;
                                }
                                if (Det[3].IsEnabled)
                                {
                                    MotionComputer(i, 3);
                                    break;
                                }
                                if (Det[8].IsEnabled)
                                {
                                    MotionComputer(i, 8);
                                    break;
                                }
                                if (A2 >= A1)
                                {
                                    if (Det[0].IsEnabled)
                                    {
                                        MotionComputer(i, 0);
                                        break;
                                    }
                                    if (Det[5].IsEnabled)
                                    {
                                        MotionComputer(i, 5);
                                        break;
                                    }
                                    if (Det[7].IsEnabled)
                                    {
                                        MotionComputer(i, 7);
                                        break;
                                    }
                                }
                                if (Det[2].IsEnabled)
                                {
                                    MotionComputer(i, 2);
                                    break;
                                }
                                if (Det[4].IsEnabled)
                                {
                                    MotionComputer(i, 4);
                                    break;
                                }
                                if (Det[6].IsEnabled)
                                {
                                    MotionComputer(i, 6);
                                    break;
                                }
                            }
                            int cnt = -1;
                            foreach (var j in Det)
                            {
                                cnt++;
                                if (j.IsEnabled)
                                {
                                    j.Foreground = new SolidColorBrush(Color.FromRgb(102, 153, 255));
                                    j.Content = i + 1;
                                    AA[cnt] = i + 1;
                                    j.IsEnabled = false;
                                    B[i].IsEnabled = false;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (B[i].IsEnabled)
                        {
                            int A1 = AA[0] * AA[4] * AA[8];
                            int A2 = AA[1] * AA[5] * AA[6];
                            int A3 = AA[2] * AA[3] * AA[7];
                            if (A1 >= A2 && A1 >= A3)
                            {
                                if (Det[0].IsEnabled)
                                {
                                    MotionComputer(i, 0);
                                    break;
                                }
                                if (Det[4].IsEnabled)
                                {
                                    MotionComputer(i, 4);
                                    break;
                                }
                                if (Det[8].IsEnabled)
                                {
                                    MotionComputer(i, 8);
                                    break;
                                }
                                if (A2 >= A3)
                                {
                                    if (Det[1].IsEnabled)
                                    {
                                        MotionComputer(i, 1);
                                        break;
                                    }
                                    if (Det[5].IsEnabled)
                                    {
                                        MotionComputer(i, 5);
                                        break;
                                    }
                                    if (Det[6].IsEnabled)
                                    {
                                        MotionComputer(i, 6);
                                        break;
                                    }
                                }
                                if (Det[2].IsEnabled)
                                {
                                    MotionComputer(i, 2);
                                    break;
                                }
                                if (Det[3].IsEnabled)
                                {
                                    MotionComputer(i, 3);
                                    break;
                                }
                                if (Det[7].IsEnabled)
                                {
                                    MotionComputer(i, 7);
                                    break;
                                }
                            }

                            if (A2 >= A1 && A2 >= A3)
                            {
                                if (Det[1].IsEnabled)
                                {
                                    MotionComputer(i, 1);
                                    break;
                                }
                                if (Det[5].IsEnabled)
                                {
                                    MotionComputer(i, 5);
                                    break;
                                }
                                if (Det[6].IsEnabled)
                                {
                                    MotionComputer(i, 6);
                                    break;
                                }
                                if (A1 >= A3)
                                {
                                    if (Det[0].IsEnabled)
                                    {
                                        MotionComputer(i, 0);
                                        break;
                                    }
                                    if (Det[4].IsEnabled)
                                    {
                                        MotionComputer(i, 4);
                                        break;
                                    }
                                    if (Det[8].IsEnabled)
                                    {
                                        MotionComputer(i, 8);
                                        break;
                                    }
                                }
                                if (Det[2].IsEnabled)
                                {
                                    MotionComputer(i, 2);
                                    break;
                                }
                                if (Det[3].IsEnabled)
                                {
                                    MotionComputer(i, 3);
                                    break;
                                }
                                if (Det[7].IsEnabled)
                                {
                                    MotionComputer(i, 7);
                                    break;
                                }
                            }

                            if (A3 >= A1 && A3 >= A2)
                            {
                                if (Det[2].IsEnabled)
                                {
                                    MotionComputer(i, 2);
                                    break;
                                }
                                if (Det[3].IsEnabled)
                                {
                                    MotionComputer(i, 3);
                                    break;
                                }
                                if (Det[7].IsEnabled)
                                {
                                    MotionComputer(i, 7);
                                    break;
                                }
                                if (A1 >= A2)
                                {
                                    if (Det[0].IsEnabled)
                                    {
                                        MotionComputer(i, 0);
                                        break;
                                    }
                                    if (Det[4].IsEnabled)
                                    {
                                        MotionComputer(i, 4);
                                        break;
                                    }
                                    if (Det[8].IsEnabled)
                                    {
                                        MotionComputer(i, 8);
                                        break;
                                    }
                                }
                                if (Det[1].IsEnabled)
                                {
                                    MotionComputer(i, 1);
                                    break;
                                }
                                if (Det[5].IsEnabled)
                                {
                                    MotionComputer(i, 5);
                                    break;
                                }
                                if (Det[6].IsEnabled)
                                {
                                    MotionComputer(i, 6);
                                    break;
                                }
                            }
                            int cnt = -1;
                            foreach (var j in Det)
                            {
                                cnt++;
                                if (j.IsEnabled)
                                {
                                    j.Foreground = new SolidColorBrush(Color.FromRgb(102, 153, 255));
                                    j.Content = i + 1;
                                    AA[cnt] = i + 1;
                                    j.IsEnabled = false;
                                    B[i].IsEnabled = false;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

            }
        }

        public void B_Click1(object sender, RoutedEventArgs e)
        {
            var cell = (Button)sender;
            string name = cell.Name;
            int b1 = int.Parse(name[1].ToString());
            if (b != -1)
            {
                B[b - 1].Background = new SolidColorBrush(Color.FromRgb(204, 204, 102));
            }
            b = b1;
            B[b - 1].Background = new SolidColorBrush(Color.FromRgb(102, 102, 102));
        }
            
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (this.PozitiveName.Text.Length > 0)
            {

                for (int i = 1; i < 10; i++)
                {
                    list.Add(i);
                }
                for (int i = 0; i < 9; i++)
                {
                    AA[i] = 1;
                }
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

                foreach (var i in B)
                {
                    i.IsEnabled = true;
                }

                this.next.IsEnabled = false;
                this.names.IsEnabled = false;
                this.names.Visibility = Visibility.Hidden;
                this.next.Visibility = Visibility.Hidden;
                this.DET.Visibility = Visibility.Visible;
                this.next.IsEnabled = false;
                this.PozitiveName.IsEnabled = false;

                foreach (var i in B)
                {
                    i.Background = new SolidColorBrush(Color.FromRgb(204, 204, 102));
                }
            }
            else
            {
                MessageBox.Show("Введите свое имя!");
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
                int Plus = (int)Det[0].Content * (int)Det[4].Content * (int)Det[8].Content + (int)Det[2].Content * (int)Det[3].Content * (int)Det[7].Content + (int)Det[1].Content * (int)Det[5].Content * (int)Det[6].Content;
                int Minus = (int)Det[2].Content * (int)Det[4].Content * (int)Det[6].Content + (int)Det[1].Content * (int)Det[3].Content * (int)Det[8].Content + (int)Det[0].Content * (int)Det[5].Content * (int)Det[7].Content;

                Determinant D = new Determinant();
                D.Poz1.Text = Plus.ToString();
                D.Neg1.Text = Minus.ToString();
                int det = Plus - Minus;
                D.Determinant1.Text = det.ToString();
                if (det < 0)
                {
                    D.Name1.Text = "Computer";
                   D.End.Text = "Победил компьютер, с результатом " + det;
                }
                else if (det > 0)
                {
                    D.Name1.Text = this.PozitiveName.Text;
                    D.End.Text = "Победил " + this.PozitiveName.Text + ", с результатом " + det+" !";
                }
                else
                {
                    D.End.Text = "Ничья!!!";
                }
                if (D.ShowDialog() == true)
                {
                    D.Close();
                    this.DialogResult = true;
                    //this.Close();
                }
            }
        }
    }
}
