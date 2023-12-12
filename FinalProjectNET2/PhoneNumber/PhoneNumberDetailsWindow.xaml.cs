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
    /// Interaction logic for PhoneNumberDetailsWindow.xaml
    /// </summary>

    public partial class PhoneNumberDetailsWindow : Window
    {
        PhoneNumber phoneNumber2;
        public PhoneNumberDetailsWindow(PhoneNumber phoneNumber)
        {
            InitializeComponent();
            this.phoneNumber2 = phoneNumber;

            //Display the user

            NumberTextBox.Text = phoneNumber.Number;
            TypeTextBox.Text = phoneNumber.Type;

        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            UpdatePhoneNumberWindow updatephoneNumber = new UpdatePhoneNumberWindow(phoneNumber2);
            updatephoneNumber.ShowDialog();
            Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            HandlerPhoneNumber pn = HandlerPhoneNumber.Instance;
            

        }
    }
}
