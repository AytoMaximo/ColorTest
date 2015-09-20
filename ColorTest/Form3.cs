using System;
using System.Windows.Forms;
using System.Management;

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
            /*
            string Manufacture; string model;
           

            Manufacture = "SELECT MonitorType FROM Win32_DesktopMonitor";
            string result = String.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Manufacture);
            foreach (ManagementObject obj in searcher.Get())
            {
                result = obj["MonitorType"].ToString().Trim();
                textBox1.Text = result;
            }
            */

            label1.Text = "Введите модель своего" + Environment.NewLine + "монитора или ноутбука";
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}
