using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace DeterminantGame
{
    /// <summary>
    /// Логика взаимодействия для Determinant.xaml
    /// </summary>
    /// [Serializable]
    /// 

    public class EW : IComparer<Records>
    {
        public int Compare(Records s1, Records s2)
        {

            if (Math.Abs(int.Parse(s1.Record)) < Math.Abs(int.Parse(s2.Record)))
                return 1;
            else if (Math.Abs(int.Parse(s1.Record)) > Math.Abs(int.Parse(s2.Record)))
                return -1;
            else
                return 0;


        }
    }
    public class Records
    {
        public string Name { get; set; }
        public string Record { get; set; }
        public string Mode { get; set; }

        public Records() { }
        public Records(string n, string r, string m)
        {
            Name = n;
            Record = r;
            Mode = m;
        }
        public override string ToString()
        {
            return $"Name: {Name}       Record: {Record}       Mode: {Mode}";
        }
    }
    public partial class Determinant : Window
    {
        public Determinant()
        {
            InitializeComponent();
        }

        private void Theend_Click(object sender, RoutedEventArgs e)
        {
            List<Records> deserilize=new List<Records>();
            XmlSerializer xmlformatter = new XmlSerializer(typeof(List<Records>));
            string filename = "records.xml";
            using (Stream fStream = File.OpenRead(filename))
            {
                deserilize = (List<Records>)xmlformatter.Deserialize(fStream);
            }

            string[] a = this.End.Text.Split(' ');
            if (a.Length > 1 && this.Name1.Text!="Computer")
            {
                if (a[a.Length - 1] != "!")
                {
                    bool flag = true;
                    int cnt = -1;
                    foreach (var i in deserilize)
                    {
                        cnt++;
                        if (i.Name == this.Name1.Text && i.Mode == "Two Players") { flag = false; break; }
                    }

                    if (!flag)
                    {
                        if (Math.Abs(int.Parse(deserilize[cnt].Record)) < Math.Abs(int.Parse(this.Determinant1.Text)))
                        {
                            deserilize[cnt] = new Records(this.Name1.Text, this.Determinant1.Text, "Two Players");
                            deserilize.Sort(new EW());
                        }
                    }
                    else
                    if (deserilize.Count < 10)
                    {
                        deserilize.Add(new Records(this.Name1.Text, this.Determinant1.Text, "Two Players"));
                        deserilize.Sort(new EW());
                    }
                    else
                    {
                        if (Math.Abs(int.Parse(deserilize[9].Record)) < Math.Abs(int.Parse(this.Determinant1.Text)))
                        {
                            deserilize[9] = new Records(this.Name1.Text, this.Determinant1.Text, "Two Players");
                            deserilize.Sort(new EW());
                        }
                    }

                }
                else
                {
                    bool flag = true;
                    int cnt = -1;
                    foreach (var i in deserilize)
                    {
                        cnt++;
                        if (i.Name == this.Name1.Text && i.Mode=="Computer") { flag = false; break; }
                    }

                    if (!flag)
                    {
                        if (Math.Abs(int.Parse(deserilize[cnt].Record)) < Math.Abs(int.Parse(this.Determinant1.Text)))
                        {
                            deserilize[cnt] = new Records(this.Name1.Text, this.Determinant1.Text, "Computer");
                            deserilize.Sort(new EW());
                        }
                    }
                    else
                    if (deserilize.Count < 10)
                    {
                        deserilize.Add(new Records(this.Name1.Text, this.Determinant1.Text, "Computer"));
                        deserilize.Sort(new EW());
                    }
                    else
                    {
                        if (Math.Abs(int.Parse(deserilize[9].Record)) < Math.Abs(int.Parse(this.Determinant1.Text)))
                        {
                            deserilize[9] = new Records(this.Name1.Text, this.Determinant1.Text, "Computer");
                            deserilize.Sort(new EW());
                        }
                    }

                }
            }
            
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Records>));
            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, deserilize);
            }
            this.DialogResult = true;
        }

    }
}
