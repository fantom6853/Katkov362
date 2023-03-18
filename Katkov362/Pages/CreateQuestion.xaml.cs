using KatkovLibrary;
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
    /// Логика взаимодействия для CreateQuestion.xaml
    /// </summary>
    public partial class CreateQuestion : Page
    {
        public CreateQuestion()
        {
            InitializeComponent();
            questionnairelist.SetBinding(ListBox.ItemsSourceProperty, new Binding()
            {
                Source = KatkovLibrary.Class1.Questionnaires
            });
        }
        
        private void createquestionairebutton_Click(object sender, RoutedEventArgs e)
        {
            if (questionairenamebox.Text.Length == 0) return;
            KatkovLibrary.Class1.questionaireAdd(questionairenamebox.Text.ToString(), MainWindow.Authlogin);
            KatkovLibrary.Class1.ListsLoad();
        }

        private void questionnairelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(questionnairelist.SelectedItem == null) return;
            int id = (questionnairelist.SelectedItem as KatkovLibrary.Classes.Questionnaire).id;
            if(id == 0) return;
            CreateQuest.id = id;
            Class1.IdQuest(id);
            NavigationService.Navigate(Katkov362.Classes.nav.CreateQuest);
        }
    }
}
