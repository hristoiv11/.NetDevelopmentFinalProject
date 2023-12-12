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
    /// Interaction logic for HobbiesDetailsWindow.xaml
    /// </summary>
    public partial class HobbiesDetailsWindow : Window
    {
        public HobbiesDetailsWindow()
        {
            InitializeComponent();
        }

        Hobbies hobbies;
        public HobbiesDetailsWindow(Hobbies hobbies)
        {
            InitializeComponent();
            this.hobbies = hobbies;

            //Display the user

            DescriptionTextBox.Text = hobbies.Description;

            TypeTextBox.Text = hobbies.Type;

        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateHobbieWindow updateHobbie = new UpdateHobbieWindow(hobbies);
            updateHobbie.ShowDialog();
            Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
