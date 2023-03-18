using KatkovLibrary;
using KatkovLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

namespace Katkov362.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
            
        }

        private void Authbutton_Click(object sender, RoutedEventArgs e)
        {
            string l = loginbox.Text.ToString();
            string p = passbox.Password.ToString();
            int id = KatkovLibrary.Class1.Auth(l,p);
            int res = KatkovLibrary.Class1.TeacherCheck(id);
            if (id == 0) { return; }
            else 
            {
                MainWindow.Authlogin = l;
                MainWindow.Authpass= p;
                Class1 class1= new Class1();
                
                if (res == 2)
                {
                    MainWindow.teacher = true;
                    loginbox.Text = "";
                    test();
                    NavigationService.Navigate(Katkov362.Classes.nav.TeacherPage);
                }
                else { MainWindow.teacher = false; }
            }
        }
        public static void test()
        {/*
            Class1.AnswerOptions.Add("bb");
            Class1.AnswerOptions.Add("gg");
            Class1.AnswerOptions.Add("vp");
            string jsonstring = JsonSerializer.Serialize(Class1.AnswerOptions);
            Class1.QuestAdd(3, 2, "типо текст", jsonstring);*/
        }
    }
}
