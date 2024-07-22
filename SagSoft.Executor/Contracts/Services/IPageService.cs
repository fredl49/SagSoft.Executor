﻿using System.Windows.Controls;

namespace SagSoft.Executor.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
