using System.Windows;
using WPF.ViewModels;

namespace WPF.Views
{
    public partial class UserManagementView : Window
    {
        public UserManagementView()
        {
            InitializeComponent();
            DataContext = new UserManagementViewModel();
        }
    }
}