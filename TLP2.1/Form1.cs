using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLP2._1
{
    public partial class Form1 : Form
    {
        ExecutController executControler;
        Compilator compilator;
        public Form1()
        {
            executControler = new ExecutController(new MyExecutor());
            compilator = new Compilator();
            InitializeComponent();
        }

        private void сохранитьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SaveDialog("Txt файл (*.txt)|*.txt", textBox1.Text);
            }
            else
                MessageBox.Show("Пустое поле!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void загрузитьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt файл (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBox1.Text = FileManager.LoadFile(openFileDialog.FileName);
        }

        private void программуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] registersValue = executControler.RunExecute(compilator.Compilate(textBox1.Text));
            SetRegistersValueToListBox2(registersValue);
        }

        private void отладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] registersValue = executControler.DebugExecute(compilator.Compilate(textBox1.Text));
            SetRegistersValueToListBox2(registersValue);
        }
        private void SaveDialog(string filter, string text)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {

                    if (MessageBox.Show("Файл с таким именем уже существует. Перезаписать существующий файл?",
                        "Файл существует", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        FileManager.SaveFile(saveFileDialog.FileName, text, false);
                }
                else
                    FileManager.SaveFile(saveFileDialog.FileName, text, false);
            }
        }
        private void SetRegistersValueToListBox2(int[] registersValue)
        {
            listBox2.Items.Clear();

            for (int i = 0; i < registersValue.Length; i++)
            {
                string line = "" + registersValue[i].ToString();
                listBox2.Items.Add(line);
            }
        }
        private void SetRegistersValueToListBox2(int[,] registersValue)
        {
            listBox2.Items.Clear();

            for (int i = 0; i < registersValue.GetLength(1); i++)
            {
                string line = "";
                for (int j = 0; j < registersValue.GetLength(0); j++)
                {
                    line += Convert.ToString(registersValue[j, i]) + '\t';
                }
                listBox2.Items.Add(line);
            }
        }

        //    private void textBox1_CursorChanged(object sender, EventArgs e)
        //    {
        //        string str = textBox1.Text;
        //        int cursorPosition = 0;
        //        for (int i = 0; i < str.Length; i++)
        //        {
        //            cursorPosition += (str[i] == '\n') ? 1 : 0;
        //        }
        //        label1.Text = "Текущая позиция курсора: " + cursorPosition.ToString();
        //    }        
    }
}
