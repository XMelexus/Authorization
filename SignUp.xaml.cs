using System;
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
            //passwordCheck.Success += SuccessMessage;

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
            PasswordCheck.PasswordCheck passwordCheck = new PasswordCheck.PasswordCheck();
            string password = input_Password.Password;

            passwordCheck.Error += MessageLabel_CheckLength_Error;
            passwordCheck.Success += MessageLabel_CheckLength_Success;
            bool checkLength = passwordCheck.CheckLength(password);
            passwordCheck.Error -= MessageLabel_CheckLength_Error;
            passwordCheck.Success -= MessageLabel_CheckLength_Success;

            passwordCheck.Error += MessageLabel_CheckSymbols_Error;
            passwordCheck.Success += MessageLabel_CheckSymbols_Success;
            bool checkSymbols = passwordCheck.CheckSymbol(password);
            passwordCheck.Error -= MessageLabel_CheckSymbols_Error;
            passwordCheck.Success -= MessageLabel_CheckSymbols_Success;

            passwordCheck.Error += MessageLabel_CheckAlphabet_Error;
            passwordCheck.Success += MessageLabel_CheckAlphabet_Success;
            bool checkAlphabet = passwordCheck.CheckAlphabet(password);
            passwordCheck.Error -= MessageLabel_CheckAlphabet_Error;
            passwordCheck.Success -= MessageLabel_CheckAlphabet_Success;

            if (checkLength && checkSymbols && checkAlphabet)
            {
                input_RepeatPassword.IsEnabled = true;
            }
            else
            {
                input_RepeatPassword.IsEnabled = false;
            }
        }

        private void MessageLabel_CheckLength_Error(string message)
        {
            label_PasswordCheck_length.Foreground = Brushes.Red;
            label_PasswordCheck_length.Text = message;
        }

        private void MessageLabel_CheckLength_Success(string message)
        {
            label_PasswordCheck_length.Foreground = Brushes.Green;
            label_PasswordCheck_length.Text = message;
        }

        private void MessageLabel_CheckSymbols_Error(string message)
        {
            label_PasswordCheck_Symbols.Foreground = Brushes.Red;
            label_PasswordCheck_Symbols.Text = message;
        }

        private void MessageLabel_CheckSymbols_Success(string message)
        {
            label_PasswordCheck_Symbols.Foreground = Brushes.Green;
            label_PasswordCheck_Symbols.Text = message;
        }

        private void MessageLabel_CheckAlphabet_Error(string message)
        {
            label_PasswordCheck_Alphabet.Foreground = Brushes.Red;
            label_PasswordCheck_Alphabet.Text = message;
        }

        private void MessageLabel_CheckAlphabet_Success(string message)
        {
            label_PasswordCheck_Alphabet.Foreground = Brushes.Green;
            label_PasswordCheck_Alphabet.Text = message;
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SuccessMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void input_RepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = input_Password.Password;
            string passwordRepeat = input_RepeatPassword.Password;

            if (passwordRepeat == "")
            {
                label_PasswordCheck_Repeat.Text = "";
            }

            if (password == passwordRepeat)
            {
                label_PasswordCheck_Repeat.Foreground = Brushes.Green;
                label_PasswordCheck_Repeat.Text = "Пароли совпадают";
                button_SignUp.IsEnabled = true;
            }
            else
            {
                label_PasswordCheck_Repeat.Foreground = Brushes.Red;
                label_PasswordCheck_Repeat.Text = "Пароли не совпадают";
                button_SignUp.IsEnabled = false;
            }
        }
    }
}
