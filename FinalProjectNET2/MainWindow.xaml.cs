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
        public DateTime CreatedOnDate { get; set; } = DateTime.Now;

        HandlerPhoneNumber db = HandlerPhoneNumber.Instance;
        List<PhoneNumber> phoneNumbers;

        HandlerEducation ed = HandlerEducation.Instance;
        List<Education> educations;

        HandlerHobbies ho = HandlerHobbies.Instance;
        List<Hobbies> hobbies;

        HandlerReferences refe = HandlerReferences.Instance;
        List<References> references;

        HandlerWorkExperience we = HandlerWorkExperience.Instance;
        List<WorkExperience> workExperience;

        public MainWindow()
        {
            InitializeComponent();
            RefreshhAllPhoneNumberList();
            RefreshAllEducationList();
            RefreshAllHobbiesList();
            RefreshAllReferencesList();
            RefreshAllWorkExperiencesList();
            CreatedOnTodayTextBlock.Text = CreatedOnDate.ToString();


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
            educations = ed.ReadAllEducations();
            AllEducationGrid.ItemsSource = educations;
        }

        private void RefreshAllHobbiesList()
        {
            AllHobbieGrid.ItemsSource = null;
            hobbies = ho.ReadAllHobbies();
            AllHobbieGrid.ItemsSource = hobbies;
        }

        private void RefreshAllReferencesList()
        {
            ReferencesGrid.ItemsSource = null;
            references = refe.ReadAllReferences();
            ReferencesGrid.ItemsSource = references;
        }

        private void RefreshAllWorkExperiencesList()
        {
            AllWorkExperiencesGrid.ItemsSource = null;
            workExperience = we.ReadAllWorkExperiences();
            AllWorkExperiencesGrid.ItemsSource = workExperience;
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

        private void AllHobbieGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hobbies hobbie = (Hobbies)AllHobbieGrid.SelectedItem;

            if (hobbie != null)
            {
                HobbiesDetailsWindow hobbieDetailsWindow = new HobbiesDetailsWindow(hobbie);
                hobbieDetailsWindow.ShowDialog();
                RefreshAllHobbiesList();
            }
        }

        private void ReferencesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            References references = (References)ReferencesGrid.SelectedItem;

            if (references != null)
            {
                ReferenceDetailsWindow referenceDetailsWindow = new ReferenceDetailsWindow(references);
                referenceDetailsWindow.ShowDialog();
                RefreshAllReferencesList();

            }
        }

        private void AllWorkExperiencesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkExperience workExperience = (WorkExperience)AllWorkExperiencesGrid.SelectedItem;

            if (workExperience != null)
            {
                WorkExperienceDetailsWindow workExperienceDetails = new WorkExperienceDetailsWindow(workExperience);
                workExperienceDetails.ShowDialog();
                RefreshAllWorkExperiencesList();
            }
        }

        private void AddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumberWindow addPhoneNumberWindow = new AddPhoneNumberWindow();
          


            addPhoneNumberWindow.ShowDialog();
            CreatedOnDate = DateTime.Now;
            CreatedOnUpdateTextBlock.Text = CreatedOnDate.ToString();
            RefreshhAllPhoneNumberList();
        }

        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {
            AddEducationWindow addEducationWindow = new AddEducationWindow();

            addEducationWindow.ShowDialog();
            CreatedOnDate = DateTime.Now;
            CreatedOnUpdateTextBlock.Text = CreatedOnDate.ToString();
            RefreshAllEducationList();

        }

        private void AddHobbie_Click(object sender, RoutedEventArgs e)
        {
            AddHobbieWindow addHobbiewindow = new AddHobbieWindow();
            addHobbiewindow.ShowDialog();
            CreatedOnDate = DateTime.Now;
            CreatedOnUpdateTextBlock.Text = CreatedOnDate.ToString();
            RefreshAllHobbiesList();

        }


        private void AddReference_Click(object sender, RoutedEventArgs e)
        {
            AddReferenceWindow addReferenceWindow = new AddReferenceWindow();
            addReferenceWindow.ShowDialog();
            CreatedOnDate = DateTime.Now;
            CreatedOnUpdateTextBlock.Text = CreatedOnDate.ToString();
            RefreshAllReferencesList();

        }

        private void AddWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            AddWorkExperienceWindow addWorkExperience = new AddWorkExperienceWindow();
            addWorkExperience.ShowDialog();
            CreatedOnDate = DateTime.Now;
            CreatedOnUpdateTextBlock.Text = CreatedOnDate.ToString();
            RefreshAllWorkExperiencesList();    

        }
    }
}

