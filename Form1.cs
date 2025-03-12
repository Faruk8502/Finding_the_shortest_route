using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static Finding_the_shortest_route.Find_way_algorithm;

namespace Finding_the_shortest_route
{
    public partial class Form1 : Form
    {
        // Глобальные переменные 
        int score = 0;
        Point point1 = new Point(-1, -1);
        Point point2 = new Point(-1, -1);
        List<Point> obstacles = new List<Point>();
        List<Point> way = new List<Point>();

        // Модуль инициализации
        public Form1()
        {
            InitializeComponent();
            Clear_Data();
            this.ClientSize = new Size(800, 700);

            SquareGrid.Width = 500;
            SquareGrid.Height = 500;
            SquareGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            NumUpDwn_p1_x.Minimum = -1;
            NumUpDwn_p1_y.Minimum = -1;
            NumUpDwn_p2_x.Minimum = -1;
            NumUpDwn_p2_y.Minimum = -1;

            // Удаление полей с Up/Down кнопаками для элементов NumericUpDown
            int widthOfSpinButtons = NumUpDwn_p1_x.Controls[0].Width;
            NumUpDwn_p1_x.Controls[0].Dispose();
            NumUpDwn_p1_x.Controls[0].MinimumSize = new Size(NumUpDwn_p1_x.Controls[0].Width + 
                widthOfSpinButtons, NumUpDwn_p1_x.Controls[0].MinimumSize.Height);
            NumUpDwn_p1_y.Controls[0].Dispose();
            NumUpDwn_p1_y.Controls[0].MinimumSize = new Size(NumUpDwn_p1_y.Controls[0].Width +
                widthOfSpinButtons, NumUpDwn_p1_y.Controls[0].MinimumSize.Height);
            NumUpDwn_p2_x.Controls[0].Dispose();
            NumUpDwn_p2_x.Controls[0].MinimumSize = new Size(NumUpDwn_p2_x.Controls[0].Width +
                widthOfSpinButtons, NumUpDwn_p2_x.Controls[0].MinimumSize.Height);
            NumUpDwn_p2_y.Controls[0].Dispose();
            NumUpDwn_p2_y.Controls[0].MinimumSize = new Size(NumUpDwn_p2_y.Controls[0].Width +
                widthOfSpinButtons, NumUpDwn_p2_y.Controls[0].MinimumSize.Height);

            // Настройка интерфейса
            panel1.Dock = DockStyle.Top;
            panel2.Dock = DockStyle.Fill;
            panel1.Width = this.ClientSize.Width;
            panel1.Height = (int)(2.25 * this.ClientSize.Height / 3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Dock = DockStyle.Fill;
            panel2.Width = this.ClientSize.Width;
            panel2.Height = (int)(0.75 * this.ClientSize.Height / 3);
        }

        // Модуль обновления сетки
        public void Grid_update()
        {
            Graphics g = SquareGrid.CreateGraphics();
            g.Clear(Color.LightGray); //Очищаем сетку указывая цвет фона
            Pen pen = new Pen(Color.Black); // Используем черный цвет для линий сетки

            int GridSize = Convert.ToInt16(NumUpDwn_GridSize.Value) == 0 ? 1 :
                Convert.ToInt16(NumUpDwn_GridSize.Value);
            NumUpDwn_ObsNum.Maximum = GridSize <= Math.Sqrt(2000) ? GridSize * GridSize - 2 : 2000;
            NumUpDwn_p1_x.Maximum = GridSize - 1;
            NumUpDwn_p1_y.Maximum = GridSize - 1;
            NumUpDwn_p2_x.Maximum = GridSize - 1;
            NumUpDwn_p2_y.Maximum = GridSize - 1;
            float cellSize = (float)(SquareGrid.Width - pen.Width) / GridSize;

            // Рисуем вертикальные и горизонтальные линии
            for (int i = 0; i <= GridSize; i++)
            {
                float param = i * cellSize;
                g.DrawLine(pen, param, 0, param, GridSize * cellSize);
                g.DrawLine(pen, 0, param, GridSize * cellSize, param);
            }

            Brush brush = new SolidBrush(Color.Red); // Используем красный цвет для препятствий

            foreach (var obstacle in obstacles)
            {
                float x = obstacle.X * cellSize;
                float y = obstacle.Y * cellSize;
                g.FillRectangle(brush, x + 1, y + 1, cellSize, cellSize);
            }

            brush = new SolidBrush(Color.Yellow); // Используем жёлтый цвет для найденного пути
            foreach (var cell in way)
            {
                float x = cell.X * cellSize;
                float y = cell.Y * cellSize;
                g.FillRectangle(brush, x + 1, y + 1, cellSize, cellSize);
            }

            brush = new SolidBrush(Color.Green); // Зеленый цвет для начальной точки

            g.FillEllipse(brush, point1.X * cellSize, point1.Y * cellSize, cellSize, cellSize);

            brush = new SolidBrush(Color.Blue);   // Синий цвет для конечной точки

            g.FillEllipse(brush, point2.X * cellSize, point2.Y * cellSize, cellSize, cellSize);
        }
        private void NumUpDwn_GridSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        private void NumUpDwn_GridSize_ValueChanged(object sender, EventArgs e)
        {
            //SquareGrid.Invalidate();
            if (point1.X > NumUpDwn_p1_x.Maximum || point1.Y > NumUpDwn_p1_y.Maximum)
            {
                point1.X = 0;
                point1.Y = 0;
            }
            if (point2.X > NumUpDwn_p2_x.Maximum || point2.Y > NumUpDwn_p2_y.Maximum)
            {
                point2.X = 0;
                point2.Y = 0;
            }
            Grid_update();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Control parent = button.Parent;
            int tag = Convert.ToInt16(parent.Tag);
            NumericUpDown numericUpDown1 = new NumericUpDown();
            NumericUpDown numericUpDown2 = new NumericUpDown();
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown & control.Name.Contains("x"))
                {
                    numericUpDown1 = control as NumericUpDown;
                }
                else if(control is NumericUpDown & control.Name.Contains("y"))
                {
                    numericUpDown2 = control as NumericUpDown;
                }

            }
            switch (button.Name)
            {
                case string s when s.Contains("Up"):
                    numericUpDown2.Value -= numericUpDown2.Value != numericUpDown2.Minimum? 
                        Step_correct(tag, "Y", "-", 0) : 0;
                    break;
                case string s when s.Contains("Down"):
                    numericUpDown2.Value += numericUpDown2.Value != numericUpDown2.Maximum?
                        Step_correct(tag, "Y", "+", (int)numericUpDown2.Maximum) : 0;
                    break;
                case string s when s.Contains("Left"):
                    numericUpDown1.Value -= numericUpDown1.Value != numericUpDown2.Minimum?
                        Step_correct(tag, "X", "-", 0) : 0;
                    break;
                case string s when s.Contains("Right"):
                    numericUpDown1.Value += numericUpDown1.Value != numericUpDown2.Maximum?
                        Step_correct(tag, "X", "+", (int)numericUpDown1.Maximum) : 0;
                    break;
            }
        }
        private int Step_correct(int tag, string coordinate, string sign, int limit)
        {
            int additional = 1;
            Point point_clone = tag == 0 ? point1 : point2;
            if (coordinate == "Y")
            {
                Point potential_point = sign == "+" ? new Point(point_clone.X, point_clone.Y + additional) :
                    new Point(point_clone.X, point_clone.Y - additional);
                int max = sign == "+" ? limit - point_clone.Y: point_clone.Y;
                while (obstacles.Any(p => p == potential_point))
                {
                    additional += additional < max & max > 0? 1 : -additional;
                    potential_point.Y += sign == "+" ? 1 : -1;
                }
            }
            else
            {
                Point potential_point = sign == "+" ? new Point(point_clone.X + additional, point_clone.Y) :
                    new Point(point_clone.X - additional, point_clone.Y);
                int max = sign == "+" ? limit - point_clone.X: point_clone.X;
                while (obstacles.Any(p => p == potential_point))
                {
                    additional += additional < max & max > 0 ? 1 : -additional;
                    potential_point.X += sign == "+" ? 1 : -1;
                }
            }
            return additional;
        }
        private void NumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown1 = (NumericUpDown)sender;
            NumericUpDown numericUpDown2 = new NumericUpDown();
            Control parent = numericUpDown1.Parent;
            foreach (Control control in parent.Controls)
            {
                if (control != numericUpDown1 & control is NumericUpDown)
                {
                    numericUpDown2 = control as NumericUpDown;
                }

            }
            int tag = Convert.ToInt16(parent.Tag);
            int location1 = numericUpDown1.Location.Y;
            int location2 = numericUpDown2.Location.Y;
            int value1 = (int)numericUpDown1.Value;
            int value2 = (int)numericUpDown2.Value;
            if (tag == 0)
            {
                point1 = Point_synchronization(point1, location1, location2, value1, value2);
            }
            else
            {
                point2 = Point_synchronization(point2, location1, location2, value1, value2);
            }
            Label_result.Text = null;
            way.Clear();
            Grid_update();
        }
        private Point Point_synchronization(Point point, int loc1,int loc2, int val1, int val2)
        {
            point.X = loc1 < loc2 ? val1 : val2;
            point.Y = loc1 < loc2 ? val2 : val1;
            return point;
        }
        private void NumUpDwn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            else
            {
                e.SuppressKeyPress = true;
                NumericUpDown numericUpDown1 = (NumericUpDown)sender;
                if (numericUpDown1.Value != -1)
                {
                    Change_focus(sender, numericUpDown1);
                }
            }
        }
        public void Change_focus(object sender, NumericUpDown numericUpDown1)
        {
            NumericUpDown numericUpDown2 = new NumericUpDown();
            Control parent = numericUpDown1.Parent;
            foreach (Control control in parent.Controls)
            {
                if (control != numericUpDown1 & control is NumericUpDown)
                {
                    numericUpDown2 = control as NumericUpDown;
                }

            }
            if (Convert.ToInt16(numericUpDown2.Tag) > 0)
            {
                numericUpDown2.Tag = "0";
                this.ActiveControl = null;
            }
            else
            {
                numericUpDown1.Tag = "1";
                numericUpDown2.Focus();
            }
        }
        public void DrawObstacles(object sender, EventArgs e)
        {
            way.Clear();
            obstacles.Clear();
            Random random = new Random();
            int obstacleCount = (int)NumUpDwn_ObsNum.Value;
            int GridSize = Convert.ToInt16(NumUpDwn_GridSize.Value) == 0 ? 1 :
                Convert.ToInt16(NumUpDwn_GridSize.Value);
            while (obstacles.Count < obstacleCount)
            {
                // Генерация случайных координат
                int x = random.Next(GridSize);
                int y = random.Next(GridSize);
                Point point = new Point(x, y);

                // Проверка, что координаты не совпадают с начальной и конечной точками
                if (point != point1 && point != point2 && !obstacles.Any(p=>p==point))
                {
                    obstacles.Add(point); // Добавляем препятствие
                }
            }
            Label_result.Text = null;
            Grid_update();
        }
        private void Find_way_Button_Click(object sender, EventArgs e)
        {
            int GridSize = Convert.ToInt16(NumUpDwn_GridSize.Value) == 0 ? 1 :
                Convert.ToInt16(NumUpDwn_GridSize.Value);
            way = FindPath(obstacles, GridSize, point1, point2);
            (Label_result.Text, Label_result.ForeColor) = way.Count() == 0 ? ("Путь не найден", Color.Tomato) : ("Путь найден!", Color.Green);
            Grid_update();
        }
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Clear_Data();
        }
        private void Clear_Data()
        {
            obstacles.Clear();
            way.Clear();
            point1.X = -1;
            point1.Y = -1;
            point2.X = -1;
            point2.Y = -1;
            NumUpDwn_p1_x.Value = -1;
            NumUpDwn_p1_y.Value = -1;
            NumUpDwn_p2_x.Value = -1;
            NumUpDwn_p2_y.Value = -1;
            NumUpDwn_ObsNum.Value = 0;
            Label_result.Text = null;
            Grid_update();
            Points_manegment_lock(3);
        }
        private void Points_manegment_lock(int cond)
        {
            if (cond == 1)
            {
                Btn_Up_1.Visible = true;
                Btn_Down_1.Visible = true;
                Btn_Left_1.Visible = true;
                Btn_Right_1.Visible = true;

                Label_P1_x.Visible = true;
                Label_P1_y.Visible = true;
                NumUpDwn_p1_x.Visible = true;
                NumUpDwn_p1_y.Visible = true;
                NumUpDwn_p1_x.Minimum = 0;
                NumUpDwn_p1_y.Minimum = 0;
                Btn_p1_lock.Visible = false;
                NumUpDwn_p1_x.Value = 0;
                point1.X = 0;
                NumUpDwn_p1_y.Value = 0;
                point1.Y = 0;
                Grid_update();
            }
            else if(cond == 2)
            {
                Btn_Up_2.Visible = true;
                Btn_Down_2.Visible = true;
                Btn_Left_2.Visible = true;
                Btn_Right_2.Visible = true;

                Label_P2_x.Visible = true;
                Label_P2_y.Visible = true;
                NumUpDwn_p2_x.Visible = true;
                NumUpDwn_p2_y.Visible = true;
                NumUpDwn_p2_x.Minimum = 0;
                NumUpDwn_p2_y.Minimum = 0;
                Btn_p2_lock.Visible=false;
                NumUpDwn_p2_x.Value = 0;
                point2.X = 0;
                NumUpDwn_p2_y.Value = 0;
                point2.Y = 0;
                Grid_update();
            }
            else if(cond == 3)
            {
                Btn_Up_1.Visible = false;
                Btn_Down_1.Visible = false;
                Btn_Left_1.Visible = false;
                Btn_Right_1.Visible = false;

                Btn_Up_2.Visible = false;
                Btn_Down_2.Visible = false;
                Btn_Left_2.Visible = false;
                Btn_Right_2.Visible = false;

                Label_P1_x.Visible = false;
                Label_P1_y.Visible = false;
                Label_P2_x.Visible = false;
                Label_P2_y.Visible = false;
                NumUpDwn_p1_x.Visible = false;
                NumUpDwn_p1_y.Visible = false;
                NumUpDwn_p2_x.Visible = false;
                NumUpDwn_p2_y.Visible = false;
                Btn_p1_lock.Visible = true;
                Btn_p2_lock.Visible = true;
            }

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Grid_update();
        }

        private void Btn_lock_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            if (button.Name == "Btn_p1_lock")
            {
                Points_manegment_lock(1);
            }
            else
            {
                Points_manegment_lock(2);
            }
        }
    }
}
