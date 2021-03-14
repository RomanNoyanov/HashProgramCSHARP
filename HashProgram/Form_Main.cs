using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace HashProgram
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string StrFromFile;
            try
            {           
                using (var sr = new StreamReader("TestFile.txt"))
                {                
                    StrFromFile = sr.ReadToEnd();                   
                }
                textBox_TextFromFile.Text = StrFromFile;
                textBox_HashCode.Text = GetHash(StrFromFile);
            }
            catch
            {
                MessageBox.Show("The file could not be read", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string GetHash(string input)
        {
            // создаем объект этого класса
            MD5 md5Hasher = MD5.Create();

            // Преобразуем входную строку в массив байт и вычисляем хэш
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
            StringBuilder sBuilder = new StringBuilder();

            // Преобразуем каждый байт хэша в шестнадцатеричную строку
            for (int i = 0; i < data.Length; i++)
            {
                //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();         


          
        }

        private void textBox_TextFromFile_TextChanged(object sender, EventArgs e)
        {
            string str = textBox_TextFromFile.Text;
            var a = str.ToCharArray().Select(i => Convert.ToString(i, 2));
            foreach (var ch in a)
                richTextBox.AppendText(ch + " ");



        }
    }
}
