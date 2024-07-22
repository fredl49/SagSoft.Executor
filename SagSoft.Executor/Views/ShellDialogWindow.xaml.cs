using System.Windows.Controls;

using MahApps.Metro.Controls;

using SagSoft.Executor.Contracts.Views;
using SagSoft.Executor.ViewModels;

namespace SagSoft.Executor.Views;

public partial class ShellDialogWindow : MetroWindow, IShellDialogWindow
{
    public ShellDialogWindow(ShellDialogViewModel viewModel)
    {
        InitializeComponent();
        viewModel.SetResult = OnSetResult;
        DataContext = viewModel;
    }

    public Frame GetDialogFrame()
        => dialogFrame;

    private void OnSetResult(bool? result)
    {
        DialogResult = result;
        Close();
    }
}
