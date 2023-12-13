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
    /// Interaction logic for UpdateWorkExperienceWindow.xaml
    /// </summary>
    public partial class UpdateWorkExperienceWindow : Window
    {
        WorkExperience workExperience2;
        public UpdateWorkExperienceWindow(WorkExperience workExperience)
        {
            this.workExperience2 = workExperience;
            InitializeComponent();
            companyNameTextBox.Text = workExperience.CompanyName; 
            jobTitleTextBox.Text = workExperience.JobTitle;
            yearsSpentTextBox.Text = workExperience.YearsSpent;
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            workExperience2.CompanyName = companyNameTextBox.Text;
            workExperience2.JobTitle = jobTitleTextBox.Text;
            workExperience2.YearsSpent = yearsSpentTextBox.Text;

            HandlerWorkExperience hwe = HandlerWorkExperience.Instance;
            hwe.UpdateWorkExperience(workExperience2);
            Close();
        }
    }
}
