using KatkovLibrary;
using KatkovLibrary.Classes;
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
    /// Логика взаимодействия для CreateQuest.xaml
    /// </summary>
    public partial class CreateQuest : Page
    {
        public static int id = 0;
        public static string answeroptions = "";
        public CreateQuest()
        {
            InitializeComponent();
            QuestList.SetBinding(ListBox.ItemsSourceProperty, new Binding()
            {
                Source = KatkovLibrary.Class1.QuestsinQuestionnaires
            });
            TypeList.SetBinding(ListBox.ItemsSourceProperty, new Binding()
            {
                Source = KatkovLibrary.Class1.Questionnairetypes
            });
            answeroptionslist.SetBinding(ListBox.ItemsSourceProperty, new Binding()
            {
                Source = KatkovLibrary.Class1.answerOptions
            });
        }
        public static void setId(int id)
        {
            CreateQuest.id = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionText.Text.Trim().Length == 0) return;
            if (TypeList.SelectedItem == null) return;
            int type = (TypeList.SelectedItem as Questionnairetype).id;
            Class1.QuestAdd(CreateQuest.id, type,QuestionText.Text.Trim(),CreateQuest.answeroptions);
            SelectedidPanel.Visibility = Visibility.Hidden;
        }

        private void QuestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestList.SelectedItem == null) return;
            LabelSelectedid.Content= (QuestList.SelectedItem as KatkovLibrary.Classes.Quest).id.ToString();
            SelectedidPanel.Visibility = Visibility.Visible;
            if (TypeList.Items.Count == 0) return;
            TypeList.SelectedIndex = (QuestList.SelectedItem as KatkovLibrary.Classes.Quest).type-1;
        }

        private void TypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeList.SelectedItem == null) return;
            if ((TypeList.SelectedItem as KatkovLibrary.Classes.Questionnairetype).name == "select")
            {

            }
        }

        private void Unselectbutton_Click(object sender, RoutedEventArgs e)
        {
            QuestList.SelectedIndex = 0;
            SelectedidPanel.Visibility = Visibility.Hidden;
        }

        private void answeroptionslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
