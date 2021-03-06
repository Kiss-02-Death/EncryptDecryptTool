using Encrypt;
using Decrypt;
using UIDelegate;

namespace UI
{
    public partial class MainWindow : Form
    {
        private static bool IsDragging = false; // 用于指示当前是否拖拽状态
        private Point StartPoint = new Point(0, 0); // 记录鼠标按下去的坐标
        private Point OffsetPoint = new Point(0, 0); // 记录偏移量
        private DateTime StartDateTime; // 记录开始时间

        private DgvUpdata dgvUpdata = null; // 表格记录更新委托
        private DgvProgress dgvProgress = null; // 加解密进度更新委托
        private FormUpdata formUpdata = null; // 界面更新委托
        private StopWatchUpdata stopWatchUpdata = null; // 计时器状态更新委托


        public MainWindow()
        {
            InitializeComponent();
            // 给表格记录更新委托绑定 表格记录更新函数
            dgvUpdata = SetDGVUpdata;
            // 给加解密进度更新委托绑定 操作进度反馈函数
            dgvProgress = SetOperationProgress;
            // 给界面更新委托绑定 界面更新函数
            formUpdata = SetFormControl;
            // 给计时器状态更新委托绑定 计时器状态函数
            stopWatchUpdata = SetStopWatchState;
        }

        /// <summary>
        /// 窗口加载时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // 界面初始后默认加载加密界面
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
            // 切换加密窗口
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
            // 切换解密窗口
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
            // 新建 打开文件对话框，允许选择多个文件
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
                    Filter = "WPFENCRYPT文件|*.WPFENCRYPT",
                    Multiselect = true
                };
            }
            // 如果对话框返回值为OK，则添加选择的文件
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
                    // 记录非 .WPFENCRYPT 拓展名的文件索引，删除掉
                    List<int> indexes = new List<int>();
                    for (int i = fileNames.Count - 1; i >= 0; i--)
                    {
                        if (Path.GetExtension(fileNames[i]) != ".WPFENCRYPT")
                            indexes.Add(i);
                    }
                    if (indexes.Count > 0)
                    {
                        foreach (int index in indexes)
                        {
                            fileNames.RemoveAt(index);
                        }
                    }

                    // 向解密文件列表添加文件
                    AddFile(fileNames, DecryptFileList);
                }
            }
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
                    dataGridView.Rows[rowIndex].Cells[4].Value = "否";
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
                    fileNames.AddRange(FindAllFile(fileSystemInfo.FullName));
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
            catch (Exception e)
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
            // 先对列表进行处理，把历史记录清理掉
            List<int> rowIndexes = new List<int>();
            if (TabControlMainWindow.SelectedIndex == 0) // 当前界面在加密界面时
            {
                // 找出所有历史行的行索引值
                for (int i = EncryptFileList.Rows.Count - 1; i >= 0; i--)
                {
                    if (EncryptFileList.Rows[i].Cells[4].Value.ToString() == "是")
                        rowIndexes.Add(i);
                }
                // 删除这些历史行
                if (rowIndexes.Count > 0)
                {
                    foreach (int rowIndex in rowIndexes)
                    {
                        EncryptFileList.Rows.RemoveAt(rowIndex);
                    }
                }
                // 如果加密列表数量为0，直接return
                if (EncryptFileList.Rows.Count == 0)
                    return;
            }
            else // 当前界面在解密界面时
            {
                // 找出所有历史行的行索引值
                for (int i = DecryptFileList.Rows.Count - 1; i >= 0; i--)
                {
                    if (DecryptFileList.Rows[i].Cells[4].Value.ToString() == "是")
                        rowIndexes.Add(i);
                }
                // 删除这些历史行
                if (rowIndexes.Count > 0)
                {
                    foreach (int rowIndex in rowIndexes)
                    {
                        DecryptFileList.Rows.RemoveAt(rowIndex);
                    }
                }
                // 如果解密列表数量为0，直接return
                if (DecryptFileList.Rows.Count == 0)
                    return;
            }
            
            if (TabControlMainWindow.SelectedIndex == 0) // 当前界面在加密界面时
            {
                if (MessageBox.Show("确定要开始加密文件吗？\n" +
                    "（若导出位置有重名文件，则会被覆盖！）", "开始加密", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                    LabelTime.Text = "已用时间：00:00:00";
                    Task.Factory.StartNew(() =>
                    {
                        this.BeginInvoke(formUpdata, new object[] { false }); // 锁定按钮
                        StartDateTime = DateTime.Now; // 记录开始时间
                        this.BeginInvoke(stopWatchUpdata, new object[] { 1 }); // 开始计时
                        for (int i = 0; i < EncryptFileList.Rows.Count; i++)
                        {
                            this.BeginInvoke(dgvUpdata, new object[] { 1, i }); // 更新加密列表数据
                            string inputFile = EncryptFileList.Rows[i].Cells[0].Value.ToString();
                            string outputFile = folderBrowserDialog.SelectedPath + "\\" + Path.GetFileName(inputFile) + ".WPFENCRYPT";

                            // 如果勾选了删除源文件、则加密完成后删除源文件
                            if (EncryptFile(inputFile, outputFile, i) && File.Exists(inputFile) && WhetherDelete.Checked)
                            {
                                File.Delete(inputFile);
                            }
                        }
                        this.BeginInvoke(stopWatchUpdata, new object[] { 2 }); // 结束计时
                        MessageBox.Show("加密完成！","提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BeginInvoke(formUpdata, new object[] { true }); // 解锁按钮
                    });
                }
                
            }
            else // 当前界面在解密界面时
            {
                if (MessageBox.Show("确定要开始解密文件吗？\n" +
                    "（若导出位置有重名文件，则会被覆盖！）", "开始解密", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                    LabelTime.Text = "已用时间：00:00:00";
                    Task.Factory.StartNew(() =>
                    {
                        this.BeginInvoke(formUpdata, new object[] { false }); // 锁定按钮
                        StartDateTime = DateTime.Now; // 记录开始时间
                        this.BeginInvoke(stopWatchUpdata, new object[] { 1 }); // 开始计时
                        for (int i = 0; i < DecryptFileList.Rows.Count; i++)
                        {
                            this.BeginInvoke(dgvUpdata, new object[] { 2, i }); // 更新解密列表数据
                            string inputFile = DecryptFileList.Rows[i].Cells[0].Value.ToString();
                            string outputFile = folderBrowserDialog.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(inputFile);

                            // 如果勾选了删除源文件、则解密完成后删除源文件
                            if (DecryptFile(inputFile, outputFile, i) && File.Exists(inputFile) && WhetherDelete.Checked)
                            {
                                File.Delete(inputFile);
                            }
                        }
                        this.BeginInvoke(stopWatchUpdata, new object[] { 2 }); // 结束计时
                        MessageBox.Show("解密完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BeginInvoke(formUpdata, new object[] { true }); // 解锁按钮
                    });
                }
            }
        }

        /// <summary>
        /// 加密列表删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex != 2)
                return;

            if (MessageBox.Show("确认要删除该文件吗？","删除文件", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                EncryptFileList.Rows.RemoveAt(e.RowIndex);
            }
        }

        /// <summary>
        /// 解密列表删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="rowIndex">当前操作所在dgv的行索引</param>
        /// <returns>若加密成功，返回True，否则返回False</returns>
        private bool EncryptFile(string inputFile, string outputFile, int rowIndex)
        {
            this.dgvProgress?.Invoke(1, rowIndex, 0);
            try
            {
                FileStream fRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                // 如果文件大于1MB，采用分块加密，按1MB读写
                if (fRead.Length > 1 * 1024 * 1024)
                {
                    byte[] myByte = new byte[1 * 1024 * 1024]; // 每1MB加密一次
                    int byteRead = 1 * 1024 * 1024; // 每次加密的流的大小
                    long leftBytes = fRead.Length; // 剩余需要加密的流大小
                    long readBytes = 0; // 已经读取的流的大小
                    byte[] encrypt = new byte[1 * 1024 * 1024 + 16]; // 每次加密后会增加16字节

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
                        else // 重新设定读取流的大小，避免最后多余空值
                        {
                            byte[] newByte = new byte[leftBytes];
                            fRead.Read(newByte, 0, newByte.Length);
                            byte[] newWriteByte = AESEncrypt.Encrypt(newByte, TextBoxPassword.Text);
                            fWrite.Write(newWriteByte, 0, newWriteByte.Length);
                            readBytes += leftBytes;
                            break;
                        }
                        int progress = Convert.ToInt32(readBytes * 100 / fRead.Length);
                        this.dgvProgress?.Invoke(1, rowIndex, progress);
                    }
                }
                else
                {
                    byte[] myByte = new byte[fRead.Length];
                    fRead.Read(myByte, 0, myByte.Length);
                    byte[] encrypt = AESEncrypt.Encrypt(myByte, TextBoxPassword.Text);
                    fWrite.Write(encrypt, 0, encrypt.Length);
                }
                this.dgvProgress?.Invoke(1, rowIndex, 100);
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
        /// <param name="rowIndex">当前操作所在dgv的行索引</param>
        /// <returns>若解密成功，返回True，否则返回False</returns>
        private bool DecryptFile(string inputFile, string outputFile, int rowIndex)
        {
            this.dgvProgress?.Invoke(2, rowIndex, 0);
            try
            {
                FileStream fRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                // 如果文件大于1MB，采用分块加密，按1MB读写
                if (fRead.Length > 1 * 1024 * 1024)
                {
                    byte[] myByte = new byte[1 * 1024 * 1024 + 16]; // 解密缓冲区1MB+16字节
                    int byteRead = 1 * 1024 * 1024 + 16; // 每次解密的流的大小
                    long leftBytes = fRead.Length; // 剩余需要解密的流大小
                    long readBytes = 0; // 已经读取的流的大小
                    byte[] decrypt = new byte[1 * 1024 * 1024]; // 解密后的流大小

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
                        else // 重新设定读取流的大小，避免最后多余空值
                        {
                            byte[] newByte = new byte[leftBytes];
                            fRead.Read(newByte, 0, newByte.Length);
                            byte[] newWriteByte = AESDecrypt.Decrypt(newByte, TextBoxPassword.Text);
                            fWrite.Write(newWriteByte, 0, newWriteByte.Length);
                            readBytes += leftBytes;
                            break;
                        }
                        int progress = Convert.ToInt32(readBytes * 100 / fRead.Length);
                        this.dgvProgress?.Invoke(2, rowIndex, progress);
                    }
                }
                else
                {
                    byte[] myByte = new byte[fRead.Length];
                    fRead.Read(myByte, 0, myByte.Length);
                    byte[] decrypt = AESDecrypt.Decrypt(myByte, TextBoxPassword.Text);
                    fWrite.Write(decrypt, 0, decrypt.Length);
                }
                this.dgvProgress?.Invoke(2, rowIndex, 100);
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
        /// 更改列表行的记录，被操作过的行记为历史行
        /// </summary>
        /// <param name="type">类型值：1为加密，2为解密</param>
        /// <param name="rowIndex">当前操作行索引值</param>
        private void SetDGVUpdata(int type, int rowIndex)
        {
            if (type == 1)
                EncryptFileList.Rows[rowIndex].Cells[4].Value = "是";
            else
                DecryptFileList.Rows[rowIndex].Cells[4].Value = "是";
        }

        /// <summary>
        /// 加/解密进度反馈
        /// </summary>
        /// <param name="type">类型值：1为加密，2为解密</param>
        /// <param name="rowIndex">当前操作行索引值</param>
        /// <param name="progress">进度</param>
        private void SetOperationProgress(int type, int rowIndex, int progress)
        {
            if (type == 1)
                EncryptFileList.Rows[rowIndex].Cells[3].Value = progress + "%";
            else
                DecryptFileList.Rows[rowIndex].Cells[3].Value = progress + "%";
        }

        /// <summary>
        /// 界面更新函数
        /// </summary>
        /// <param name="isComplete">是否完成加/解密</param>
        private void SetFormControl(bool isComplete)
        {
            // 如果加/解密操作完成，则解除按钮锁定
            if (isComplete)
            {
                ButtonTabEncrypt.Enabled = true;
                ButtonTabDecrypt.Enabled = true;

                ButtonAddDocument.Enabled = true;
                ButtonAddFolder.Enabled = true;
                ButtonClearList.Enabled = true;

                TextBoxPassword.Enabled = true;
                WhetherDelete.Enabled = true;
                ButtonRun.Enabled = true;
            }
            else
            {
                ButtonTabEncrypt.Enabled = false;
                ButtonTabDecrypt.Enabled = false;

                ButtonAddDocument.Enabled = false;
                ButtonAddFolder.Enabled = false;
                ButtonClearList.Enabled = false;

                TextBoxPassword.Enabled = false;
                WhetherDelete.Enabled = false;
                ButtonRun.Enabled = false;
            }
        }

        /// <summary>
        /// 设置计时器状态
        /// </summary>
        /// <param name="type">类型值：1为开始，2为停止</param>
        private void SetStopWatchState(int type)
        {
            if (type == 1)
                StopWatch.Start();
            else
                StopWatch.Stop();
        }

        /// <summary>
        /// 设置加/解密使用时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopWatch_Tick(object sender, EventArgs e)
        {
            TimeSpan timeCount = DateTime.Now - StartDateTime;
            LabelTime.Text = "已用时间：" + string.Format("{0:00}:{1:00}:{2:00}", timeCount.Hours, timeCount.Minutes, timeCount.Seconds);
        }

        /// <summary>
        /// 只接收英文、数字和退格键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void EncryptFileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None; 
        }

        /// <summary>
        /// 拖拽文件或文件夹到加密列表里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptFileList_DragDrop(object sender, DragEventArgs e)
        {
            // 接收拖拽文件或文件夹
            string[] tempFileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            List<string> fileNames = new List<string>();
            foreach(string fileName in tempFileNames)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
                // 判断当前路径是否为文件
                if (File.Exists(fileName))
                {
                    fileNames.Add(fileName);
                }
                else
                {
                    FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
                    foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
                    {
                        // 判断是否为文件夹
                        if (fileSystemInfo is DirectoryInfo)
                        {
                            fileNames.AddRange(FindAllFile(fileSystemInfo.ToString()));
                        }
                        else
                        {
                            fileNames.Add(fileSystemInfo.ToString());
                        }
                    }
                }
            }
            AddFile(fileNames, EncryptFileList);
        }

        private void DecryptFileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 拖拽文件或文件夹到解密列表里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecryptFileList_DragDrop(object sender, DragEventArgs e)
        {
            // 接收拖拽文件或文件夹
            string[] tempFileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            List<string> fileNames = new List<string>();
            foreach (string fileName in tempFileNames)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
                // 判断当前路径是否为文件
                if (File.Exists(fileName) && Path.GetExtension(fileName) == ".WPFENCRYPT")
                {
                    fileNames.Add(fileName);
                }
                else
                {
                    FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
                    foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
                    {
                        // 判断是否为文件夹
                        if (fileSystemInfo is DirectoryInfo)
                        {
                            List<string> files = new List<string>();
                            files.AddRange(FindAllFile(fileSystemInfo.ToString()));
                            foreach (string file in files)
                            {
                                if (Path.GetExtension(file) == ".WPFENCRYPT")
                                {
                                    fileNames.Add(file);
                                }
                            }
                        }
                        else if (Path.GetExtension(fileSystemInfo.ToString()) == ".WPFENCRYPT")
                        {
                            fileNames.Add(fileSystemInfo.ToString());
                        }
                    }
                }
            }
            AddFile(fileNames, DecryptFileList);
        }

        /// <summary>
        /// 删除源文件警告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WhetherDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (WhetherDelete.Checked)
            {
                if (MessageBox.Show("警告！请谨慎勾选此选项！若导致文件不可逆操作概不负责！","警告",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    WhetherDelete.Checked = false;
            }
        }
    }
}