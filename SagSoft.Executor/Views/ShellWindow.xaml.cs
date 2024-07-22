﻿using System.Windows.Controls;

using MahApps.Metro.Controls;

using SagSoft.Executor.Contracts.Views;
using SagSoft.Executor.ViewModels;

namespace SagSoft.Executor.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
        => shellFrame;

    public Frame GetRightPaneFrame()
        => rightPaneFrame;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();

    public SplitView GetSplitView()
        => splitView;
}
