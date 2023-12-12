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
    /// Interaction logic for ReferenceDetailsWindow.xaml
    /// </summary>
    public partial class ReferenceDetailsWindow : Window
    {
        References references2;
        public ReferenceDetailsWindow(References references)
        {
            InitializeComponent();
            this.references2 = references;

            //Display the user

            NameTextBox.Text = references.Name;
            descriptionTextBox.Text = references.Description;
            phoneNumberTextBox.Text = references.PhoneNumber;

        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdateReferenceWindow updateReference = new UpdateReferenceWindow(references2);
            updateReference.ShowDialog();
            Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            //HandlerReferences pn = HandlerReferences.Instance;
            //pn.DeleteReference(references2);
            //Close();
        }
    }
}
