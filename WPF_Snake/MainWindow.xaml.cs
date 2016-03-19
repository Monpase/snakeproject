﻿using Snake_Project;
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

namespace WPF_Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SnakeRepository sr = new SnakeRepository();
        public MainWindow()
        {
            InitializeComponent();
            listBoxMap.Items.Add("Коробочка");
            listBoxMap.Items.Add("Комнаты");
            listBoxMap.Items.Add("Туннель");
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
            int lvlGame = 0;
            string mapGame = "";
            try
            {
                lvlGame = comboBoxLevel.SelectedIndex + 1;
                mapGame = listBoxMap.SelectedItem.ToString();
                Object selectedLvl = comboBoxLevel.SelectedItem;
                Object selectedMap = listBoxMap.SelectedItem;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите уровень сложности и карту!");
            }
            if (lvlGame > 0 && lvlGame < 11 && (mapGame == "Коробочка" || mapGame == "Комнаты"))
            {
                sr.OnClickPlay();
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonScores_Click(object sender, RoutedEventArgs e)
        {
            //some actions
        }



    }
}

