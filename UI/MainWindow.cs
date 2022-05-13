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

        /// <summary>
        /// 窗口加载时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 最小化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
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

        private void PanelTitle_MouseMove(object sender, MouseEventArgs e)
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

        private void PanelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标左键松开时，把拖动判定设置为false
            IsDragging = false;
        }

        /// <summary>
        /// 点击切换加密窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTabEncrypt_Click(object sender, EventArgs e)
        {
            ButtonTabEncrypt.ForeColor = Color.White;
            ButtonTabDecrypt.ForeColor = Color.DeepSkyBlue;
        }

        /// <summary>
        /// 点击切换解密窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTabDecrypt_Click(object sender, EventArgs e)
        {
            ButtonTabEncrypt.ForeColor = Color.DeepSkyBlue;
            ButtonTabDecrypt.ForeColor = Color.White;
        }
    }
}