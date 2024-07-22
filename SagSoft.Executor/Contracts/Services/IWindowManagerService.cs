﻿using System.Windows;

namespace SagSoft.Executor.Contracts.Services;

public interface IWindowManagerService
{
    Window MainWindow { get; }

    void OpenInNewWindow(string pageKey, object parameter = null);

    bool? OpenInDialog(string pageKey, object parameter = null);

    Window GetWindow(string pageKey);
}
