using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PasswordCheck;

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            PasswordCheck.PasswordCheck passwordCheck = new PasswordCheck.PasswordCheck();

            passwordCheck.Error += ErrorMessage;

            string password = input_Password.Password;
            bool checkLength = passwordCheck.CheckLength(password);
            bool checkSymbol = passwordCheck.CheckSymbol(password);
            bool checkAlphabet = passwordCheck.CheckAlphabet(password);

            if (checkLength && checkSymbol && checkAlphabet)
            {
                SuccessMessage("Всё OK");
            }
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            input_Login.Clear();
            input_Password.Clear();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите закрыть окно авторизации?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void input_Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (input_RepeatPassword.Password == "")
            {
                lable_Password_Check.Foreground = Brushes.Black;
                lable_Password_Check.Text = "";
            }
            else if (input_Password.Password != input_RepeatPassword.Password)
            {
                lable_Password_Check.Foreground = Brushes.Red;
                lable_Password_Check.Text = "Пароли не совпадают";
            }
            else if (input_Password.Password == input_RepeatPassword.Password)
            {
                lable_Password_Check.Foreground = Brushes.Green;
                lable_Password_Check.Text = "Пароли совпадают";
            }
        }

        private void ErrorMessage(string message)
        {
            lable_Password_Check.Foreground = Brushes.Red;
            lable_Password_Check.Text = message;
        }

        private void SuccessMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void input_RepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (input_RepeatPassword.Password == "")
            {
                lable_Password_Check.Foreground = Brushes.Black;
                lable_Password_Check.Text = "";
            }
            else if (input_Password.Password != input_RepeatPassword.Password)
            {
                lable_Password_Check.Foreground = Brushes.Red;
                lable_Password_Check.Text = "Пароли не совпадают";
            }
            else if (input_Password.Password == input_RepeatPassword.Password)
            {
                lable_Password_Check.Foreground = Brushes.Green;
                lable_Password_Check.Text = "Пароли совпадают";
            }
        }
    }
}
