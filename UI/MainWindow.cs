using Encrypt;
using Decrypt;

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
            ButtonTabEncrypt_Click(sender, e);
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
            WhetherDelete.Text = "加密完成后删除源文件";
            ButtonRun.Text = "开始加密";
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
            WhetherDelete.Text = "解密完成后删除源文件";
            ButtonRun.Text = "开始解密";
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            if (TabControlMainWindow.SelectedIndex == 0)
            {
                openFileDialog = new OpenFileDialog()
                {
                    Title = "添加文件",
                    Filter = "所有文件|*.*",
                    Multiselect = true
                };
            }
            else
            {
                openFileDialog = new OpenFileDialog()
                {
                    Title = "添加文件",
                    Filter = "encrypt文件|*.encrypt",
                    Multiselect = true
                };
            }

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
            ButtonAddDocument.Enabled = false;
            ButtonAddFolder.Enabled = false;
            ButtonClearList.Enabled = false;
            TextBoxPassword.Enabled = false;
            WhetherDelete.Enabled = false;

            if (TabControlMainWindow.SelectedIndex == 0)
            {
                if (MessageBox.Show("确定要开始加密文件吗？", "开始加密", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // 选择文件导出位置
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
                    {
                        Description = "请选择导出位置",
                        ShowNewFolderButton = true
                    };
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    int success = 0;
                    int total = EncryptFileList.Rows.Count;
                    for (int i = 0; i < EncryptFileList.Rows.Count; i++)
                    {
                        string inputFile = EncryptFileList.Rows[i].Cells[0].Value.ToString();
                        string outputFile = folderBrowserDialog.SelectedPath + "\\" + Path.GetFileName(inputFile) + ".encrypt";

                        EncryptFileList.Rows[i].Cells[3].Value = "加密中...";
                        if (EncryptFile(inputFile, outputFile))
                        {
                            EncryptFileList.Rows[i].Cells[3].Value = "加密完成";
                            if (File.Exists(inputFile) && WhetherDelete.Checked) // 加密完成后删除源文件
                            {
                                File.Delete(inputFile);
                            }
                            success++;
                        }
                        else
                        {
                            EncryptFileList.Rows[i].Cells[3].Value = "加密失败";
                        }
                    }
                    MessageBox.Show($"加密完成！本次共加密{total}个文件，其中{success}个文件加密成功，{total - success}个文件加密失败！");
                }
            }
            else
            {
                if (MessageBox.Show("确定要开始解密文件吗？", "开始解密", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // 选择文件导出位置
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
                    {
                        Description = "请选择导出位置",
                        ShowNewFolderButton = true
                    };
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    int success = 0;
                    int total = DecryptFileList.Rows.Count;
                    for (int i = 0; i < DecryptFileList.Rows.Count; i++)
                    {
                        string inputFile = DecryptFileList.Rows[i].Cells[0].Value.ToString();
                        string outputFile = folderBrowserDialog.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(inputFile);

                        DecryptFileList.Rows[i].Cells[3].Value = "解密中...";
                        if (DecryptFile(inputFile, outputFile))
                        {
                            DecryptFileList.Rows[i].Cells[3].Value = "解密完成";
                            if (File.Exists(inputFile) && WhetherDelete.Checked) // 解密完成后删除加密文件
                            {
                                File.Delete(inputFile);
                            }
                            success++;
                        }
                        else
                        {
                            DecryptFileList.Rows[i].Cells[3].Value = "解密失败";
                        }
                    }
                    MessageBox.Show($"加密完成！本次共解密{total}个文件，其中{success}个文件解密成功，{total - success}个文件解密失败！");
                }
            }

            ButtonAddDocument.Enabled = true;
            ButtonAddFolder.Enabled = true;
            ButtonClearList.Enabled = true;

            TextBoxPassword.Enabled = true;
            WhetherDelete.Enabled = true;
        }

        /// <summary>
        /// 向列表中添加文件
        /// </summary>
        /// <param name="dataGridView">列表名</param>
        private void AddFile(List<string> fileNames, DataGridView dataGridView)
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
                    dataGridView.Rows[rowIndex].Cells[1].Value = LoadFileSize(fileName);
                    dataGridView.Rows[rowIndex].Cells[3].Value = "准备";
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

        /// <summary>
        /// 加载文件大小
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>文件大小（KB）</returns>
        private string LoadFileSize(string path)
        {
            FileInfo fileInfo;
            try
            {
                fileInfo = new FileInfo(path);
            }
            catch(Exception e)
            {
                return e.Message;
            }

            if (fileInfo != null && fileInfo.Exists)
            {
                if (fileInfo.Length > 1024 * 1024 * 1024)
                    return Math.Round(fileInfo.Length / 1024.0 / 1024.0 / 1024.0, 1).ToString() + "GB";
                else if (fileInfo.Length > 1024 * 1024)
                    return Math.Round(fileInfo.Length / 1024.0 / 1024.0, 1).ToString() + "MB";
                else
                    return Math.Round(fileInfo.Length / 1024.0, 1).ToString() + "KB";
            }
            else
            {
                return "未知大小";
            }
        }

        private void EncryptFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex != 2)
                return;

            if (MessageBox.Show("确认要删除该文件吗？","删除文件", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                EncryptFileList.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DecryptFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex != 2)
                return;

            if (MessageBox.Show("确认要删除该文件吗？", "删除文件", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DecryptFileList.Rows.RemoveAt(e.RowIndex);
            }
        }

        /// <summary>
        /// 加密文件操作
        /// </summary>
        /// <param name="inputFile">源文件路径</param>
        /// <param name="outputFile">输出文件路径</param>
        /// <returns>若加密成功，返回True，否则返回False</returns>
        private bool EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                FileStream fRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                // 如果文件大于50MB，采用分块加密，按50MB读写
                if (fRead.Length > 50 * 1024 * 1024)
                {
                    byte[] myByte = new byte[50 * 1024 * 1024]; //每50MB加密一次
                    int byteRead = 50 * 1024 * 1024; // 每次加密的流的大小
                    long leftBytes = fRead.Length; // 剩余需要加密的流大小
                    long readBytes = 0; // 已经读取的流的大小
                    byte[] encrypt = new byte[50 * 1024 * 1024 + 16]; // 每次加密后会增加16字节

                    while (true)
                    {
                        if (leftBytes > byteRead)
                        {
                            fRead.Read(myByte, 0, myByte.Length);
                            encrypt = AESEncrypt.Encrypt(myByte, TextBoxPassword.Text);
                            fWrite.Write(encrypt, 0, encrypt.Length);
                            leftBytes -= byteRead;
                            readBytes += byteRead;
                        }
                        else //重新设定读取流的大小，避免最后多余空值
                        {
                            byte[] newByte = new byte[leftBytes];
                            fRead.Read(newByte, 0, newByte.Length);
                            byte[] newWriteByte = AESEncrypt.Encrypt(newByte, TextBoxPassword.Text);
                            fWrite.Write(newWriteByte, 0, newWriteByte.Length);
                            readBytes += leftBytes;
                            break;
                        }
                    }
                }
                else
                {
                    byte[] myByte = new byte[fRead.Length];
                    fRead.Read(myByte, 0, myByte.Length);
                    byte[] encrypt = AESEncrypt.Encrypt(myByte, TextBoxPassword.Text);
                    fWrite.Write(encrypt, 0, encrypt.Length);
                }

                fRead.Close();
                fWrite.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 解密文件操作
        /// </summary>
        /// <param name="inputFile">要解密的文件路径</param>
        /// <param name="outputFile">解密后的文件路径</param>
        /// <returns>若解密成功，返回True，否则返回False</returns>
        private bool DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                FileStream fRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                // 如果文件大于50MB，采用分块加密，按50MB读写
                if (fRead.Length > 50 * 1024 * 1024)
                {
                    byte[] myByte = new byte[50 * 1024 * 1024 + 16]; // 解密缓冲区50MB+16字节
                    int byteRead = 50 * 1024 * 1024 + 16; // 每次解密的流的大小
                    long leftBytes = fRead.Length; // 剩余需要解密的流大小
                    long readBytes = 0; // 已经读取的流的大小
                    byte[] decrypt = new byte[50 * 1024 * 1024]; // 解密后的流大小

                    while (true)
                    {
                        if (leftBytes > byteRead)
                        {
                            fRead.Read(myByte, 0, myByte.Length);
                            decrypt = AESDecrypt.Decrypt(myByte, TextBoxPassword.Text);
                            fWrite.Write(decrypt, 0, decrypt.Length);
                            leftBytes -= byteRead;
                            readBytes += byteRead;
                        }
                        else //重新设定读取流的大小，避免最后多余空值
                        {
                            byte[] newByte = new byte[leftBytes];
                            fRead.Read(newByte, 0, newByte.Length);
                            byte[] newWriteByte = AESDecrypt.Decrypt(newByte, TextBoxPassword.Text);
                            fWrite.Write(newWriteByte, 0, newWriteByte.Length);
                            readBytes += leftBytes;
                            break;
                        }
                    }
                }
                else
                {
                    byte[] myByte = new byte[fRead.Length];
                    fRead.Read(myByte, 0, myByte.Length);
                    byte[] decrypt = AESDecrypt.Decrypt(myByte, TextBoxPassword.Text);
                    fWrite.Write(decrypt, 0, decrypt.Length);
                }

                fRead.Close();
                fWrite.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}