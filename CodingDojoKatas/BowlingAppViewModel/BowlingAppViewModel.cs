using System.Windows.Input;
using BowlingAppModel;

namespace BowlingAppViewModel
{
    public class BowlingAppViewModel
    {
        Line _line = new Line();

        public BowlingAppViewModel()
        {
            AddMissCommand = new AddMissCommand(_line);
            AddMissCommand = new AdOneCommand(_line);
        }

        public ICommand AddMissCommand { get; set; }
        public ICommand AddOneCommand { get; set; }

        public int ThrowCount
        {
            get => _line.Count;
        }
    }
}
