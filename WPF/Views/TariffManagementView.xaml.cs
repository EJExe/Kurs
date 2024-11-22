using System.Windows;
using WPF.ViewModels;

namespace WPF.Views
{
    public partial class TariffManagementView : Window
    {
        public TariffManagementView()
        {
            InitializeComponent();
            DataContext = new TariffManagementViewModel();
        }
    }
}