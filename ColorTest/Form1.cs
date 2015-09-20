using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using EFlogger.EntityFramework6;

namespace ColorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EFloggerFor6.Initialize();
        }

        int r, g, b;   //кодировка цвета
        int page = 1; //номер страницы
        int check = 0; //подсчет галочек на странице
        public string model;
        int x = -30; int y = 20;

        int[,] colorMtx = new int[2, 74]; //массив соответствий оттенков и галочек 

        int hue = 0; //для матрицы

        private void Form1_Load(object sender, EventArgs e)
        { 
            Form3 modelMon = new Form3();
            modelMon.ShowDialog();
            model = modelMon.textBox1.Text;

            foreach (Control control in this.Controls)
                if (control is Panel)
                {
                    if (control.Tag == "Etalon")
                    {
                        HsbToRgb(0, 1, 1, out r, out g, out b);
                        control.BackColor = Color.FromArgb(r, g, b);
                    }

                    if (control.Tag == "Saturation")
                    {
                        switch (control.Name)
                        {
                            case "panel1":
                                HsbToRgb(2, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel2":
                                HsbToRgb(4, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel3":
                                HsbToRgb(6, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel4":
                                HsbToRgb(8, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel5":
                                HsbToRgb(10, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                        }

                    }

                    if (control.Tag == "Brightness")
                    {
                        switch (control.Name)
                        {
                            case "panel15":
                                HsbToRgb(12, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel14":
                                HsbToRgb(14, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel13":
                                HsbToRgb(16, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel12":
                                HsbToRgb(18, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                            case "panel11":
                                HsbToRgb(20, 1, 1, out r, out g, out b);
                                control.BackColor = Color.FromArgb(r, g, b);
                                break;
                        }
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (page < 74)
            {
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

                colorMtx[0, page - 1] = hue;
                colorMtx[1, page - 1] = check;

                testResult step = new testResult
                {
                    Model = model,
                    Hue = hue,
                    Check = check
                };

                {
                    using (var db = new testResultContext())
                    {
                        db.testResult.Add(step);
                        db.SaveChanges();
                    }
                }

                    check = 0;


                /*Переход на новую страницу*/
                page++;
                label1.Text = Convert.ToString(page) + "/74";

                /*Следующий оттенок*/
                hue += 5;
                Random rand = new Random(((int)DateTime.Now.Ticks));

                foreach (Control control in this.Controls)
                    if (control is Panel)
                    {
                        if (control.Tag == "Etalon")
                        {
                            HsbToRgb(hue, 1, 1, out r, out g, out b);
                            control.BackColor = Color.FromArgb(r, g, b);
                        }

                        if (control.Tag == "Saturation")
                        {
                            if (hue < 30) x = 0; else x = -30;

                            switch (control.Name)
                            {
                                case "panel1":
                                    HsbToRgb(hue + rand.Next(x, y), 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel2":
                                    HsbToRgb(hue + rand.Next(x, y) + 10, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel3":
                                    HsbToRgb(hue + rand.Next(x, y) + 16, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel4":
                                    HsbToRgb(hue + rand.Next(x, y) + 5, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel5":
                                    HsbToRgb(hue + rand.Next(x, y) + 18, 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                            }

                        }

                        if (control.Tag == "Brightness")
                        {
                            if (hue < 30) x = 0; else x = -30;

                            switch (control.Name)
                            {
                                case "panel15":
                                    HsbToRgb(hue + rand.Next(x, y), 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel14":
                                    HsbToRgb(hue + rand.Next(x, y), 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel13":
                                    HsbToRgb(hue + rand.Next(x, y), 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel12":
                                    HsbToRgb(hue + rand.Next(x, y), 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                                case "panel11":
                                    HsbToRgb(hue + rand.Next(x, y), 1, 1, out r, out g, out b);
                                    control.BackColor = Color.FromArgb(r, g, b);
                                    break;
                            }
                        }
                    }
            }

            else
            {
                Form2 graphic = new Form2();
                graphic.Show();
            }
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
    }
}
