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
    /// Interaction logic for UpdateReferenceWindow.xaml
    /// </summary>
    public partial class UpdateReferenceWindow : Window
    {
        References references2;
        public UpdateReferenceWindow(References references)
        {
            this.references2 = references;
            InitializeComponent();
            nameTextBox.Text = references.Name;
            descriptionTextBox.Text = references.Description;
            phoneNumberTextBox.Text = references.PhoneNumber;
            

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            //references2.Name = nameTextBox.Text;
            //references2.Description = descriptionTextBox.Text;
            //references2.PhoneNumber = phoneNumberTextBox.Text;

            //HandlerReferences pn = HandlerReferences.Instance;
            //pn.UpdateP(phoneNumber2);
            //Close();

        }
    }
}
