
namespace HuffmanArchiverForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.ArchiveBtn = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.UnarchiveBtn = new System.Windows.Forms.Button();
            this.ArchiveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuccessMsgLabel = new System.Windows.Forms.Label();
            this.UnarchiveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Location = new System.Drawing.Point(172, 51);
            this.SelectFileBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(148, 38);
            this.SelectFileBtn.TabIndex = 0;
            this.SelectFileBtn.Text = "Выбрать файл";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Header.Location = new System.Drawing.Point(47, 9);
            this.Header.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(402, 20);
            this.Header.TabIndex = 1;
            this.Header.Text = "Кодирование файла по алгоритму Хаффмана";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PathLabel.Location = new System.Drawing.Point(180, 105);
            this.PathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(128, 20);
            this.PathLabel.TabIndex = 3;
            this.PathLabel.Text = "Путь к файлу:";
            // 
            // ArchiveBtn
            // 
            this.ArchiveBtn.Enabled = false;
            this.ArchiveBtn.Location = new System.Drawing.Point(40, 184);
            this.ArchiveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ArchiveBtn.Name = "ArchiveBtn";
            this.ArchiveBtn.Size = new System.Drawing.Size(148, 34);
            this.ArchiveBtn.TabIndex = 4;
            this.ArchiveBtn.Text = "Архивировать";
            this.ArchiveBtn.UseVisualStyleBackColor = true;
            this.ArchiveBtn.Click += new System.EventHandler(this.archiveBtn_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(27, 133);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(443, 22);
            this.PathTextBox.TabIndex = 5;
            // 
            // UnarchiveBtn
            // 
            this.UnarchiveBtn.Enabled = false;
            this.UnarchiveBtn.Location = new System.Drawing.Point(296, 184);
            this.UnarchiveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UnarchiveBtn.Name = "UnarchiveBtn";
            this.UnarchiveBtn.Size = new System.Drawing.Size(148, 34);
            this.UnarchiveBtn.TabIndex = 6;
            this.UnarchiveBtn.Text = "Разархивировать";
            this.UnarchiveBtn.UseVisualStyleBackColor = true;
            this.UnarchiveBtn.Click += new System.EventHandler(this.unarchiveBtn_Click);
            // 
            // SuccessMsgLabel
            // 
            this.SuccessMsgLabel.AutoSize = true;
            this.SuccessMsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SuccessMsgLabel.Location = new System.Drawing.Point(36, 247);
            this.SuccessMsgLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SuccessMsgLabel.Name = "SuccessMsgLabel";
            this.SuccessMsgLabel.Size = new System.Drawing.Size(0, 20);
            this.SuccessMsgLabel.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 336);
            this.Controls.Add(this.SuccessMsgLabel);
            this.Controls.Add(this.UnarchiveBtn);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.ArchiveBtn);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.SelectFileBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Button ArchiveBtn;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button UnarchiveBtn;
        private System.Windows.Forms.SaveFileDialog ArchiveFileDialog;
        private System.Windows.Forms.Label SuccessMsgLabel;
        private System.Windows.Forms.SaveFileDialog UnarchiveFileDialog;
    }
}

