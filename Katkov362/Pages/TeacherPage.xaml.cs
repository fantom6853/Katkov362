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

namespace Katkov362.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Katkov362.Classes.nav.AddStudents);
        }

        private void GiveButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Katkov362.Classes.nav.GiveQuestion);
        }

        private void QuestionnaireButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Katkov362.Classes.nav.CreateQuestion);
        }
    }
}
