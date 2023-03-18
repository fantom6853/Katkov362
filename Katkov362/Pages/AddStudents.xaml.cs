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
    /// Логика взаимодействия для AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Page
    {
        public AddStudents()
        {
            InitializeComponent();
            GroupList.SetBinding(ListBox.ItemsSourceProperty, new Binding()
            {
                Source = KatkovLibrary.Class1.Groups
            }) ;
        }

        private void StudentAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginText.Text.Length == 0 || PassText.Text.Length == 0 || GroupList.SelectedItem==null || NameText.Text.Length ==0 || SurenameText.Text.Length == 0) return;
            string patronimic;
            if (PatronimicText.Text.Length >= 0) patronimic = PatronimicText.Text.ToString();
            else patronimic = "0";
            var group = GroupList.SelectedItem as KatkovLibrary.Classes.Group;
            if (group == null) return;
            
            KatkovLibrary.Class1.StudentAdd(LoginText.Text.ToString(),PassText.Text.ToString(),NameText.Text.ToString(),SurenameText.Text.ToString(),patronimic, group.id);
            LoginText.Text = "";
            PassText.Text = "";
            NameText.Text= "";
            SurenameText.Text = "";
            PatronimicText.Text = "";
        }
    }
}
