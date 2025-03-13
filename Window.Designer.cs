namespace Finding_the_shortest_route
{
    partial class Window
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SquareGrid = new System.Windows.Forms.Panel();
            this.NumUpDwn_GridSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Right_1 = new System.Windows.Forms.Button();
            this.Btn_Left_1 = new System.Windows.Forms.Button();
            this.Btn_Down_1 = new System.Windows.Forms.Button();
            this.Btn_Up_1 = new System.Windows.Forms.Button();
            this.NumUpDwn_p1_y = new System.Windows.Forms.NumericUpDown();
            this.NumUpDwn_p1_x = new System.Windows.Forms.NumericUpDown();
            this.Label_P1_y = new System.Windows.Forms.Label();
            this.Label_P1_x = new System.Windows.Forms.Label();
            this.Btn_p1_lock = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_Right_2 = new System.Windows.Forms.Button();
            this.Btn_Left_2 = new System.Windows.Forms.Button();
            this.NumUpDwn_p2_y = new System.Windows.Forms.NumericUpDown();
            this.Btn_Down_2 = new System.Windows.Forms.Button();
            this.NumUpDwn_p2_x = new System.Windows.Forms.NumericUpDown();
            this.Btn_Up_2 = new System.Windows.Forms.Button();
            this.Label_P2_x = new System.Windows.Forms.Label();
            this.Label_P2_y = new System.Windows.Forms.Label();
            this.Btn_p2_lock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NumUpDwn_ObsNum = new System.Windows.Forms.NumericUpDown();
            this.Find_way_Button = new System.Windows.Forms.Button();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.Label_result = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_GridSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p1_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p1_x)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p2_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p2_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_ObsNum)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SquareGrid
            // 
            this.SquareGrid.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SquareGrid.Location = new System.Drawing.Point(16, 12);
            this.SquareGrid.Name = "SquareGrid";
            this.SquareGrid.Size = new System.Drawing.Size(392, 361);
            this.SquareGrid.TabIndex = 0;
            // 
            // NumUpDwn_GridSize
            // 
            this.NumUpDwn_GridSize.Location = new System.Drawing.Point(97, 15);
            this.NumUpDwn_GridSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumUpDwn_GridSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUpDwn_GridSize.Name = "NumUpDwn_GridSize";
            this.NumUpDwn_GridSize.Size = new System.Drawing.Size(62, 22);
            this.NumUpDwn_GridSize.TabIndex = 1;
            this.NumUpDwn_GridSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUpDwn_GridSize.ValueChanged += new System.EventHandler(this.NumUpDwn_GridSize_ValueChanged);
            this.NumUpDwn_GridSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumUpDwn_GridSize_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сторона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "квадратов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Right_1);
            this.groupBox1.Controls.Add(this.Btn_Left_1);
            this.groupBox1.Controls.Add(this.Btn_Down_1);
            this.groupBox1.Controls.Add(this.Btn_Up_1);
            this.groupBox1.Controls.Add(this.NumUpDwn_p1_y);
            this.groupBox1.Controls.Add(this.NumUpDwn_p1_x);
            this.groupBox1.Controls.Add(this.Label_P1_y);
            this.groupBox1.Controls.Add(this.Label_P1_x);
            this.groupBox1.Controls.Add(this.Btn_p1_lock);
            this.groupBox1.Location = new System.Drawing.Point(31, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "0";
            this.groupBox1.Text = "Первая точка";
            // 
            // Btn_Right_1
            // 
            this.Btn_Right_1.Location = new System.Drawing.Point(132, 30);
            this.Btn_Right_1.Name = "Btn_Right_1";
            this.Btn_Right_1.Size = new System.Drawing.Size(23, 23);
            this.Btn_Right_1.TabIndex = 15;
            this.Btn_Right_1.Text = "▶";
            this.Btn_Right_1.UseVisualStyleBackColor = true;
            this.Btn_Right_1.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Left_1
            // 
            this.Btn_Left_1.Location = new System.Drawing.Point(86, 30);
            this.Btn_Left_1.Name = "Btn_Left_1";
            this.Btn_Left_1.Size = new System.Drawing.Size(23, 23);
            this.Btn_Left_1.TabIndex = 15;
            this.Btn_Left_1.Text = "◀";
            this.Btn_Left_1.UseVisualStyleBackColor = true;
            this.Btn_Left_1.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Down_1
            // 
            this.Btn_Down_1.Location = new System.Drawing.Point(109, 42);
            this.Btn_Down_1.Name = "Btn_Down_1";
            this.Btn_Down_1.Size = new System.Drawing.Size(23, 23);
            this.Btn_Down_1.TabIndex = 15;
            this.Btn_Down_1.Text = "▼";
            this.Btn_Down_1.UseVisualStyleBackColor = true;
            this.Btn_Down_1.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Up_1
            // 
            this.Btn_Up_1.Location = new System.Drawing.Point(109, 22);
            this.Btn_Up_1.Name = "Btn_Up_1";
            this.Btn_Up_1.Size = new System.Drawing.Size(23, 23);
            this.Btn_Up_1.TabIndex = 14;
            this.Btn_Up_1.Text = "▲";
            this.Btn_Up_1.UseVisualStyleBackColor = true;
            this.Btn_Up_1.Click += new System.EventHandler(this.Btn_Click);
            // 
            // NumUpDwn_p1_y
            // 
            this.NumUpDwn_p1_y.Location = new System.Drawing.Point(34, 43);
            this.NumUpDwn_p1_y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NumUpDwn_p1_y.Name = "NumUpDwn_p1_y";
            this.NumUpDwn_p1_y.Size = new System.Drawing.Size(40, 22);
            this.NumUpDwn_p1_y.TabIndex = 3;
            this.NumUpDwn_p1_y.ValueChanged += new System.EventHandler(this.NumUpDwn_ValueChanged);
            this.NumUpDwn_p1_y.Enter += new System.EventHandler(this.NumUpDwn_Enter);
            this.NumUpDwn_p1_y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumUpDwn_KeyDown);
            // 
            // NumUpDwn_p1_x
            // 
            this.NumUpDwn_p1_x.Location = new System.Drawing.Point(34, 20);
            this.NumUpDwn_p1_x.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NumUpDwn_p1_x.Name = "NumUpDwn_p1_x";
            this.NumUpDwn_p1_x.Size = new System.Drawing.Size(40, 22);
            this.NumUpDwn_p1_x.TabIndex = 2;
            this.NumUpDwn_p1_x.ValueChanged += new System.EventHandler(this.NumUpDwn_ValueChanged);
            this.NumUpDwn_p1_x.Enter += new System.EventHandler(this.NumUpDwn_Enter);
            this.NumUpDwn_p1_x.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumUpDwn_KeyDown);
            // 
            // Label_P1_y
            // 
            this.Label_P1_y.AutoSize = true;
            this.Label_P1_y.Location = new System.Drawing.Point(7, 47);
            this.Label_P1_y.Name = "Label_P1_y";
            this.Label_P1_y.Size = new System.Drawing.Size(16, 16);
            this.Label_P1_y.TabIndex = 1;
            this.Label_P1_y.Text = "Y";
            // 
            // Label_P1_x
            // 
            this.Label_P1_x.AutoSize = true;
            this.Label_P1_x.Location = new System.Drawing.Point(7, 22);
            this.Label_P1_x.Name = "Label_P1_x";
            this.Label_P1_x.Size = new System.Drawing.Size(15, 16);
            this.Label_P1_x.TabIndex = 0;
            this.Label_P1_x.Text = "X";
            // 
            // Btn_p1_lock
            // 
            this.Btn_p1_lock.Location = new System.Drawing.Point(28, 25);
            this.Btn_p1_lock.Name = "Btn_p1_lock";
            this.Btn_p1_lock.Size = new System.Drawing.Size(52, 42);
            this.Btn_p1_lock.TabIndex = 13;
            this.Btn_p1_lock.Text = "+";
            this.Btn_p1_lock.UseVisualStyleBackColor = true;
            this.Btn_p1_lock.Click += new System.EventHandler(this.Btn_lock_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_Right_2);
            this.groupBox2.Controls.Add(this.Btn_Left_2);
            this.groupBox2.Controls.Add(this.NumUpDwn_p2_y);
            this.groupBox2.Controls.Add(this.Btn_Down_2);
            this.groupBox2.Controls.Add(this.NumUpDwn_p2_x);
            this.groupBox2.Controls.Add(this.Btn_Up_2);
            this.groupBox2.Controls.Add(this.Label_P2_x);
            this.groupBox2.Controls.Add(this.Label_P2_y);
            this.groupBox2.Controls.Add(this.Btn_p2_lock);
            this.groupBox2.Location = new System.Drawing.Point(197, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 72);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "1";
            this.groupBox2.Text = "Вторая точка";
            // 
            // Btn_Right_2
            // 
            this.Btn_Right_2.Location = new System.Drawing.Point(132, 30);
            this.Btn_Right_2.Name = "Btn_Right_2";
            this.Btn_Right_2.Size = new System.Drawing.Size(23, 23);
            this.Btn_Right_2.TabIndex = 17;
            this.Btn_Right_2.Text = "▶";
            this.Btn_Right_2.UseVisualStyleBackColor = true;
            this.Btn_Right_2.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn_Left_2
            // 
            this.Btn_Left_2.Location = new System.Drawing.Point(86, 30);
            this.Btn_Left_2.Name = "Btn_Left_2";
            this.Btn_Left_2.Size = new System.Drawing.Size(23, 23);
            this.Btn_Left_2.TabIndex = 18;
            this.Btn_Left_2.Text = "◀";
            this.Btn_Left_2.UseVisualStyleBackColor = true;
            this.Btn_Left_2.Click += new System.EventHandler(this.Btn_Click);
            // 
            // NumUpDwn_p2_y
            // 
            this.NumUpDwn_p2_y.Location = new System.Drawing.Point(34, 43);
            this.NumUpDwn_p2_y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NumUpDwn_p2_y.Name = "NumUpDwn_p2_y";
            this.NumUpDwn_p2_y.Size = new System.Drawing.Size(37, 22);
            this.NumUpDwn_p2_y.TabIndex = 7;
            this.NumUpDwn_p2_y.ValueChanged += new System.EventHandler(this.NumUpDwn_ValueChanged);
            this.NumUpDwn_p2_y.Enter += new System.EventHandler(this.NumUpDwn_Enter);
            this.NumUpDwn_p2_y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumUpDwn_KeyDown);
            // 
            // Btn_Down_2
            // 
            this.Btn_Down_2.Location = new System.Drawing.Point(109, 42);
            this.Btn_Down_2.Name = "Btn_Down_2";
            this.Btn_Down_2.Size = new System.Drawing.Size(23, 23);
            this.Btn_Down_2.TabIndex = 19;
            this.Btn_Down_2.Text = "▼";
            this.Btn_Down_2.UseVisualStyleBackColor = true;
            this.Btn_Down_2.Click += new System.EventHandler(this.Btn_Click);
            // 
            // NumUpDwn_p2_x
            // 
            this.NumUpDwn_p2_x.Location = new System.Drawing.Point(34, 20);
            this.NumUpDwn_p2_x.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NumUpDwn_p2_x.Name = "NumUpDwn_p2_x";
            this.NumUpDwn_p2_x.Size = new System.Drawing.Size(37, 22);
            this.NumUpDwn_p2_x.TabIndex = 6;
            this.NumUpDwn_p2_x.ValueChanged += new System.EventHandler(this.NumUpDwn_ValueChanged);
            this.NumUpDwn_p2_x.Enter += new System.EventHandler(this.NumUpDwn_Enter);
            this.NumUpDwn_p2_x.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumUpDwn_KeyDown);
            // 
            // Btn_Up_2
            // 
            this.Btn_Up_2.Location = new System.Drawing.Point(109, 22);
            this.Btn_Up_2.Name = "Btn_Up_2";
            this.Btn_Up_2.Size = new System.Drawing.Size(23, 23);
            this.Btn_Up_2.TabIndex = 16;
            this.Btn_Up_2.Text = "▲";
            this.Btn_Up_2.UseVisualStyleBackColor = true;
            this.Btn_Up_2.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Label_P2_x
            // 
            this.Label_P2_x.AutoSize = true;
            this.Label_P2_x.Location = new System.Drawing.Point(12, 22);
            this.Label_P2_x.Name = "Label_P2_x";
            this.Label_P2_x.Size = new System.Drawing.Size(15, 16);
            this.Label_P2_x.TabIndex = 4;
            this.Label_P2_x.Text = "X";
            // 
            // Label_P2_y
            // 
            this.Label_P2_y.AutoSize = true;
            this.Label_P2_y.Location = new System.Drawing.Point(12, 47);
            this.Label_P2_y.Name = "Label_P2_y";
            this.Label_P2_y.Size = new System.Drawing.Size(16, 16);
            this.Label_P2_y.TabIndex = 5;
            this.Label_P2_y.Text = "Y";
            // 
            // Btn_p2_lock
            // 
            this.Btn_p2_lock.Location = new System.Drawing.Point(28, 25);
            this.Btn_p2_lock.Name = "Btn_p2_lock";
            this.Btn_p2_lock.Size = new System.Drawing.Size(52, 42);
            this.Btn_p2_lock.TabIndex = 14;
            this.Btn_p2_lock.Text = "+";
            this.Btn_p2_lock.UseVisualStyleBackColor = true;
            this.Btn_p2_lock.Click += new System.EventHandler(this.Btn_lock_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Сгенерировать препятствия";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DrawObstacles);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(625, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "шт";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Кол-во  препятствий";
            // 
            // NumUpDwn_ObsNum
            // 
            this.NumUpDwn_ObsNum.Location = new System.Drawing.Point(557, 15);
            this.NumUpDwn_ObsNum.Name = "NumUpDwn_ObsNum";
            this.NumUpDwn_ObsNum.Size = new System.Drawing.Size(62, 22);
            this.NumUpDwn_ObsNum.TabIndex = 7;
            this.NumUpDwn_ObsNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumUpDwn_GridSize_KeyDown);
            // 
            // Find_way_Button
            // 
            this.Find_way_Button.Location = new System.Drawing.Point(424, 87);
            this.Find_way_Button.Name = "Find_way_Button";
            this.Find_way_Button.Size = new System.Drawing.Size(98, 28);
            this.Find_way_Button.TabIndex = 10;
            this.Find_way_Button.Text = "Найти путь";
            this.Find_way_Button.UseVisualStyleBackColor = true;
            this.Find_way_Button.Click += new System.EventHandler(this.Find_way_Button_Click);
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(528, 87);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(120, 28);
            this.Clear_Button.TabIndex = 11;
            this.Clear_Button.Text = "Очистить поле";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // Label_result
            // 
            this.Label_result.AutoSize = true;
            this.Label_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_result.Location = new System.Drawing.Point(11, 16);
            this.Label_result.Name = "Label_result";
            this.Label_result.Size = new System.Drawing.Size(65, 18);
            this.Label_result.TabIndex = 12;
            this.Label_result.Text = "Вывод:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.Clear_Button);
            this.panel2.Controls.Add(this.NumUpDwn_GridSize);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Find_way_Button);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.NumUpDwn_ObsNum);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(3, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 142);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.Label_result);
            this.panel3.Location = new System.Drawing.Point(426, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 376);
            this.panel3.TabIndex = 15;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 553);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.SquareGrid);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Window";
            this.Text = "Поиск кратчайшего пути";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_GridSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p1_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p1_x)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p2_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_p2_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwn_ObsNum)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SquareGrid;
        private System.Windows.Forms.NumericUpDown NumUpDwn_GridSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label_P1_y;
        private System.Windows.Forms.Label Label_P1_x;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Label_P2_x;
        private System.Windows.Forms.Label Label_P2_y;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NumUpDwn_ObsNum;
        private System.Windows.Forms.Button Find_way_Button;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Label Label_result;
        private System.Windows.Forms.NumericUpDown NumUpDwn_p1_y;
        private System.Windows.Forms.NumericUpDown NumUpDwn_p1_x;
        private System.Windows.Forms.NumericUpDown NumUpDwn_p2_y;
        private System.Windows.Forms.NumericUpDown NumUpDwn_p2_x;
        private System.Windows.Forms.Button Btn_p1_lock;
        private System.Windows.Forms.Button Btn_p2_lock;
        private System.Windows.Forms.Button Btn_Up_1;
        private System.Windows.Forms.Button Btn_Down_1;
        private System.Windows.Forms.Button Btn_Right_1;
        private System.Windows.Forms.Button Btn_Left_1;
        private System.Windows.Forms.Button Btn_Right_2;
        private System.Windows.Forms.Button Btn_Left_2;
        private System.Windows.Forms.Button Btn_Down_2;
        private System.Windows.Forms.Button Btn_Up_2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

