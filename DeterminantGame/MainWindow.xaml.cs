using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace DeterminantGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
  
    public partial class MainWindow : Window
    {
        internal SoundPlayer sp;
        public MainWindow()
        {
            InitializeComponent();
            var dir = Environment.CurrentDirectory;
            var cource = Path.Combine(dir, "bez-imeni-dozhd-v-lesu.wav");
            sp = new SoundPlayer
            {
                SoundLocation = cource
            };
            sp.Load();
            sp.PlayLooping();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Compucter compucter= new Compucter();
           
            compucter.ShowDialog();
        }
        
        private void Exit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TwoGames_Click(object sender, RoutedEventArgs e)
        {
            Names names1 = new Names(); 
           
            names1.ShowDialog();
        }

        private void Records_Click(object sender, RoutedEventArgs e)
        {
            List<Records> deserilize = new List<Records>();
            XmlSerializer xmlformatter = new XmlSerializer(typeof(List<Records>));
            string filename = "records.xml";
            using (Stream fStream = File.OpenRead(filename))
            {
                deserilize = (List<Records>)xmlformatter.Deserialize(fStream);
            }
            Rec r = new Rec();
            int count = 1;
            foreach(var i in deserilize)
            {
                r.R.Items.Add(count+". "+i.ToString());
                count++;
            }
            r.Show();
        }

        private void Reference_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        
        private void NotVoice_Click(object sender, RoutedEventArgs e)
        {
            var but = (Button)sender;
            if (but.Style == (Style)Application.Current.FindResource("SoundButtonOn"))
            {
                but.Style = (Style)Application.Current.FindResource("SoundButtonOff");
                sp.Stop();
            }
            else
            {
                but.Style = (Style)Application.Current.FindResource("SoundButtonOn");
                sp.Play();
            }
        }
    }
}
