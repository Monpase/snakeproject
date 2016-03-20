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
using System.Windows.Shapes;

namespace WPF_Snake.VK_API
{
    /// <summary>
    /// Логика взаимодействия для LogInVK.xaml
    /// </summary>
    public partial class LogInVK : Window
    {
        public LogInVK()
        {
            InitializeComponent();
            Webbrowser.Navigate("https://oauth.vk.com/authorize?client_id=5366198&display=page&redirect_uri=https://oauth.vk.com/blank.html&display=page&scope=wall&response_type=token");
        }
    }
}
