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
    /// Interaction logic for EducationDetailsWindow.xaml
    /// </summary>
    public partial class EducationDetailsWindow : Window
    {
        Education education2;
        public EducationDetailsWindow(Education education)
        {
            InitializeComponent();
            this.education2 = education;

            nameTextBox.Text = education.InstitutionName;
            levelTextBox.Text = education.Level;
            addressTextBox.Text = education.Address; 

        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateEducationWindow updateEducation = new UpdateEducationWindow(education2);
            updateEducation.ShowDialog();
            Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            HandlerEducation he = HandlerEducation.Instance;
            he.DeleteEducation(education2);
            Close();  
        }
    }
}
