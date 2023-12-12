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
        Hobbies hobbie;
        public UpdateHobbieWindow(Hobbies hobbie)
        {
            this.hobbie = hobbie;
            InitializeComponent();
            DescriptionTextBox.Text = hobbie.Description;
            typeTextBox.Text = hobbie.Type;

        }

        //private void UpdateButton_Click(object sender, RoutedEventArgs e)
        //{

        //    hobbie.Description = DescriptionTextBox.Text;
        //    hobbie.Type = typeTextBox.Text;

        //    HandlerPhoneNumber pn = HandlerPhoneNumber.Instance;
        //    pn.UpdateHobbie(hobbie);
        //    Close();

        //}
    }
}
