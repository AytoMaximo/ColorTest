using System;
using System.Windows.Forms;
using System.IO;

namespace ColorTest
{
    public partial class Form5 : Form
    {
        public bool flag;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string monitor = "Данный монитор или устройство уже есть в БД, программа постарается использовать средние значения всех проведенных испытаний";
            textBox1.Text = monitor;
            flag = true;

            string fileName = "Repeat.txt";
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                {
                    sw.WriteLine("true");
                }
        }
    }
}
