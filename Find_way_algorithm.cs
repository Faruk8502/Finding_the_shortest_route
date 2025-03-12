using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_the_shortest_route
{
    internal class Find_way_algorithm
    {
        public static List<Point> FindPath(List<Point> obstacles, int GridSize, Point start, Point end)
        {
            // Открытый и закрытый списки
            var openSet = new List<Node>();
            var closedSet = new HashSet<Point>();

            // Начальная точка
            var startNode = new Node(start);
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                // Находим клетку с наименьшей стоимостью F
                var currentNode = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].F < currentNode.F)
                    {
                        currentNode = openSet[i];
                    }
                }

                // Если это конечная точка, восстанавливаем путь
                if (currentNode.Position == end)
                {
                    return ReconstructPath(currentNode);
                }

                // Перемещаем текущую клетку в закрытый список
                openSet.Remove(currentNode);
                closedSet.Add(currentNode.Position);

                // Исследуем соседние клетки
                foreach (var neighbor in GetNeighbors(currentNode.Position, GridSize))
                {
                    // Пропускаем препятствия и уже исследованные клетки
                    if (obstacles.Any(p => p == neighbor) || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    // Рассчитываем новую стоимость G
                    int tentativeG = currentNode.G + 1;

                    // Создаем новую клетку
                    var neighborNode = new Node(neighbor, currentNode)
                    {
                        G = tentativeG,
                        H = Heuristic(neighbor, end)
                    };

                    // Если клетка уже в открытом списке и новая стоимость хуже, пропускаем
                    var existingNode = openSet.Find(n => n.Position == neighbor);
                    if (existingNode != null && tentativeG >= existingNode.G)
                    {
                        continue;
                    }

                    // Добавляем клетку в открытый список
                    openSet.Add(neighborNode);
                }
            }
            return new List<Point>();
        }

        // Восстановление пути
        private static List<Point> ReconstructPath(Node node)
        {
            var path = new List<Point>();
            while (node != null)
            {
                path.Add(node.Position);
                node = node.Parent;
            }
            path.Reverse();
            return path;
        }
        // Получение соседних клеток
        private static IEnumerable<Point> GetNeighbors(Point position, int side)
        {
            var neighbors = new List<Point>();
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int x = position.X + dx[i];
                int y = position.Y + dy[i];

                if (x >= 0 && x < side && y >= 0 && y < side)
                {
                    neighbors.Add(new Point(x, y));
                }
            }

            return neighbors;
        }
        // Эвристическая функция (манхэттенское расстояние)
        private static int Heuristic(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
        class Node
        {
            public Point Position { get; set; }
            public Node Parent { get; set; }
            public int G { get; set; } // Стоимость от начала до этой клетки
            public int H { get; set; } // Эвристическая оценка до конечной точки
            public int F => G + H; // Общая стоимость

            public Node(Point position, Node parent = null)
            {
                Position = position;
                Parent = parent;
                G = 0;
                H = 0;
            }
        }
    }
}
