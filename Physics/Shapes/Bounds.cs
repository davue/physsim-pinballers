using System.Collections.Generic;

namespace Pinballers.Physics.Shapes
{
    public class Bounds : Shape
    {
        public IEnumerable<Line> Lines { get; }

        public Bounds(IEnumerable<Line> lines)
            => Lines = lines;
    }
}
