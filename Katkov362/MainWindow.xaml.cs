using Katkov362.Pages;
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
using Npgsql;
using NpgsqlTypes;
using System.Collections.ObjectModel;
using Katkov362.Classes;
using KatkovLibrary;

namespace Katkov362
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool teacher { get; set; }
        public static string host = "10.14.206.27";
        public static int port = 5432;
        public static string user = "student";
        public static string pass = "1234";
        public static string dbname = "katkov362";
        public static string Authlogin = "";
        public static string Authpass = "";

        public MainWindow()
        {
            InitializeComponent();
            KatkovLibrary.Class1.Connect(host.ToString(),port,user.ToString(),pass.ToString(),dbname.ToString());
            DataContext = this;
            AppFrame.Navigate(nav.Auth);
        }
        public static void AuthTeacher()
        {
            
        }
        public static void AuthStudent()
        {

        }
        
    }
}
