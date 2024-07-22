using System.Windows.Controls;

using MahApps.Metro.Controls;

namespace SagSoft.Executor.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();

    Frame GetRightPaneFrame();

    SplitView GetSplitView();
}
