using System;
using System.Windows.Input;
using BowlingAppModel;

namespace BowlingAppViewModel
{
    public class AddMissCommand : ICommand
    {
        Line _line = new Line();

        public AddMissCommand(Line line)
        {
            _line = line;
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            _line.Add(Throw.Miss);
        }

        public event EventHandler? CanExecuteChanged;
    }
}