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
using System.Windows.Shapes;

namespace FinalProjectNET2
{
    /// <summary>
    /// Interaction logic for WorkExperienceDetailsWindow.xaml
    /// </summary>
    public partial class WorkExperienceDetailsWindow : Window
    {
        WorkExperience workExperience2;
        public WorkExperienceDetailsWindow(WorkExperience workExperience)
        {
            InitializeComponent();
            this.workExperience2 = workExperience;

            companyNameTextBox.Text = workExperience.CompanyName;
            jobTitleTextBox.Text = workExperience.JobTitle;
            yearsSpentTextBox.Text = workExperience.YearsSpent;
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateWorkExperienceWindow updateWorkExperience = new UpdateWorkExperienceWindow(workExperience2);
            updateWorkExperience.ShowDialog();
            Close();

        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            HandlerWorkExperience hwe = HandlerWorkExperience.Instance;
            hwe.DeleteWorkExperience(workExperience2);
            Close();

        }
    }
}
