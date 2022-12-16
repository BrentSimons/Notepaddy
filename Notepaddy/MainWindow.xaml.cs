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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public noteObject activeNote; // 0 means no note is active, actual notes will start counting from higher or sth 
        public List<noteObject> notesListBox = new List<noteObject>();

        public MainWindow()
        {
            InitializeComponent();
            noteObject startingNote = new noteObject() { Title = "starting Note", ID = 0, Note = "Please select a note you would like to open!" };

            activeNote = startingNote;
            textBlock.Text = activeNote.Note;

            // connect to db and fetch notes
            notesListBox.Add(new noteObject() { Title = "Milestone", ID = 1001, Note = "a significant stage or event in the development of something. the speech is being hailed as a milestone in race relations" });
            notesListBox.Add(new noteObject() { Title = "Dev ops", ID = 1002, Note = " DevOps is a set of practices that combines software development (Dev) and IT operations (Ops). It aims to shorten the systems development life cycle and provide continuous delivery with high software quality.[1] DevOps is complementary to agile software development; several DevOps aspects came from the agile way of working. Contents" });
            notesListBox.Add(new noteObject() { Title = "Namur", ID = 1003, Note = "Namur (French: [namyʁ] (listen); German: [naˈmyːɐ̯] (listen); Dutch: Namen [ˈnaːmə(n)] (listen); Walloon: Nameur) is a city and municipality in Wallonia, Belgium. It is both the capital of the province of Namur and of Wallonia, hosting the Parliament of Wallonia, the Government of Wallonia and its administration." });

            noteList.ItemsSource = notesListBox;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nog maken");
        }

        private void minimizeNoteButton_Click(object sender, RoutedEventArgs e)
        {
            // save text to database
            textBlock.Text = "";
        }

        private void deleteNoteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            const string message = "Are you sure you want to delete this note?";
            result = MessageBox.Show(message, "Delete note", MessageBoxButton.YesNo);
            if (result.ToString().Equals("Yes"))
            {
                // Delete note
                textBlock.Text = "eqeq";
                // notesListBox.Remove();
                noteList.ItemsSource = notesListBox;
            }
            else
            {
                // Keep the note!
            }
        }

        private void createNoteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nog maken");
        }

        private void noteList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (noteList.SelectedItem != null)
            {
                textBlock.Text = (noteList.SelectedItem as noteObject).Note;

            }
        }
    }


    public class noteObject
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public string Note { get; set; }
    }
}

