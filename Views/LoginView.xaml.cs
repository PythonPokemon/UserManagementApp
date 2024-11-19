using System;
using System.IO;
using System.Windows;
using UserManagementApp.Utils;

namespace UserManagementApp.Views
{
    /// <summary>
    /// Interaktionslogik für LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (ValidateUser(username, password))
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ungültige Anmeldedaten.");
            }
        }

        private bool ValidateUser(string username, string password)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);

            if (File.Exists("users.txt"))
            {
                foreach (var line in File.ReadAllLines("users.txt"))
                {
                    var parts = line.Split('|');
                    if (parts[2] == username && parts[3] == hashedPassword) // parts[2] = Username, parts[3] = gehashtes Passwort
                        return true;
                }
            }
            return false;
        }
    }
}
