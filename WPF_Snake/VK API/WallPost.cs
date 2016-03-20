using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WPF_Snake.VK_API
{
    public class WallPost
    {
        public string AppID = "5366198";
        public string token;

        WebBrowser wb = new WebBrowser();
        LogInVK ww;
        public string Header { get { return "Share"; } }
        private ICommand _post;
        WebBrowser webbrowser = new WebBrowser();
        public ICommand Post
        {
            get
            {
                return _post ?? (_post = new RelayCommand(() =>
                {
                    Log();
                }));
            }
        }
        public void Log()
        {
            ww = new LogInVK();
            token = null;
            ww.Webbrowser.Navigated += new NavigatedEventHandler(LogAccept);
            ww.ShowDialog();
            
        }
        public void LogAccept(object sender, NavigationEventArgs e)
        {
            string[] parts = e.Uri.AbsoluteUri.Split('#');
            if (parts[0] == "https://oauth.vk.com/blank.html")
            {
                if (parts.Count() == 2)
                {
                    if (parts[1].Substring(0, 5) == "ERROR") ww.Close();
                    else if (parts[1].Substring(0, 12) == "token")
                    {
                        token = parts[1].Split('=')[1].Split('&')[0];
                        
                        string message = "My new Record in Snake";
                        var str = string.Format("https://api.vk.com/method/wall.post?message={0}&token={1}", message, token);
                        Uri uri = new Uri(str);
                        
                        
                        this.ww.Close();
                        
                    }
                }
                else
                {
                    ww.Close();
                   
                }
            }
            else
            {
                parts = e.Uri.AbsoluteUri.Split('?');
                if (parts[0] == "https://oauth.vk.com/oauth/authorize")
                    webbrowser.Navigate("https://oauth.vk.com/authorize?client_id=5330828&display=page&redirect_uri=https://oauth.vk.com/blank.html&display=page&scope=friends,wall&response_type=token");
                
            }
        }


    }
}
