using System.Windows.Input;
using BowlingAppModel;

namespace BowlingAppViewModel
{
    public class BowlingAppViewModel
    {
        Line _line = new Line();

        public BowlingAppViewModel()
        {
            AddThrowCommand = new AddThrowCommand(_line);            
        }

        public ICommand AddThrowCommand { get; set; }

        public int ThrowCount => _line.Count;

        public Throw this[int index] => _line[index];
    }
}
