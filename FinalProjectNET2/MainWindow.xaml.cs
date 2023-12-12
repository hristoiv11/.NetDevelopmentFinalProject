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

namespace FinalProjectNET2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        HandlerPhoneNumber db = HandlerPhoneNumber.Instance;
        List<PhoneNumber> phoneNumbers;

        HandlerEducation e = HandlerEducation.Instance;
        List<Education> educations;


        public MainWindow()
        {
            InitializeComponent();
            RefreshhAllPhoneNumberList();
            RefreshAllEducationList();


        }

        private void RefreshhAllPhoneNumberList()
        {
            AllPhoneNumberDataGrid.ItemsSource = null;
            phoneNumbers = db.ReadAllPhoneNumbers();
            AllPhoneNumberDataGrid.ItemsSource = phoneNumbers;
        }

        private void RefreshAllEducationList()
        {
            AllEducationGrid.ItemsSource = null;
            educations = e.ReadAllEducations();
            AllEducationGrid.ItemsSource= educations;
        }

        private void AllPhoneNumberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhoneNumber phoneNumber = (PhoneNumber)AllPhoneNumberDataGrid.SelectedItem;

            if (phoneNumber != null)
            {
                PhoneNumberDetailsWindow personDetailsWindow = new PhoneNumberDetailsWindow(phoneNumber);
                personDetailsWindow.ShowDialog();
                RefreshhAllPhoneNumberList();
            }
        }

        private void AllEducationGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Education education = (Education)AllEducationGrid.SelectedItem;

            if (education != null)
            {
                EducationDetailsWindow educationDetailsWindow = new EducationDetailsWindow(education);
                educationDetailsWindow.ShowDialog();
                RefreshAllEducationList();
            }
        }

        private void AddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumberWindow addPhoneNumberWindow = new AddPhoneNumberWindow();


            addPhoneNumberWindow.ShowDialog();
            RefreshhAllPhoneNumberList();
        }

        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {
            AddEducationWindow addEducationWindow = new AddEducationWindow();

            addEducationWindow.ShowDialog();
            RefreshAllEducationList();

        }
        private void AllReferencesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void AddReference_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReferencesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
