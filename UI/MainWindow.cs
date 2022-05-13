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
            ButtonTabEncrypt.ForeColor = Color.White;
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
            TabControlMainWindow.SelectTab(0);
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
            TabControlMainWindow.SelectTab(1);
        }

        /// <summary>
        /// ����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "����ļ�",
                Filter = "�����ļ�|*.*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> fileNames = new List<string>();
                foreach (string fileName in openFileDialog.FileNames)
                {
                    fileNames.Add(fileName);
                }

                if (TabControlMainWindow.SelectedIndex == 0)
                {
                    // ������ļ��б�����ļ�
                    AddFile(fileNames, EncryptFileList);
                }
                else
                {
                    // ������ļ��б�����ļ�
                    AddFile(fileNames, DecryptFileList);
                }
            }
        }

        /// <summary>
        /// ����ļ����е������ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "��ѡ��һ���ļ���",
                ShowNewFolderButton = false
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;

                List<string> fileNames = FindAllFile(path);

                if (TabControlMainWindow.SelectedIndex == 0)
                {
                    // ������ļ��б�����ļ�
                    AddFile(fileNames, EncryptFileList);
                }
                else
                {
                    // ������ļ��б�����ļ�
                    AddFile(fileNames, DecryptFileList);
                }
            }
        }

        /// <summary>
        /// ����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClearList_Click(object sender, EventArgs e)
        {
            if (TabControlMainWindow.SelectedIndex == 0)
            {
                if (EncryptFileList.Rows.Count == 0)
                    return;

                if (MessageBox.Show("ȷ����ռ����ļ��б���", "����б�", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    EncryptFileList.Rows.Clear();
            }
            else
            {
                if (DecryptFileList.Rows.Count == 0)
                    return;

                if (MessageBox.Show("ȷ����ս����ļ��б���", "����б�", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    DecryptFileList.Rows.Clear();
            }
        }

        /// <summary>
        /// ִ�м���/���ܲ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRun_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ���б�������ļ�
        /// </summary>
        /// <param name="dataGridView">�б���</param>
        private void AddFile(List<string> fileNames ,DataGridView dataGridView)
        {
            int total = 0;
            int success = 0;
            // ����Ƿ���ӹ�ͬһ���ļ������������ӹ�ͬһ·���µ�ͬһ�ļ�����ܾ���ӽ��б�
            foreach (var fileName in fileNames)
            {
                total++;
                bool IsRepeat = false;
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (fileName == dataGridView.Rows[i].Cells[0].Value.ToString())
                    {
                        IsRepeat = true;
                        break;
                    }
                }
                // ���δ�ظ�������ӽ��б�
                if (!IsRepeat)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[rowIndex].Cells[0].Value = fileName;
                    dataGridView.Rows[rowIndex].Cells[2].Value = "׼��";
                    success++;
                }
            }
            MessageBox.Show($"�ɹ����{success}���ļ���{total - success}���ļ����ʧ�ܡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Ѱ���ļ�����������ļ�
        /// </summary>
        /// <param name="path">�ļ���·��</param>
        /// <returns>�ļ������е��ļ�·��</returns>
        private List<string> FindAllFile(string path)
        {
            List<string> fileNames = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
            foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
            {
                // �ж��Ƿ�Ϊ�ļ���
                if (fileSystemInfo is DirectoryInfo)
                {
                    // �ݹ����
                    FindAllFile(fileSystemInfo.FullName);
                }
                else
                {
                    fileNames.Add(fileSystemInfo.FullName);
                }
            }

            return fileNames;
        }
    }
}