using System;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    ///     Ross Muego
    ///     23/10/2017
    ///     Main window class, included in this is the main form, where you can
    ///     matriculate students, view students, search for them and delete them.
    ///     Made up of a number of event driven actions such as clicking on
    ///     buttons and selecting items in a listbox. 
    /// </summary>
    public partial class MainWindow : Window
    {

        //  Creating a new instance of ModuleList named 'store' and also 
        //  initilising 2 variables for the matriculation counter

        private ModuleList store = new ModuleList();
        private int matricBase = 10001;
        private int matricSet;
        public Boolean deleted = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        //  Event to add a new student to the system when the button
        //  is clicked
        private void btnMatric_Click(object sender, RoutedEventArgs e)
        {
            
            //  try/catch statement to check that the values entered
            //  are valid and within range etc. If there is an exception
            //  thrown it will be caught and displayed in the messagebox.
            //  if there are not exceptions caught then it will add the 
            //  student to the store list we created earlier. 

            try
            {
                Student aStudent = new Student();
                aStudent.Forename = txtForename.Text;
                aStudent.Surname = txtSurname.Text;
                aStudent.ExamMark = Convert.ToDouble(txtExam.Text);
                aStudent.CourseworkMark = Convert.ToDouble(txtCoursework.Text);
                aStudent.DateOfBirth = datePicker.SelectedDate.Value;
                aStudent.Matric = newStudent();

                listAllMatrics.Items.Add(aStudent.Matric);

                store.add(aStudent);
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }

            //  Setting the value of the text boxes and date picker
            //  to be blank once the student has been added.

            txtForename.Text = null;
            txtSurname.Text = null;
            txtCoursework.Text = null;
            txtExam.Text = null;
            datePicker.Text = null;
        }

        //  Method to generate a new matriculation number everytime
        //  a student is added. Simply checks the current matric and 
        //  if less than 50000 add one and return that number.
        public int newStudent()
        {

            if (matricBase < 50000)
            {
                matricSet = matricBase;
                matricBase = matricBase + 1;

                return matricSet;
            } else
            {
                MessageBox.Show("You have exceded the max number of students");
                return 0;
            }
        }

        //  Event carried out when the user searches for a matric number
        //  using the search box. Gets the input from the text box and 
        //  converts it to an int, creates a new student object and sets
        //  its properties to that of the found student. It then assds to the corosponding properties ie forename, surname
        //  etc. The if statement that it is encapsulated in checks that the 
        //  text box has not been left blank.

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(txtMatricSearch.Text == "")
            {
                MessageBox.Show("No Input");
            } else
            {
                listResults.Items.Clear();

                try
                {
                    int matricSearched = Convert.ToInt32(txtMatricSearch.Text);

                    Student searchBoxSearch = store.find(matricSearched);

                    listResults.Items.Add(searchBoxSearch.Matric);
                    listResults.Items.Add(searchBoxSearch.Forename);
                    listResults.Items.Add(searchBoxSearch.Surname);
                    listResults.Items.Add(searchBoxSearch.DateOfBirth);
                    listResults.Items.Add(searchBoxSearch.ExamMark);
                    listResults.Items.Add(searchBoxSearch.CourseworkMark);
                    listResults.Items.Add(searchBoxSearch.getMark + "%");
                } catch
                {
                    MessageBox.Show("Student does not exist");
                }
                
            }
            
        }

        //  Listbox displaying all the student matric numbers in
        //  the system. New matric is added each time a new student
        //  is added. It also checks to see if when a student has been removed 
        //  there are any other students and depending on the result of the 
        //  check appropriatley displays a message.

        private void listAllMatrics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            listResults.Items.Clear();

            if (listAllMatrics.Items.Count == 0)
            {
                MessageBox.Show("No students remain");
            }
            else
            {
                if(deleted == false)
                {
                    int matricSelected = Convert.ToInt32(listAllMatrics.SelectedValue.ToString());

                    Student listSelected = store.find(matricSelected);

                    listResults.Items.Add(listSelected.Matric);
                    listResults.Items.Add(listSelected.Forename);
                    listResults.Items.Add(listSelected.Surname);
                    listResults.Items.Add(listSelected.DateOfBirth);
                    listResults.Items.Add(listSelected.ExamMark);
                    listResults.Items.Add(listSelected.CourseworkMark);
                    listResults.Items.Add(listSelected.getMark + "%");
                }

                deleted = false;
                
            }
        }

        //  Opens a new window when the button is clicked showing the 
        //  user a list of all the students in the system along with 
        //  all their details and their final mark. It passes the list 
        //  of all the students into the new window in order to dispay them. 

        private void btnListAll_Click(object sender, RoutedEventArgs e)
        {
            ListAllStudents newWin = new ListAllStudents(store);
            newWin.ShowDialog();
        }

        //  Button to delete the student from the system. Works by getting
        //  the student matric from the listbox with the current student
        //  selected. It then uses the delete method from the ModuleList class
        //  to delete the selected student. It then removes the matric from
        //  the list of all matrics and clears the listbox with the students 
        //  search results. 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleted = true; 

            if (listResults.Items[0] == null)
            {
                MessageBox.Show("No student selected");
            }
            else
            {
                store.delete(Convert.ToInt32(listResults.Items[0].ToString()));
                MessageBox.Show("Student Deleted");
                listAllMatrics.Items.Remove(listResults.Items[0]);
                listResults.Items.Clear();
            }
        }
    }
}
