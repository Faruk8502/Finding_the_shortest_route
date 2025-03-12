using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_the_shortest_route
{
    internal class Additional_functions
    {
        public static int Step_correct(int tag, string coordinate, string sign, int limit, Point point1, Point point2, List<Point> obstacles)
        {
            int additional = 1;
            Point point_clone = tag == 0 ? point1 : point2;
            if (coordinate == "Y")
            {
                Point potential_point = sign == "+" ? new Point(point_clone.X, point_clone.Y + additional) :
                    new Point(point_clone.X, point_clone.Y - additional);
                int max = sign == "+" ? limit - point_clone.Y : point_clone.Y;
                while (obstacles.Any(p => p == potential_point))
                {
                    additional += additional < max & max > 0 ? 1 : -additional;
                    potential_point.Y += sign == "+" ? 1 : -1;
                }
            }
            else
            {
                Point potential_point = sign == "+" ? new Point(point_clone.X + additional, point_clone.Y) :
                    new Point(point_clone.X - additional, point_clone.Y);
                int max = sign == "+" ? limit - point_clone.X : point_clone.X;
                while (obstacles.Any(p => p == potential_point))
                {
                    additional += additional < max & max > 0 ? 1 : -additional;
                    potential_point.X += sign == "+" ? 1 : -1;
                }
            }
            return additional;
        }

        public static Point Point_synchronization(Point point, int loc1, int loc2, int val1, int val2)
        {
            point.X = loc1 < loc2 ? val1 : val2;
            point.Y = loc1 < loc2 ? val2 : val1;
            return point;
        }
    }
}
