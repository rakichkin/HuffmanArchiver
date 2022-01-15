using System;
using System.Windows.Forms;
using System.IO;

namespace HuffmanArchiverForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("aaaaa");
        }
        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.SafeFileName;

            if (GetExtension(fileName) == ".huf")
            {
                UnarchiveBtn.Enabled = true;
                ArchiveBtn.Enabled = false;
            }
            else
            {
                ArchiveBtn.Enabled = true;
                UnarchiveBtn.Enabled = false;
            }

            PathTextBox.Text = openFileDialog1.FileName;
            SuccessMsgLabel.Text = "";
        }
        private void archiveBtn_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            ArchiveFileDialog.InitialDirectory = filePath; // сохранение в той же директории

            string fileName = openFileDialog1.SafeFileName;
            ArchiveFileDialog.FileName = fileName + ".huf";
            ArchiveFileDialog.ShowDialog();

            Huffman huffman = new Huffman();
            huffman.CompressFile(openFileDialog1.FileName, ArchiveFileDialog.FileName);

            long originalFileSize = GetFileSize(openFileDialog1.FileName);
            long archivedFileSize = GetFileSize(ArchiveFileDialog.FileName);

            SuccessMsgLabel.Text = "Успешно заархивировано.\n" 
                                   + "Размер файла до архивации: " + originalFileSize + " байт\n"
                                   + "Размер файла после архивации: " + archivedFileSize + " байт";

           
        }
        private void unarchiveBtn_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            UnarchiveFileDialog.InitialDirectory = filePath;

            string fileName = openFileDialog1.SafeFileName;
            UnarchiveFileDialog.FileName = fileName + GetOriginalExtension(fileName);
            UnarchiveFileDialog.ShowDialog();

            Huffman huffman = new Huffman();
            huffman.DecompressFile(openFileDialog1.FileName, UnarchiveFileDialog.FileName);

            long archivedFileSize = GetFileSize(openFileDialog1.FileName);
            long unarchivedFileSize = GetFileSize(UnarchiveFileDialog.FileName);

            SuccessMsgLabel.Text = "Успешно разархивировано.\n"
                                   + "Размер файла до разархивации: " + archivedFileSize + " байт\n"
                                   + "Размер файла после разархивации: " + unarchivedFileSize + " байт";
        }
        private string GetExtension(string fileName)
        {
            string extension = "";
            for (int i = fileName.Length - 1; i >= 0; i--)
            {
                extension = extension.Insert(0, fileName[i].ToString());
                if (openFileDialog1.SafeFileName[i] == '.')
                    break;
            }
            return extension;
        }
        private string GetOriginalExtension(string fileName)
        {
            string originalExtension = ".";

            int index = 0;
            while (fileName[index++] != '.') ;

            while (fileName[index] != '.')
                originalExtension += fileName[index++];

            return originalExtension;
        }
        private long GetFileSize(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Length;
        }
    }
}
