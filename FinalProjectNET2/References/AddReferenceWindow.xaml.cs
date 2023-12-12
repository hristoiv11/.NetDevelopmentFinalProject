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
    /// Interaction logic for AddReferenceWindow.xaml
    /// </summary>
    public partial class AddReferenceWindow : Window
    {
        public AddReferenceWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            References reference = new References();
            reference.Name = NameTextBox.Text;
            reference.Description = descriptionTextBox.Text;
            reference.Name = phoneNumberTextBox.Text;
            


            HandlerReferences db = HandlerReferences.Instance;
            db.AddReference(reference);
            Close();
        }
    }
}
