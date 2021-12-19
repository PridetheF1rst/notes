using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filename = "";
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Сохраняет содержимое richTextBox1 в текстовый файл
        /// </summary>

        void SaveText(string filename)
        {
            StreamWriter f = new StreamWriter(filename, false); foreach (string s in richTextBox1.Lines) f.WriteLine(s); f.Close();
        }

        /// <summary>
        /// Выводит короткое имя файла без расширения в заголовок текущего окна
        /// </summary>
        void Rename(string filename)
        {
            string s = new FileInfo(filename).Name.ToString(); s = s.Remove(s.Length - 4);
            this.Text = s + " – Блокнот";
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear(); filename = "";
            this.Text = "Безымянный – Блокнот";
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt",
            };
            DialogResult res = ofd.ShowDialog(); if (res != DialogResult.OK) return; filename = ofd.FileName; Rename(filename);
            StreamReader f = new StreamReader(filename); richTextBox1.Text = f.ReadToEnd();
            f.Close();

        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (filename == "")
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Текстовые файлы (*.txt)|*.txt",
                };
                DialogResult res = sfd.ShowDialog(); if (res != DialogResult.OK) return; filename = sfd.FileName; Rename(filename);
            }
            SaveText(filename);

        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt",
            };
            DialogResult res = sfd.ShowDialog(); if (res != DialogResult.OK) return; filename = sfd.FileName; SaveText(filename); Rename(filename);

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void стеретьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Clear(); 
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void mnuFile_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Исходный код программы вы можете найти по ссылке \n ","О программе" , MessageBoxButtons.OK);
        }
    }
}
