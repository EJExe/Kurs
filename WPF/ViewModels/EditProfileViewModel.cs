using System;
using System.ComponentModel;
using System.Windows;
using WPF.Models;

namespace WPF.ViewModels
{
    public class EditProfileViewModel : INotifyPropertyChanged
    {
        private UserClass currentUser;
        private DBAccess dbAccess;

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public EditProfileViewModel(UserClass user)
        {
            currentUser = user;
            dbAccess = new DBAccess();

            // Инициализация полей данными текущего пользователя
            FullName = user.Name;
            PhoneNumber = user.PhoneNumber;
        }

        public void ConfirmEdit()
        {
            // Логика редактирования профиля
            if (ValidateProfileDetails())
            {
                dbAccess.UpdateUserProfile(currentUser.PhoneNumber, FullName, PhoneNumber);
                MessageBox.Show("Profile updated successfully!");
            }
            else
            {
                MessageBox.Show("Invalid profile details or phone number already exists!");
            }
        }

        private bool ValidateProfileDetails()
        {
            // Простая валидация данных профиля
            return !string.IsNullOrEmpty(FullName) &&
                   !string.IsNullOrEmpty(PhoneNumber) &&
                   (PhoneNumber == currentUser.PhoneNumber || !dbAccess.IsPhoneNumberExists(PhoneNumber));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}