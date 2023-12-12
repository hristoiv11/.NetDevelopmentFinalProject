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
    /// Interaction logic for UpdateEducationWindow.xaml
    /// </summary>
    public partial class UpdateEducationWindow : Window
    {
        Education education2;
        public UpdateEducationWindow(Education education)
        {
            this.education2 = education;
            InitializeComponent();
            nameTextBox.Text = education.InstitutionName;
            levelTextBox.Text = education.Level;
            addressTextBox.Text = education.Address;
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            education2.InstitutionName = nameTextBox.Text;
            education2.Level = levelTextBox.Text;
            education2.Address = addressTextBox.Text;

            HandlerEducation he = HandlerEducation.Instance;
            he.UpdateEducation(education2);
            Close();

        }
    }
}
