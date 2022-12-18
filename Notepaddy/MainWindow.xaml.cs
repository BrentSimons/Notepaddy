using Dapper;
using Notepaddy;
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
// Used for console logging: use "Trace.WriteLine("text");" to log to output window
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // Used to populate the listbox object
        public List<NoteObject> notesListBox = new List<NoteObject>();

        // Used for connecting to DB
        public QueryManagement queryManagement { get; } = new QueryManagement();

        // This is the title of the active note
        public string selectedGlobalNote;
        public MainWindow()
        {
            InitializeComponent();

            // The following query can be used to manually drop the table for testing 
            /* queryManagement.getConnection().Execute("drop table noteObject;"); */

            // This query makes the table (if it doesnt exist).
            queryManagement.getConnection().Execute("create table if not exists noteObject(title varchar(50), note varchar(512));");
            // SQLite does not enforce length of a varchar, in actuallity it can be up to 500million chars long

            // The following query can be used to manually make a note object in the database for testing purposes:
            /* queryManagement.getConnection().Execute("insert into noteObject(title, note ) values(@title, @note)",
                new {title = "Milestone", note = "blablablablablablablablablablablabla" }); */

            // This adds some flavor text:
            textBlock.Text = "Please select a note you would like to open!";

            // Connects to the db and fetches all existing notes and puts them in a list.
            notesListBox = queryManagement.getConnection().Query<NoteObject>("select * from noteObject").ToList();
            // Populates the listbox object
            noteList.ItemsSource = notesListBox;

            // This allows the user to newline in the textbox
            textBlock.AcceptsReturn = true;
        }

        private void minimizeNoteButton_Click(object sender, RoutedEventArgs e)
        {
            // when the user presses this button the current text will be saved
            queryManagement.getConnection().Execute("update noteObject set note=@note where title=@title",
                new { title = selectedGlobalNote, note = textBlock.Text });

            // the text box will be emptied and the selectedGlobalNote will be emptied
            textBlock.Text = "";
            selectedGlobalNote = "";
        }

        private void deleteNoteButton_Click(object sender, RoutedEventArgs e)
        {
            // Message for the messagebox
            const string message = "Are you sure you want to delete this note?";

            // Shows a messagebox prompting yes or no.
            MessageBoxResult result = MessageBox.Show(message, "Delete note", MessageBoxButton.YesNo);

            if (result.ToString().Equals("Yes"))
            {
                // Reset the text on the machine
                textBlock.Text = "";

                // Delete note based on the title of the current selected note
                queryManagement.getConnection().Execute("delete from noteObject where title=@title",
                    new { title = selectedGlobalNote} );
                selectedGlobalNote = "";

                // Grab a new list of all note
                notesListBox = queryManagement.getConnection().Query<NoteObject>("select * from noteObject").ToList();
                // Put the new list as the item source
                noteList.ItemsSource = notesListBox;
                // Refresh the list
                noteList.Items.Refresh();
            }
        }

        private void createNoteButton_Click(object sender, RoutedEventArgs e)
        {
            // Get note title in textblock and query for note with that title
            string tempNoteTitle = createNoteName.Text;
            List<string> listNotesWithTempTitle = queryManagement.getConnection().Query<string>("select title from noteObject where title = @title", new { title = tempNoteTitle }).ToList();

            // Check if the new note title already exists in the query
            if (listNotesWithTempTitle.Contains(tempNoteTitle))
            {
                // The new note title already exists, throw an error messagebox informing user
                const string message = "A note with this name already exists!";
                MessageBox.Show(message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            } else
            {
                // No other note exists with this name so we can continue
                // Creates a new note with no text, the name of the note comes from the textbox next to the button, add it to the Database
                queryManagement.getConnection().Execute("insert into noteObject(title , note ) values(@title, @note)",
                    new { title = tempNoteTitle, note = "" });

                // Create the new note locally and add it to the listbox
                NoteObject tempNoteObject = new NoteObject() { Title = tempNoteTitle, Note = "" };
                notesListBox.Add(tempNoteObject);
                // Refreshed the listbox
                noteList.Items.Refresh();
            }
        }

        private void noteList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check if the user selects a different item. 
            // (Needed because deselecting when clicking on something else also counts as changing selection)
            if (noteList.SelectedItem != null)
            {
                // Set selectedGlobalNote title
                selectedGlobalNote = (noteList.SelectedItem as NoteObject).Title;

                // Since the Note text saved in the noteList is not always accurate we will
                // pull this from the database.
                List<string> selectedGlobalNoteText = queryManagement.getConnection().Query<string>("select note from noteObject where title = @title", new { title = selectedGlobalNote }).ToList();
                // This has to be a list for some reason (probably did something wrong)
                textBlock.Text = selectedGlobalNoteText[0];
            }
        }

        private void leaveTextBlockFocus(object sender, RoutedEventArgs e)
        {
            // Make sure user has selected a note
            if (selectedGlobalNote != "")
            {
                // when the user leaves the focus of the textblock the current text will be saved
                queryManagement.getConnection().Execute("update noteObject set note=@note where title=@title",
                    new { title = selectedGlobalNote, note = textBlock.Text });
            }
        }
    }

    // This is the NoteObject, the Title is the name of the note in the listbox
    //                         the Note is the text in the textbox
    public class NoteObject
    {
        public string Title { get; set; }
        public string Note { get; set; }
    }
}

