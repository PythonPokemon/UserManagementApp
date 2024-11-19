﻿using System;
using System.IO;
using System.Windows;
using UserManagementApp.Utils;

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
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            string address = AddressTextBox.Text;
            string birthDate = BirthDatePicker.SelectedDate?.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || password != confirmPassword)
            {
                MessageBox.Show("Überprüfen Sie die Eingaben.");
                return;
            }

            // Das Passwort wird hier gehasht
            string hashedPassword = PasswordHelper.HashPassword(password);

            // Speichern der Benutzerdaten
            SaveUser(firstName, lastName, username, hashedPassword, email, phone, address, birthDate);
            MessageBox.Show("Registrierung erfolgreich!");

            var startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void SaveUser(string firstName, string lastName, string username, string hashedPassword, string email, string phone, string address, string birthDate)
        {
            string userData = $"{firstName}|{lastName}|{username}|{hashedPassword}|{email}|{phone}|{address}|{birthDate}";
            File.AppendAllLines("users.txt", new[] { userData });
        }
    }
}
