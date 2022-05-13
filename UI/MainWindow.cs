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

        /// <summary>
        /// ���ڼ���ʱִ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �رճ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// ��С������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
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

        private void PanelTitle_MouseMove(object sender, MouseEventArgs e)
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

        private void PanelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            // �������ɿ�ʱ�����϶��ж�����Ϊfalse
            IsDragging = false;
        }

        /// <summary>
        /// ����л����ܴ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTabEncrypt_Click(object sender, EventArgs e)
        {
            ButtonTabEncrypt.ForeColor = Color.White;
            ButtonTabDecrypt.ForeColor = Color.DeepSkyBlue;
        }

        /// <summary>
        /// ����л����ܴ���
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