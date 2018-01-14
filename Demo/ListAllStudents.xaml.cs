using System.Collections.Generic;
using System.Windows;
using BusinessObjects;


namespace Demo
{
    /// <summary>
    ///     Ross Muego
    ///     23/10/2017
    ///     This is the class to display all the students in the system.
    ///     In order to do this a ModuleList is passed from the main 
    ///     window and then looped through displaying all the students.
    ///     It also has a button to close the window and return to the
    ///     main window.
    /// </summary>
    public partial class ListAllStudents : Window
    {

        //  When the form is loaded it loops through a list
        //  of matrics, finding the corrosponding student
        //  and displaying their details in a griwview within
        //  a listview.
        public ListAllStudents(ModuleList x)
        {
            InitializeComponent();

            List<int> matricList = x.matrics;
            List<Student> items = new List<Student>();

            foreach (var matric in matricList)
            {

                Student current = x.find(matric);
                items.Add(current);
                listAllStudents.ItemsSource = items;
            }
        }

        private void btnListAllClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // studentViewSource.Source = [generic data source]
        }
    }
}
