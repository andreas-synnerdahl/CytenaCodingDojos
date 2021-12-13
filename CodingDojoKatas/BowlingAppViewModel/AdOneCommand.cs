using System;
using System.Windows.Input;
using BowlingAppModel;

namespace BowlingAppViewModel
{
    public class AdOneCommand : ICommand
    {
        private readonly Line line;

        public AdOneCommand(Line line)
        {
            this.line = line;
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            line.Add(Throw.One);
        }

        public event EventHandler? CanExecuteChanged;
    }
}