using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace ColorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int r, g, b;   //кодировка цвета
        int page = 1; //номер страницы
        int check = 0; //подсчет галочек на странице
        public string model;
        int x = -30; int y = 30;        
        int hue = 0; //для матрицы
        Class1[] matrix = new Class1[73];

        private void Form1_Load(object sender, EventArgs e)
        {
            string pathFull = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int n = pathFull.IndexOf("ColorTest.exe");
            string path = pathFull.Remove(n);
            pathFull = @path.Replace(@"\\", @"\");
            pathFull = pathFull.Remove(pathFull.Length-1);
            AppDomain.CurrentDomain.SetData("DataDirectory", pathFull);

            foreach (Control control in this.Controls)
                if (control is Panel)
                {
                    control.Click += new EventHandler(colorChecked);

                    if (control.Tag == "Etalon")
                    {
                        HsbToRgb(0, 1, 1, out r, out g, out b);
                        control.BackColor = Color.FromArgb(r, g, b);
                    }
                   
                        switch (control.Name)
                        {
                            case "panel1":
                                HsbToRgb(5, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel2":
                                HsbToRgb(14, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel3":
                                HsbToRgb(2, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel4":
                                HsbToRgb(26, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel5":
                                HsbToRgb(23, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                        }                  
                                   
                        switch (control.Name)
                        {
                            case "panel15":
                                HsbToRgb(8, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel14":
                                HsbToRgb(13, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel13":
                                HsbToRgb(9, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel12":
                                HsbToRgb(28, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel11":
                                HsbToRgb(20, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                        }                    
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var array = new[] { 2, 5, 10, 17, 20, -3, -8, -16, -20, -10 };
            Random rand = new Random(((int)DateTime.Now.Ticks));
            array = array.OrderBy(x => rand.Next()).ToArray();
            progressBar1.PerformStep();

            if (page < 74)
            {
                if ((page==24)||(page==49))
                {
                    Form6 timer = new Form6();
                    timer.ShowDialog();
                }

                /*Считаем поставленные галки*/
                foreach (Control control in Controls)
                    if (control is Panel)
                    {
                        foreach (Control control_check in ((Panel)control).Controls)
                            if ((control_check is CheckBox) && ((CheckBox)control_check).Checked)
                            {
                                check++;
                                ((CheckBox)control_check).Checked = false;
                            }
                    }

                matrix[page - 1] = new Class1(model, hue,check);

                    check = 0;


                /*Переход на новую страницу*/
                page++;
                label1.Text = Convert.ToString(page) + "/74";

                /*Следующий оттенок*/
                hue += 5;

                foreach (Control control in this.Controls)
                    if (control is Panel)
                    {
                        if (control.Tag == "Etalon")
                        {
                            HsbToRgb(hue, 1, 1, out r, out g, out b);
                            control.BackColor = Color.FromArgb(r, g, b);
                        }

                            if (hue < 20) x = 0; 
                            else x = -20;

                            switch (control.Name)
                            {
                                case "panel1":
                                    HsbToRgb(hue + array[0], 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel2":
                                    HsbToRgb(hue + array[1] + 10, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel3":
                                    HsbToRgb(hue + array[2] + 16, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel4":
                                    HsbToRgb(hue + array[3] + 5, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel5":
                                    HsbToRgb(hue + array[4] + 18, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                            }

                            switch (control.Name)
                            {
                                case "panel15":
                                    HsbToRgb(hue + array[5], 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel14":
                                    HsbToRgb(hue + array[6], 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel13":
                                    HsbToRgb(hue + array[7], 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel12":
                                    HsbToRgb(hue + array[8], 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel11":
                                    HsbToRgb(hue + array[9], 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                            }
                        }
                    }

            else
            {
                {
                    using (var db = new testResultContext())
                    {
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            testResult step = new testResult
                            {
                                Model = matrix[i].model,
                                Hue = matrix[i].hue,
                                Check = matrix[i].check
                            };
                            db.testResult.Add(step);
                            db.SaveChanges();
                        }
                    }
                }

                Form2 graphic = new Form2();
                graphic.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 openG = new Form2();
            openG.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {            
            Form3 modelMon = new Form3();
            modelMon.ShowDialog();
            model = modelMon.textBox1.Text;

            if (model != "")
            {
                label2.Visible = false;
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 faq = new Form4();
            faq.ShowDialog();
        }

        public void HsbToRgb(double h, double S, double V, out int r, out int g, out int b)
        {

            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            {
                R = G = B = 0;
            }

            else if (S <= 0)
            {
                R = G = B = V;
            }

            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {
                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    default:
                        R = G = B = V;
                        break;
                }
            }

            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

        private void colorChecked(object sender, EventArgs e)
        {
            foreach (Control box in this.Controls)
            {
                if (box is Panel)
                {
                    foreach (Control control_check in ((Panel)box).Controls)
                    {
                        if (box.Tag == ((Panel)sender).Tag)
                        {
                            if (((CheckBox)control_check).Checked)
                            ((CheckBox)control_check).Checked = false;
                            else ((CheckBox)control_check).Checked = true;
                        }
                    }
                }
            }
        }
    }
}
