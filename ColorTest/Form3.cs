using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace ColorTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Введите модель своего" + Environment.NewLine + "монитора или ноутбука";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                using (var db = new testResultContext())
                {

                    var modelAll = from b in db.testResult select b.Model;

                    var models = modelAll.Distinct();

                    if (models.Contains(textBox1.Text))
                    {
                        Form5 message = new Form5();
                        message.ShowDialog();
                    }
                    else
                    {
                        File.Delete("Repeat.txt");
                    }
                }

                this.Close();
            }

            else
            {
                button1.Enabled = false;
                label2.Visible = true;
                label2.Text = "Поле не может быть пустым!";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
