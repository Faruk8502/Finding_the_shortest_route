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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static Finding_the_shortest_route.Find_way_algorithm;
using static Finding_the_shortest_route.Additional_functions_and_classes;
using static Finding_the_shortest_route.Action_params;
using System.Security.Policy;

namespace Finding_the_shortest_route
{
    public partial class Window : Form
    {
        // Глобальные переменные 
        int score = 0;
        Point point1 = new Point();
        Point point2 = new Point();
        List<Point> obstacles = new List<Point>();
        List<Point> way = new List<Point>();
        PointModel start_point = new PointModel();
        PointModel end_point = new PointModel();
        int Direction = 0;

        // Модуль инициализации
        public Window()
        {
            InitializeComponent();
            // Связываем изменение координат с обновлением таблицы
            start_point.PropertyChanged += PointModel_PropertyChanged;
            end_point.PropertyChanged += PointModel_PropertyChanged;
            //__________________________________________________________________
            // Осуществляем привязку координат точек со значениями в полях
            NumUpDwn_p1_x.DataBindings.Add("Value", start_point, "X", true, DataSourceUpdateMode.OnPropertyChanged);
            NumUpDwn_p1_y.DataBindings.Add("Value", start_point, "Y", true, DataSourceUpdateMode.OnPropertyChanged);
            NumUpDwn_p2_x.DataBindings.Add("Value", end_point, "X", true, DataSourceUpdateMode.OnPropertyChanged);
            NumUpDwn_p2_y.DataBindings.Add("Value", end_point, "Y", true, DataSourceUpdateMode.OnPropertyChanged);

            //__________________________________________________________________
            this.DoubleBuffered = true;
            this.ClientSize = new Size(625, 625);
            NumUpDwn_p1_x.MouseWheel += Ctl_MouseWheel;
            NumUpDwn_p1_y.MouseWheel += Ctl_MouseWheel;
            NumUpDwn_p2_x.MouseWheel += Ctl_MouseWheel;
            NumUpDwn_p2_y.MouseWheel += Ctl_MouseWheel;

            // Удаление полей с Up/Down кнопками для элементов NumericUpDown
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
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.Controls.Add(tableLayoutPanel1);

            SquareGrid.Width = 500;
            SquareGrid.Height = 500;
            SquareGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            SquareGrid.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(SquareGrid, 0, 0);

            panel2.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.SetColumnSpan(panel2, 2);

            panel3.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);

        }
        // Обработчик события изменения координат
        private void PointModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Вызываем функцию обновления сетки
            Grid_update();
        }
        // Обработчик нажатия на клавиши джойстиков
        private void Joystick_Button_Click(object sender, EventArgs e)
        {
            // Собираем данные для создания экземпляра класса с информацией о текущей точке
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Control parent = button.Parent;
            NumericUpDown numericUpDown = new NumericUpDown();
            foreach (Control control in parent.Controls)
            {
                if(control is NumericUpDown && control.Name.Contains(button.Tag.ToString()))
                {
                    numericUpDown = control as NumericUpDown;
                }
            }
            // Определяем направление для предоставления информации обработчику изменения значения
            Direction = button.Name.Contains("Up") || button.Name.Contains("Left") ? 2 : 1;

            // Совершаем подразумевающийся шаг
            numericUpDown.Value += Direction == 2 ? (numericUpDown.Value > 0? - 1 : 0) :
                                                    (numericUpDown.Value < numericUpDown.Maximum? 1 : 0);
        }
        // Обработчик изменения значений в полях с координатами за счёт стрелок вверх/вниз либо
        // вводом значения вручную
        private void NumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                // Определяем направление для предоставления информации обработчику изменения значения
                if (e.KeyCode == Keys.Up)
                {
                    Direction = 1;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    Direction = 2;
                }
            }
            else
            {
                // Остановка дальнейшей обработки события нажатия с целью предотвращения звукового сопровождения
                e.SuppressKeyPress = true;

                // Определяем в какое поле пользователь ввёл значение координаты,
                // чтобы перевести фокус на другое поле
                // Для этого получаем экземпляр текущего и экземпляр "другого" элемента NumericUpDown
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
                // Анализируем потенциальное перемещение точки по введённым пользователем значениям
                // Если точка встанет на препятствие - возвращаем исходную координату
                if (Convert.ToInt16(numericUpDown2.Tag) > 0)
                {
                    numericUpDown2.Tag = "0";
                    // Определяем направление для предоставления информации обработчику изменения значения
                    Direction = 1;
                    this.ActiveControl = null;
                }
                else
                {
                    // Определяем направление для предоставления информации обработчику изменения значения
                    Direction = 1;
                    numericUpDown1.Tag = "1";
                    numericUpDown2.Focus();
                }
            }
        }
        // Обработчик изменения значений координат в полях
        private void NumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            if (Direction == 0)
            {
                return;
            }
            //Очищаем найденный путь и вывод результата поиска
            Label_result.Text = null;
            way.Clear();

            // Собираем необходимую информацию для создания экземпляра класса с информацией о текущей точке
            NumericUpDown numericUpDown = sender as NumericUpDown;
            Control parent = numericUpDown.Parent;
            int tag = Convert.ToInt16(parent.Tag);
            int coordinate = numericUpDown.Name.ToString().Contains("x") ? 0 : 1;
            int direction = Direction == 1 ? 1 : 0;
            (int X, int Y) = tag == 0 ? ((int)NumUpDwn_p1_x.Value, (int)NumUpDwn_p1_y.Value) :
                ((int)NumUpDwn_p2_x.Value, (int)NumUpDwn_p2_y.Value);
            Point new_point = new Point(X, Y);

            // Создаём экземпляр класса с информацией о текущей точке
            Action_params _Params = new Action_params()
            {
                Tag = tag,
                Coordinate = coordinate,
                Direction = direction,
                Current_point = new_point,
                Maximum = (int)NumUpDwn_GridSize.Value
            };

            // Корректируем шаг
            Point corrected_point = Next_step_correct(_Params, obstacles);

            numericUpDown.Value = coordinate == 0 ?
                (corrected_point.X != -1 ? corrected_point.X :
                                    (Direction == 1 ? numericUpDown.Value - 1 :
                                                      numericUpDown.Value + 1)) :
                corrected_point.Y != -1 ? corrected_point.Y :
                                    (Direction == 1 ? numericUpDown.Value - 1 :
                                                      numericUpDown.Value + 1);
            Direction = 0;
        }
        // Обработчик изменения значения размера сетки
        private void NumUpDwn_GridSize_ValueChanged(object sender, EventArgs e)
        {
            Grid_update();
        }
        //Обработчик изменения значения размера сетки и количества препятствий вручную
        private void NumUpDwn_GridSize_Obs_KeyDown(object sender, KeyEventArgs e)
        {
            // Остановка дальнейшей обработки при нажатии клавиши Enter в элементах NumericUpDown
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        // Модуль для отрисовки препятствий
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

                Point point1 = new Point(start_point.X, start_point.Y);
                Point point2 = new Point(end_point.X, end_point.Y);

                // Проверка, что координаты не совпадают с начальной и конечной точками
                if (point != point1 && point != point2 && !obstacles.Any(p => p == point))
                {
                    obstacles.Add(point); // Добавляем препятствие
                }
            }
            Label_result.Text = null;
            // Обновляем сетку
            Grid_update();
        }
        // вызов алгоритма для поиска кратчайшего пути
        private void Find_way_Button_Click(object sender, EventArgs e)
        {
            int GridSize = Convert.ToInt16(NumUpDwn_GridSize.Value) == 0 ? 1 :
                Convert.ToInt16(NumUpDwn_GridSize.Value);
            Point point1 = new Point(start_point.X, start_point.Y);
            Point point2 = new Point(end_point.X, end_point.Y);
            way = FindPath(obstacles, GridSize, point1, point2);
            (Label_result.Text, Label_result.ForeColor) = way.Count() == 0 ? ("Путь не найден", Color.Tomato) : ("Путь найден!", Color.Green);
            Grid_update();
        }
        // Обработчик нажатия клавиши для очистки поля
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Clear_Data();
        }
        // Модуль обновления сетки
        public void Grid_update()
        {
            Graphics g = SquareGrid.CreateGraphics();
            g.Clear(Color.LightGray); //Очищаем сетку указывая цвет фона
            Pen pen = new Pen(Color.Black); // Используем черный цвет для линий сетки

            int GridSize = Convert.ToInt16(NumUpDwn_GridSize.Value) == 0 ? 1 :
                Convert.ToInt16(NumUpDwn_GridSize.Value);

            // Корректируем максимальное количество препятствий с учётом текущего размера сетки и
            // предела, указанного в ТЗ
            NumUpDwn_ObsNum.Maximum = GridSize <= Math.Sqrt(2000) ? GridSize * GridSize - 2 : 2000;

            // Адаптируем максимумы ползунков под текущий размер сетки
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

            Brush brush = new SolidBrush(Color.Red); // красный цвет для препятствий

            foreach (var obstacle in obstacles)
            {
                float x = obstacle.X * cellSize;
                float y = obstacle.Y * cellSize;
                g.FillRectangle(brush, x + 1, y + 1, cellSize, cellSize);
            }

            brush = new SolidBrush(Color.Yellow); // жёлтый цвет для найденного пути
            foreach (var cell in way)
            {
                float x = cell.X * cellSize;
                float y = cell.Y * cellSize;
                g.FillRectangle(brush, x + 1, y + 1, cellSize, cellSize);
            }

            brush = new SolidBrush(Color.White);

            g.FillEllipse(brush, start_point.X * cellSize, start_point.Y * cellSize, cellSize, cellSize);

            Pen pen1 = new Pen(Color.Black);
            g.DrawEllipse(pen1, start_point.X * cellSize, start_point.Y * cellSize, cellSize, cellSize);

            brush = new SolidBrush(Color.Black);

            g.FillEllipse(brush, end_point.X * cellSize, end_point.Y * cellSize, cellSize, cellSize);
        }
        // Обновление таблицы при загрузке формы
        private void Form1_Shown(object sender, EventArgs e)
        {
            Clear_Data();
        }
        // Модуль для очистки поля
        private void Clear_Data()
        {
            obstacles.Clear();
            way.Clear();

            NumUpDwn_p1_x.Minimum = -1;
            NumUpDwn_p1_y.Minimum = -1;
            NumUpDwn_p2_x.Minimum = -1;
            NumUpDwn_p2_y.Minimum = -1;

            // Устанавливаем отрицательные значения координат, дабы скрыть точки
            NumUpDwn_p1_x.Value = -1;
            NumUpDwn_p1_y.Value = -1;
            NumUpDwn_p2_x.Value = -1;
            NumUpDwn_p2_y.Value = -1;

            NumUpDwn_ObsNum.Value = 0;
            Label_result.Text = null;

            // Обновляем сетку
            Grid_update();
            // Устанавливаем соответствующую этапу работы программы кондицию
            Points_manegment_lock(3);
        }
        private void Ctl_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        // Модуль для перехода в разные этапы работы программы
        private void Points_manegment_lock(int cond)
        {
            if (cond == 1)
            {
                // Данная кондиция соответствует добавлению первой точки
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
                obstacles.Clear();
                Grid_update();
            }
            else if (cond == 2)
            {
                // Данная кондиция соответствует добавлению второй точки
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
                Btn_p2_lock.Visible = false;
                NumUpDwn_p2_x.Value = point2.X = (int)NumUpDwn_p2_x.Maximum;
                NumUpDwn_p2_y.Value = point2.Y = (int)NumUpDwn_p2_x.Maximum;
                obstacles.Clear();
                Grid_update();
            }
            else if (cond == 3)
            {
                // Данная кондиция соответствует очистке поля
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
        // Обработчик нажатия на кнопки для добавления точек
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
