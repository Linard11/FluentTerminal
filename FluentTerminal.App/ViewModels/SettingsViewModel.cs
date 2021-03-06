﻿using FluentTerminal.App.Services;
using FluentTerminal.App.ViewModels.Settings;
using GalaSoft.MvvmLight;
using System;

namespace FluentTerminal.App.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(ISettingsService settingsService, IDefaultValueProvider defaultValueProvider, IDialogService dialogService, ITrayProcessCommunicationService trayProcessCommunicationService, IThemeParserFactory themeParserFactory)
        {
            KeyBindings = new KeyBindingsPageViewModel(settingsService, dialogService, defaultValueProvider, trayProcessCommunicationService);
            General = new GeneralPageViewModel(settingsService, dialogService, defaultValueProvider);
            Shell = new ProfilesPageViewModel(settingsService, dialogService, defaultValueProvider);
            Terminal = new TerminalPageViewModel(settingsService, dialogService, defaultValueProvider);
            Themes = new ThemesPageViewModel(settingsService, dialogService, defaultValueProvider, themeParserFactory);
        }

        public event EventHandler Closed;

        public GeneralPageViewModel General { get; }
        public KeyBindingsPageViewModel KeyBindings { get; }
        public ProfilesPageViewModel Shell { get; }
        public TerminalPageViewModel Terminal { get; }
        public ThemesPageViewModel Themes { get; }

        public void Close()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}