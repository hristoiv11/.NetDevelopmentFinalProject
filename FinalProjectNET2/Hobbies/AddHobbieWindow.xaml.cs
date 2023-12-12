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
    /// Interaction logic for AddHobbieWindow.xaml
    /// </summary>
    public partial class AddHobbieWindow : Window
    {
        public AddHobbieWindow()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Hobbies newHobbie = new Hobbies();
            newHobbie.Description = HobbiesTextBox.Text;
            newHobbie.Type = typeTextBox.Text;


            HandlerHobbies db = HandlerHobbies.Instance;
            db.AddHobbie(newHobbie);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window and return false to indicate cancellation
            DialogResult = false;
        }
    }
}
