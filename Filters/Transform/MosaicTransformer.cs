using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MosaicTransformer : ITransformer<EmptyParameters>
    {
        Size oldSize { get; set; }
        double angleInRadians { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = new Size(size.Width * 2, size.Height * 2);
        }

        public Point? MapPoint(Point newPoint)
        {
            throw new NotImplementedException();
        }

        public Point? MapPoint(Point point, int i)
        {
            var x = point.X;
            var y = point.Y;
            switch (i)
            {
                case 1:
                    x = ResultSize.Width - x;
                    break;
                case 2:
                    y = ResultSize.Height - y;
                    break;
                case 3:
                    x = ResultSize.Width - x;
                    y = ResultSize.Height - y;
                    break;
            }

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}