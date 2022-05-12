namespace UI
{
    public partial class MainWindow : Form
    {
        private static bool IsDragging = false; // ����ָʾ��ǰ�Ƿ���ק״̬
        private Point StartPoint = new Point(0, 0); // ��¼��갴��ȥ������
        private Point OffsetPoint = new Point(0, 0); // ��¼ƫ����

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
            // �������ȥ�İ�ť��������������ֱ��return
            if (e.Button != MouseButtons.Left)
                return;
            // �������󣬽����϶�״̬
            IsDragging = true;
            // ��¼�ոհ���ʱ������
            StartPoint.X = e.X;
            StartPoint.Y = e.Y;
        }

        private void panel_ControlBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                // �õ�ǰ�����ȥ��ʼ����õ�ƫ����Offset
                OffsetPoint.X = e.X - StartPoint.X;
                OffsetPoint.Y = e.Y - StartPoint.Y;
                // ��Offsetת��Ϊ��Ļ���긳ֵ��Location
                this.Location = PointToScreen(OffsetPoint);
            }
        }

        private void panel_ControlBox_MouseUp(object sender, MouseEventArgs e)
        {
            // �������ɿ�ʱ�����϶��ж�����Ϊfalse
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
        /// �ܾ�һ�еļ��̰���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefuseAnyKey(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}