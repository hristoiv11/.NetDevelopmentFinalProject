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
    /// Interaction logic for AddWorkExperienceWindow.xaml
    /// </summary>
    public partial class AddWorkExperienceWindow : Window
    {
        public AddWorkExperienceWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            WorkExperience workExperience = new WorkExperience();
            workExperience.CompanyName = companyNameTextBox.Text;
            workExperience.JobTitle = jobTitleTextBox.Text;
            workExperience.YearsSpent = yearsSpentTextBox.Text;

            HandlerWorkExperience he = HandlerWorkExperience.Instance;
            he.AddWorkExperience(workExperience);
            Close();
        }
    }
}
