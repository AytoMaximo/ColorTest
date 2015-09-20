using System;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace ColorTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {           

            string[] modelMon;
            string monitor;
            int n = 0;

            using (var db = new testResultContext())
            {
                int? max = db.testResult.Max(u => (int?)u.Id);

                var modelM = from b in db.testResult
                           where b.Id == max
                           select b.Model;

                modelMon = modelM.ToArray();
                monitor = modelMon[0];
            }

            chart1.Series.Add(monitor);
            chart1.Series[monitor].ChartType = SeriesChartType.SplineArea;

            using (var db = new testResultContext())
            {
                var query = from b in db.testResult where b.Model==monitor select b;
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
            foreach(string choice in listBox1.SelectedItems)
            {
                string yep = choice.ToString();
                chart1.Series.Add(yep);
                chart1.Series[yep].ChartType = SeriesChartType.SplineArea;

                using (var db = new testResultContext())
                {
                    var query = from b in db.testResult where b.Model == yep select b;
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
}
