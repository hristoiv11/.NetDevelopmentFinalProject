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
    /// Interaction logic for AddEducationWindow.xaml
    /// </summary>
    public partial class AddEducationWindow : Window
    {
        public AddEducationWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Education education = new Education();
            education.InstitutionName = nameTextBox.Text;
            education.Level = levelTextBox.Text;
            education.Address = addressTextBox.Text;

            HandlerEducation ed = HandlerEducation.Instance;
            ed.AddEducation(education);
            Close();
        }
    }
}
