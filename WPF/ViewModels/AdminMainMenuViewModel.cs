using System.ComponentModel;
using System.Windows;
using WPF.Models;
using WPF.Views;

namespace WPF.ViewModels
{
    public class AdminMainMenuViewModel : INotifyPropertyChanged
    {
        public AdminMainMenuView currentwindow;
        private UserClass currentUser;
        public UserClass CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public AdminMainMenuViewModel(UserClass user)
        {
            CurrentUser = user;
            LogoutCommand = new Command(obj => Logout(currentwindow));
            OpenTariffsCommand = new Command(obj => OpenTariffs(currentwindow));
            OpenUsersCommand = new Command(obj => OpenUsers(currentwindow));
        }

        public Command LogoutCommand { get; set; }
        public Command OpenTariffsCommand { get; set; }
        public Command OpenUsersCommand { get; set; }

        private void Logout(Window mainWindow)
        {
            MainWindow authorizationWindow = new MainWindow();
            authorizationWindow.Show(); // Открываем окно авторизации
            currentwindow.Close(); // Закрываем текущее окно
        }

        private void OpenTariffs(Window mainWindow)
        {
            TariffManagementView tariffManagementView = new TariffManagementView();
            tariffManagementView.ShowDialog();
        }

        private void OpenUsers(Window mainWindow)
        {
            UserManagementView userManagementView = new UserManagementView();
            userManagementView.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}