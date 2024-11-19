using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserManagementApp.Views
{
    /// <summary>
    /// Interaktionslogik für RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string email = EmailTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || password != confirmPassword)
            {
                MessageBox.Show("Überprüfen Sie die Eingaben.");
                return;
            }

            SaveUser(username, password, email);
            MessageBox.Show("Registrierung erfolgreich!");

            var startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void SaveUser(string username, string password, string email)
        {
            string userData = $"{username}|{password}|{email}";
            File.AppendAllLines("users.txt", new[] { userData });
        }
    }
}
