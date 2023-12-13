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
        References reference2;
        public UpdateReferenceWindow(References references)
        {
            this.reference2 = references;
            InitializeComponent();
            nameTextBox.Text = references.Name;
            descriptionTextBox.Text = references.Description;
            phoneNumberTextBox.Text = references.PhoneNumber;
            emailTextBox.Text = references.Email;
            

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            reference2.Name = nameTextBox.Text;
            reference2.Description = descriptionTextBox.Text;
            reference2.PhoneNumber = phoneNumberTextBox.Text;
            reference2.Email = emailTextBox.Text;

            HandlerReferences pn = HandlerReferences.Instance;
            pn.UpdateReference(reference2);
            Close();

        }
    }
}
