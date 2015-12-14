using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 象棋算法
{
    class Point
    {
        public int x;

        public int y;

        public Point(int a, int b)

        {

            x = a;

            y = b;

        }
        public static Point Point_multi(Point a, Point b)

        {

            int i = a.x * b.x;

            int j = a.y * b.y;

            Point point = new Point(i, j);

            return point;

        }

        public static Point Point_plus(Point a, Point b)

        {

            int i = a.x + b.x;

            int j = a.y + b.y;

            Point point = new Point(i, j);

            return point;

        }

        public static Point Point_divide(Point a, int b)

        {

            Point point = new Point(a.x / b, a.y / b);

            return point;

        }

        public static Point Point_reverse(Point a)
        {
            return new Point(8 - a.x, 9 - a.y);
        }
    }


}
