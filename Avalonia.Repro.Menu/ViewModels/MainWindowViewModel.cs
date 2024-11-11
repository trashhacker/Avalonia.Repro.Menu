using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Avalonia.Repro.Menu.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IEnumerable<RelayCommand> Commands => commands;
        public string Command { get => command; set => this.RaiseAndSetIfChanged(ref command, value); }

        private readonly ObservableCollection<RelayCommand> commands = new ObservableCollection<RelayCommand>();
        private string command;

        public MainWindowViewModel()
        {
            commands.Add(new RelayCommand("test1", ExecuteTest1));
            commands.Add(new RelayCommand("test2", ExecuteTest2));
            commands.Add(new RelayCommand("test3", ExecuteTest3));
            commands.Add(new RelayCommand("test4", ExecuteTest4));
        }

        private void ExecuteTest4(object obj) => Command = "test4";
        private void ExecuteTest3(object obj) => command = "test3";
        private void ExecuteTest2(object obj) => command = "test2";
        private void ExecuteTest1(object obj) => command = "test1";
    }
}
