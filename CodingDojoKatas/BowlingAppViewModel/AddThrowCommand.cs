using System;
using System.Windows.Input;
using BowlingAppModel;

namespace BowlingAppViewModel
{
    public class AddThrowCommand : ICommand
    {
        private readonly Line line;

        public AddThrowCommand(Line line)
        {
            this.line = line;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter is Throw;
        }

        public void Execute(object? parameter)
        {
            try
            {
                line.Add((Throw)parameter);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(parameter), ex);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}