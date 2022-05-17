using Encrypt;
using Decrypt;
using UIDelegate;

namespace UI
{
    public partial class MainWindow : Form
    {
        private static bool IsDragging = false; // ����ָʾ��ǰ�Ƿ���ק״̬
        private Point StartPoint = new Point(0, 0); // ��¼��갴��ȥ������
        private Point OffsetPoint = new Point(0, 0); // ��¼ƫ����

        private DgvUpdata dgvUpdata = null; // ����¼����ί��
        private DgvProgress dgvProgress = null; // �ӽ��ܽ��ȸ���ί��
        private FormUpdata formUpdata = null; // �������ί��


        public MainWindow()
        {
            InitializeComponent();
            // ������¼���°� ����¼���º���
            dgvUpdata = SetDGVUpdata;
            // ���ӽ��ܽ��ȸ���ί�а� �������ȷ�������
            dgvProgress = SetOperationProgress;
            // ���������ί�а� ������º���
            formUpdata = SetFormControl;
        }

        /// <summary>
        /// ���ڼ���ʱִ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // �����ʼ��Ĭ�ϼ��ؼ��ܽ���
            ButtonTabEncrypt_Click(sender, e);
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
            // �л����ܴ���
            TabControlMainWindow.SelectTab(0);
            WhetherDelete.Text = "������ɺ�ɾ��Դ�ļ�";
            ButtonRun.Text = "��ʼ����";
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
            // �л����ܴ���
            TabControlMainWindow.SelectTab(1);
            WhetherDelete.Text = "������ɺ�ɾ��Դ�ļ�";
            ButtonRun.Text = "��ʼ����";
        }

        /// <summary>
        /// ����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDocument_Click(object sender, EventArgs e)
        {
            // �½� ���ļ��Ի�������ѡ�����ļ�
            OpenFileDialog openFileDialog;
            if (TabControlMainWindow.SelectedIndex == 0)
            {
                openFileDialog = new OpenFileDialog()
                {
                    Title = "����ļ�",
                    Filter = "�����ļ�|*.*",
                    Multiselect = true
                };
            }
            else
            {
                openFileDialog = new OpenFileDialog()
                {
                    Title = "����ļ�",
                    Filter = "encrypt�ļ�|*.encrypt",
                    Multiselect = true
                };
            }
            // ����Ի��򷵻�ֵΪOK�������ѡ����ļ�
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
            // �ȶ��б���д�������ʷ��¼�����
            List<int> rowIndexs = new List<int>();
            if (TabControlMainWindow.SelectedIndex == 0)
            {
                // �ҳ�������ʷ�е�������ֵ
                for (int i = EncryptFileList.Rows.Count - 1; i >= 0; i--)
                {
                    if (EncryptFileList.Rows[i].Cells[4].Value.ToString() == "��")
                        rowIndexs.Add(i);
                }
                // ɾ����Щ��ʷ��
                if (rowIndexs.Count > 0)
                {
                    foreach (int rowIndex in rowIndexs)
                    {
                        EncryptFileList.Rows.RemoveAt(rowIndex);
                    }
                }
                // ��������б�����Ϊ0��ֱ��return
                if (EncryptFileList.Rows.Count == 0)
                    return;
            }
            else
            {
                // �ҳ�������ʷ�е�������ֵ
                for (int i = DecryptFileList.Rows.Count - 1; i >= 0; i--)
                {
                    if (DecryptFileList.Rows[i].Cells[4].Value.ToString() == "��")
                        rowIndexs.Add(i);
                }
                // ɾ����Щ��ʷ��
                if (rowIndexs.Count > 0)
                {
                    foreach (int rowIndex in rowIndexs)
                    {
                        DecryptFileList.Rows.RemoveAt(rowIndex);
                    }
                }
                // ��������б�����Ϊ0��ֱ��return
                if (DecryptFileList.Rows.Count == 0)
                    return;
            }
            
            this.formUpdata?.Invoke(false);
            if (TabControlMainWindow.SelectedIndex == 0)
            {
                if (MessageBox.Show("ȷ��Ҫ��ʼ�����ļ���", "��ʼ����", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // ѡ���ļ�����λ��
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
                    {
                        Description = "��ѡ�񵼳�λ��",
                        ShowNewFolderButton = true
                    };
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < EncryptFileList.Rows.Count; i++)
                        {
                            this.BeginInvoke(dgvUpdata, new object[] { 1, i });
                            string inputFile = EncryptFileList.Rows[i].Cells[0].Value.ToString();
                            string outputFile = folderBrowserDialog.SelectedPath + "\\" + Path.GetFileName(inputFile) + ".encrypt";

                            // ������ɺ�ɾ��Դ�ļ�
                            if (EncryptFile(inputFile, outputFile, i) && File.Exists(inputFile) && WhetherDelete.Checked)
                            {
                                File.Delete(inputFile);
                            }
                        }
                        MessageBox.Show("������ɣ�","��ʾ",MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.BeginInvoke(formUpdata, new object[] { true });
                    });
                }
                
            }
            else
            {
                if (MessageBox.Show("ȷ��Ҫ��ʼ�����ļ���", "��ʼ����", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // ѡ���ļ�����λ��
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
                    {
                        Description = "��ѡ�񵼳�λ��",
                        ShowNewFolderButton = true
                    };
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < DecryptFileList.Rows.Count; i++)
                        {
                            this.BeginInvoke(dgvUpdata, new object[] { 2, i });
                            string inputFile = DecryptFileList.Rows[i].Cells[0].Value.ToString();
                            string outputFile = folderBrowserDialog.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(inputFile);

                            // ������ɺ�ɾ��Դ�ļ�
                            if (DecryptFile(inputFile, outputFile, i) && File.Exists(inputFile) && WhetherDelete.Checked)
                            {
                                File.Delete(inputFile);
                            }
                        }
                        MessageBox.Show("������ɣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.BeginInvoke(formUpdata, new object[] { true });
                    });
                }
            }
        }

        /// <summary>
        /// ���б�������ļ�
        /// </summary>
        /// <param name="dataGridView">�б���</param>
        private void AddFile(List<string> fileNames, DataGridView dataGridView)
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
                    dataGridView.Rows[rowIndex].Cells[1].Value = LoadFileSize(fileName);
                    dataGridView.Rows[rowIndex].Cells[3].Value = "׼��";
                    dataGridView.Rows[rowIndex].Cells[4].Value = "��";
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

        /// <summary>
        /// �����ļ���С
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <returns>�ļ���С��KB��</returns>
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
                return "δ֪��С";
            }
        }

        /// <summary>
        /// �����б�ɾ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex != 2)
                return;

            if (MessageBox.Show("ȷ��Ҫɾ�����ļ���","ɾ���ļ�", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                EncryptFileList.Rows.RemoveAt(e.RowIndex);
            }
        }

        /// <summary>
        /// �����б�ɾ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecryptFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.ColumnIndex != 2)
                return;

            if (MessageBox.Show("ȷ��Ҫɾ�����ļ���", "ɾ���ļ�", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DecryptFileList.Rows.RemoveAt(e.RowIndex);
            }
        }

        /// <summary>
        /// �����ļ�����
        /// </summary>
        /// <param name="inputFile">Դ�ļ�·��</param>
        /// <param name="outputFile">����ļ�·��</param>
        /// <param name="rowIndex">��ǰ��������dgv��������</param>
        /// <returns>�����ܳɹ�������True�����򷵻�False</returns>
        private bool EncryptFile(string inputFile, string outputFile, int rowIndex)
        {
            this.dgvProgress?.Invoke(1, rowIndex, 0);
            try
            {
                FileStream fRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                // ����ļ�����10MB�����÷ֿ���ܣ���10MB��д
                if (fRead.Length > 10 * 1024 * 1024)
                {
                    byte[] myByte = new byte[10 * 1024 * 1024]; // ÿ10MB����һ��
                    int byteRead = 10 * 1024 * 1024; // ÿ�μ��ܵ����Ĵ�С
                    long leftBytes = fRead.Length; // ʣ����Ҫ���ܵ�����С
                    long readBytes = 0; // �Ѿ���ȡ�����Ĵ�С
                    byte[] encrypt = new byte[10 * 1024 * 1024 + 16]; // ÿ�μ��ܺ������16�ֽ�

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
                        else // �����趨��ȡ���Ĵ�С�������������ֵ
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
        /// �����ļ�����
        /// </summary>
        /// <param name="inputFile">Ҫ���ܵ��ļ�·��</param>
        /// <param name="outputFile">���ܺ���ļ�·��</param>
        /// <param name="rowIndex">��ǰ��������dgv��������</param>
        /// <returns>�����ܳɹ�������True�����򷵻�False</returns>
        private bool DecryptFile(string inputFile, string outputFile, int rowIndex)
        {
            this.dgvProgress?.Invoke(2, rowIndex, 0);
            try
            {
                FileStream fRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                // ����ļ�����10MB�����÷ֿ���ܣ���10MB��д
                if (fRead.Length > 10 * 1024 * 1024)
                {
                    byte[] myByte = new byte[10 * 1024 * 1024 + 16]; // ���ܻ�����10MB+16�ֽ�
                    int byteRead = 10 * 1024 * 1024 + 16; // ÿ�ν��ܵ����Ĵ�С
                    long leftBytes = fRead.Length; // ʣ����Ҫ���ܵ�����С
                    long readBytes = 0; // �Ѿ���ȡ�����Ĵ�С
                    byte[] decrypt = new byte[10 * 1024 * 1024]; // ���ܺ������С

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
                        else // �����趨��ȡ���Ĵ�С�������������ֵ
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
        /// �����б��еļ�¼�������������м�Ϊ��ʷ��
        /// </summary>
        /// <param name="type">����ֵ��1Ϊ���ܣ�2Ϊ����</param>
        /// <param name="rowIndex">��ǰ����������ֵ</param>
        private void SetDGVUpdata(int type, int rowIndex)
        {
            if (type == 1)
                EncryptFileList.Rows[rowIndex].Cells[4].Value = "��";
            else
                DecryptFileList.Rows[rowIndex].Cells[4].Value = "��";
        }

        /// <summary>
        /// ��/���ܽ��ȷ���
        /// </summary>
        /// <param name="type">����ֵ��1Ϊ���ܣ�2Ϊ����</param>
        /// <param name="rowIndex">��ǰ����������ֵ</param>
        /// <param name="progress">����</param>
        private void SetOperationProgress(int type, int rowIndex, int progress)
        {
            if (type == 1)
                EncryptFileList.Rows[rowIndex].Cells[3].Value = progress + "%";
            else
                DecryptFileList.Rows[rowIndex].Cells[3].Value = progress + "%";
        }

        /// <summary>
        /// ������º���
        /// </summary>
        /// <param name="isComplete">�Ƿ���ɼ�/����</param>
        private void SetFormControl(bool isComplete)
        {
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
    }
}