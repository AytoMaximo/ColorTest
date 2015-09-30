using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTest
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        int i = 30;

        private void Form6_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            if (i > 0)
                label3.Text = i.ToString();
            else
                this.Close();
        }
    }
}
