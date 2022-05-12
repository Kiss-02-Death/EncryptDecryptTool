namespace UI
{
    public partial class MainWindow : Form
    {
        private static bool IsDragging = false; // 用于指示当前是否拖拽状态
        private Point StartPoint = new Point(0, 0); // 记录鼠标按下去的坐标
        private Point OffsetPoint = new Point(0, 0); // 记录偏移量

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            panel_ControlBox.Parent = pictureBox_BackGround;
            panel_Context.Parent = pictureBox_BackGround;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Close_MouseEnter(object sender, EventArgs e)
        {
            button_Close.Image = Properties.Resources.close_hover;
        }

        private void button_Close_MouseLeave(object sender, EventArgs e)
        {
            button_Close.Image = Properties.Resources.close;
        }

        private void button_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_Minimize_MouseEnter(object sender, EventArgs e)
        {
            button_Minimize.Image = Properties.Resources.minimize_hover;
        }

        private void button_Minimize_MouseLeave(object sender, EventArgs e)
        {
            button_Minimize.Image = Properties.Resources.minimize;
        }

        private void panel_ControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            // 如果按下去的按钮不是鼠标左键，就直接return
            if (e.Button != MouseButtons.Left)
                return;
            // 按下鼠标后，进入拖动状态
            IsDragging = true;
            // 记录刚刚按下时的坐标
            StartPoint.X = e.X;
            StartPoint.Y = e.Y;
        }

        private void panel_ControlBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                // 用当前坐标减去初始坐标得到偏移量Offset
                OffsetPoint.X = e.X - StartPoint.X;
                OffsetPoint.Y = e.Y - StartPoint.Y;
                // 将Offset转化为屏幕坐标赋值给Location
                this.Location = PointToScreen(OffsetPoint);
            }
        }

        private void panel_ControlBox_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标左键松开时，把拖动判定设置为false
            IsDragging = false;
        }

        private void label_Title_MouseDown(object sender, MouseEventArgs e)
        {
            panel_ControlBox_MouseDown(sender, e);
        }

        private void label_Title_MouseMove(object sender, MouseEventArgs e)
        {
            panel_ControlBox_MouseMove(sender, e);
        }

        private void label_Title_MouseUp(object sender, MouseEventArgs e)
        {
            panel_ControlBox_MouseUp(sender, e);
        }

        /// <summary>
        /// 拒绝一切的键盘按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefuseAnyKey(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}