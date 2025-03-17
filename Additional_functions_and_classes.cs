using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_the_shortest_route
{
    internal class Additional_functions_and_classes
    {
        // Функция для корректировки текущего положения (после совершенного перемещения)
        public static Point Next_step_correct(Action_params _Params, List<Point> obstacles)
        {
            Point current_point = new Point(_Params.Current_point.X, _Params.Current_point.Y);
            Point which_obstacle = new Point(-1, -1);
            while (obstacles.Contains(current_point))
            {
                which_obstacle = obstacles.Where(p => p == current_point).FirstOrDefault();
                current_point = One_step(_Params, current_point);
                if (current_point == which_obstacle)
                {
                    current_point = new Point(-1, -1);
                    break;
                }
            }
            return current_point;
        }
        // Вызывается, пока потенциальная точка находиться на препятствии
        public static Point One_step(Action_params _Params, Point current_point)
        {
            if (_Params.Coordinate == 0)
            {
                current_point.X += _Params.Direction == 0 ? (current_point.X == 0 ? 0 : -1)
                        : (current_point.X == _Params.Maximum - 1 ? 0 : 1);
            }
            else
            {
                current_point.Y += _Params.Direction == 0 ? (current_point.Y == 0 ? 0 : -1)
                        : (current_point.Y == _Params.Maximum - 1 ? 0 : 1);
            }
            return current_point;
        }
    }
    public class PointModel : INotifyPropertyChanged
    {
        private int _x;
        private int _y;

        public int X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Action_params
    {
        public int Tag { get; set; } // 0 - Первая точка, 1 - Вторая точка
        public Point Current_point { get; set; }
        public int Direction { get; set; } // 1 - Вверх; 0 - вниз
        public int Coordinate { get; set; } // 1 - X, 2 - Y
        public int Maximum { get; set; }
    }
}
