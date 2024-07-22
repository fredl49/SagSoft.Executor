using System.Windows.Controls;

using SagSoft.Executor.ViewModels;

namespace SagSoft.Executor.Views;

public partial class InstallerPage : Page
{
    public InstallerPage(InstallerViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
