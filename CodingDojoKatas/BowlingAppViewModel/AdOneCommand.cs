using System;
using System.Windows.Input;
using BowlingAppModel;

namespace BowlingAppViewModel
{
    public class AdOneCommand : ICommand
    {
        public AdOneCommand(Line line)
        {
            
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler? CanExecuteChanged;
    }
}