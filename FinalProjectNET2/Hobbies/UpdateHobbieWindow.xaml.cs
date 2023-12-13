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
    /// Interaction logic for UpdateHobbieWindow.xaml
    /// </summary>
    public partial class UpdateHobbieWindow : Window
    {
        Hobbies hobbies2;
        public UpdateHobbieWindow(Hobbies hobbie)
        {
            this.hobbies2 = hobbie;
            InitializeComponent();
            descriptionTextBox.Text = hobbie.Description;
            typeTextBox.Text = hobbie.Type;

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
            hobbies2.Description = descriptionTextBox.Text;
            hobbies2.Type = typeTextBox.Text;

            HandlerHobbies hh = HandlerHobbies.Instance;
            hh.UpdateHobbie(hobbies2);
            Close();
        }

    }
}
