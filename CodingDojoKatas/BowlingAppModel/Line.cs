using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BowlingAppModel
{
    public class Line : IEnumerable<Throw>
    {
        private readonly Dictionary<int,Throw> _throws;

        public Line()
        {
            _throws = new Dictionary<int, Throw>();
        }

        public int Count => _throws.Count;

        public Throw this[int index]
        {
            get
            {
                if (_throws.TryGetValue(index, out var value))
                    return value;
                return Throw.Miss;
            }
            set => _throws[index] = value;
        }

        public IEnumerator<Throw> GetEnumerator() =>
            _throws.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
