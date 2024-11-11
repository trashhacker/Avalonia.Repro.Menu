using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Avalonia.Repro.Menu.ViewModels
{
    public class RelayCommand: ReactiveObject, ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public string Name { get; }

        private ICommand command;
        public RelayCommand(string name, Action<object> action)
        {
            Name = name;
            command = ReactiveCommand.Create(action);
            command.CanExecuteChanged += CommandCanExecuteChanged;
        }

        private void CommandCanExecuteChanged(object? sender, EventArgs e) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object? parameter) => command.CanExecute(parameter);
        public void Execute(object? parameter) => command.Execute(parameter);
    }
}
