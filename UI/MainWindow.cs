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
            ButtonTabEncrypt.ForeColor = Color.White;
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
            TabControlMainWindow.SelectTab(0);
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
            TabControlMainWindow.SelectTab(1);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "添加文件",
                Filter = "所有文件|*.*",
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
                    // 向加密文件列表添加文件
                    AddFile(fileNames, EncryptFileList);
                }
                else
                {
                    // 向解密文件列表添加文件
                    AddFile(fileNames, DecryptFileList);
                }
            }
        }

        /// <summary>
        /// 添加文件夹中的所有文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "请选择一个文件夹",
                ShowNewFolderButton = false
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;

                List<string> fileNames = FindAllFile(path);

                if (TabControlMainWindow.SelectedIndex == 0)
                {
                    // 向加密文件列表添加文件
                    AddFile(fileNames, EncryptFileList);
                }
                else
                {
                    // 向解密文件列表添加文件
                    AddFile(fileNames, DecryptFileList);
                }
            }
        }

        /// <summary>
        /// 清空列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClearList_Click(object sender, EventArgs e)
        {
            if (TabControlMainWindow.SelectedIndex == 0)
            {
                if (EncryptFileList.Rows.Count == 0)
                    return;

                if (MessageBox.Show("确认清空加密文件列表吗？", "清空列表", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    EncryptFileList.Rows.Clear();
            }
            else
            {
                if (DecryptFileList.Rows.Count == 0)
                    return;

                if (MessageBox.Show("确认清空解密文件列表吗？", "清空列表", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    DecryptFileList.Rows.Clear();
            }
        }

        /// <summary>
        /// 执行加密/解密操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRun_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 向列表中添加文件
        /// </summary>
        /// <param name="dataGridView">列表名</param>
        private void AddFile(List<string> fileNames ,DataGridView dataGridView)
        {
            int total = 0;
            int success = 0;
            // 检测是否添加过同一份文件，如果曾经添加过同一路径下的同一文件，则拒绝添加进列表
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
                // 如果未重复，则添加进列表
                if (!IsRepeat)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[rowIndex].Cells[0].Value = fileName;
                    dataGridView.Rows[rowIndex].Cells[2].Value = "准备";
                    success++;
                }
            }
            MessageBox.Show($"成功添加{success}个文件，{total - success}个文件添加失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 寻找文件夹里的所有文件
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>文件里所有的文件路径</returns>
        private List<string> FindAllFile(string path)
        {
            List<string> fileNames = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
            foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
            {
                // 判断是否为文件夹
                if (fileSystemInfo is DirectoryInfo)
                {
                    // 递归调用
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