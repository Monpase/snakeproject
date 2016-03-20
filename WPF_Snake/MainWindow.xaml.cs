using Snake_Project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.IO;

namespace WPF_Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Record rec = new Record();
        SnakeRepository sr = new SnakeRepository();
        public MainWindow()
        {
            InitializeComponent();
            listBoxMap.Items.Add("Box");
            listBoxMap.Items.Add("Rooms");
            listBoxMap.Items.Add("Tunnel");
            comboBoxLevel.Items.Add("1");
            comboBoxLevel.Items.Add("2");
            comboBoxLevel.Items.Add("3");
            comboBoxLevel.Items.Add("4");
            comboBoxLevel.Items.Add("5");
            comboBoxLevel.Items.Add("6");
            comboBoxLevel.Items.Add("7");
            comboBoxLevel.Items.Add("8");
            comboBoxLevel.Items.Add("9");
            comboBoxLevel.Items.Add("10");
        }

        


        public void Button_Click(object sender, RoutedEventArgs e)
        {
           
           if (comboBoxLevel.SelectedIndex <0 || listBoxMap.SelectedItem == null)
           {
               MessageBox.Show("Set the level and the map!");
               return;
           }
           sr.Level = comboBoxLevel.SelectedIndex+1;
           sr.MapType = listBoxMap.SelectedItem.ToString();
           sr.OnClickPlay();
           
        }

        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ButtonScores_Click(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show(rec.Name + rec.Result);
        }



    }
}

