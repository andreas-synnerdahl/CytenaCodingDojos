using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BowlingAppModel
{
    public class Line : IEnumerable<Throw>
    {
        private readonly Throw[] _throws;        

        public Line()
        {
            _throws = new Throw[23];
        }

        public int Count { get; private set;  }

        public Throw this[int index] => _throws[index];

        public void Add(Throw value)
        {
            var index = Count;

            if (IsOdd(index))
            {
                var previous = _throws[index - 1];

                if ((int)value + (int)previous > 10)
                {
                    throw new InvalidOperationException("You are cheating!!!");
                }
            }

            _throws[index] = value;

            if (IsEven(index) && value == Throw.Ten)
            {
                Count = index + 2;
            }
            else
            {
                Count = index + 1;
            }

            static bool IsEven(int value) =>
                (value & 1) == 0;

            static bool IsOdd(int value) =>
                (value & 1) == 1;
        }

        public IEnumerator<Throw> GetEnumerator() =>
            _throws.Take(Count)
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

    }
}
