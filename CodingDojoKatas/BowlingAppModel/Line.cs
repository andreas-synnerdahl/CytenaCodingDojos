using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BowlingAppModel
{
    public class Line : IEnumerable<Frame>
    {
        private readonly Frame[] _frames;

        public Line()
        {
            _frames = Enumerable.Repeat(0, 10).Select(_ => new Frame()).ToArray();
        }

        public Frame this[int index]
        {
            get => _frames[index];
        }

        public IEnumerator<Frame> GetEnumerator() =>
            ((IEnumerable<Frame>)_frames).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
