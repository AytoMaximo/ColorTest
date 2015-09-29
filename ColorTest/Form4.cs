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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Перед вами программа, которая может определить чувствительность зрительной системы испытуемого к изменению цветого тона на конкретно заданном мониторе или устройстве. Пользователю будет предложено 72 различных оттенков всего цветового спектра, которые надо будет сравнить с другими и отметить отличия. Эталонный оттенок реализован в центральном ряде, а в верхнем и нижнем рядах находятся как раз те оттенки, которые надо отметить как отличающиеся от эталонного. Во время тестирования будет предложен два раза отдых по 1 минуте. В конце вам будет выведен график, отображающий результаты тестирования. Также вы сможете сравнить получившиеся результаты с предыдущими, выполненными на других устройствах и мониторах.";
        }
    }
}
