using System;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace ColorTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string monitor;
        int n = 0;

        private void Form2_Load(object sender, EventArgs e)
        {

            string[] modelMon;

            bool chFlag = false;

            string[] allText = File.ReadAllLines("Repeat.txt");
            chFlag = Convert.ToBoolean(allText.First());

            using (var db = new testResultContext())
            {
                int max = (from b in db.testResult select b.Id).Max();

                var modelM = from b in db.testResult
                             where b.Id == max
                             select b.Model;

                modelMon = modelM.ToArray();
                monitor = modelMon[0];
            }



            using (var db = new testResultContext())
            {
                var query = from b in db.testResult where b.Model == monitor select b;

                if (chFlag)
                {
                    repeatMonitor(monitor);
                }

                else
                {
                    chart1.Series.Add(monitor);
                    chart1.Series[monitor].ChartType = SeriesChartType.SplineArea;
                    foreach (var item in query)
                    {
                        switch (item.Check)
                        {
                            case 0:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 30);
                                break;
                            case 1:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 25);
                                break;
                            case 2:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 14);
                                break;
                            case 3:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 12);
                                break;
                            case 4:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 10);
                                break;
                            case 5:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 8);
                                break;
                            case 6:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 6);
                                break;
                            case 7:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 5);
                                break;
                            case 8:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 2);
                                break;
                            case 9:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 1);
                                break;
                            case 10:
                                chart1.Series[monitor].Points.AddXY(item.Hue, 0);
                                break;
                        }

                    }
                }
            }

            using (var db = new testResultContext())
            {
                var models = from b in db.testResult select b.Model;
                foreach (var item_model in models.Distinct())
                {
                    listBox1.Items.Add(item_model.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string choice in listBox1.SelectedItems)
            {
                string yep = choice.ToString();

                using (var db = new testResultContext())
                {
                    var query = from b in db.testResult where b.Model == yep select b;
                    if (query.Count() > 73)
                    {
                        repeatMonitor(yep);
                    }

                    else
                    {
                        chart1.Series.Add(yep);
                        chart1.Series[yep].ChartType = SeriesChartType.SplineArea;

                        foreach (var item in query)
                        {
                            switch (item.Check)
                            {
                                case 0:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 30);
                                    break;
                                case 1:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 25);
                                    break;
                                case 2:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 14);
                                    break;
                                case 3:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 12);
                                    break;
                                case 4:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 10);
                                    break;
                                case 5:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 8);
                                    break;
                                case 6:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 6);
                                    break;
                                case 7:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 5);
                                    break;
                                case 8:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 2);
                                    break;
                                case 9:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 1);
                                    break;
                                case 10:
                                    chart1.Series[yep].Points.AddXY(item.Hue, 0);
                                    break;
                            }

                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
        }

        private void repeatMonitor(string monic)
        {
            chart1.Series.Add(monic);
            chart1.Series[monic].ChartType = SeriesChartType.SplineArea;

            int sum = 0;
            using (var db = new testResultContext())
            {
                for (int i = 0; i <= 360; i += 5)
                {
                    var stat = from b in db.testResult where b.Model == monic where b.Hue == i select b;
                    int len = stat.Count();
                    foreach (var item in stat)
                    {
                        sum += item.Check.Value;
                    }
                    sum = sum / len;

                    switch (sum)
                    {
                        case 0:
                            chart1.Series[monic].Points.AddXY(i, 30);
                            break;
                        case 1:
                            chart1.Series[monic].Points.AddXY(i, 25);
                            break;
                        case 2:
                            chart1.Series[monic].Points.AddXY(i, 14);
                            break;
                        case 3:
                            chart1.Series[monic].Points.AddXY(i, 12);
                            break;
                        case 4:
                            chart1.Series[monic].Points.AddXY(i, 10);
                            break;
                        case 5:
                            chart1.Series[monic].Points.AddXY(i, 8);
                            break;
                        case 6:
                            chart1.Series[monic].Points.AddXY(i, 6);
                            break;
                        case 7:
                            chart1.Series[monic].Points.AddXY(i, 5);
                            break;
                        case 8:
                            chart1.Series[monic].Points.AddXY(i, 2);
                            break;
                        case 9:
                            chart1.Series[monic].Points.AddXY(i, 1);
                            break;
                        case 10:
                            chart1.Series[monic].Points.AddXY(i, 0);
                            break;

                    }

                    sum = 0;
                }
            }
        }
    }
}