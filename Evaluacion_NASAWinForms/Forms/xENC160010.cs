using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Evaluacion_NASAWinForms.Forms
{
    public partial class xENC160010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENC160010()
        {
            InitializeComponent();
        }

        private void xENC160010_Load(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            chart1.Series["Series1"].BorderWidth = 5;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("Angular",20);
            dic.Add("Consoft",15);
            dic.Add("CONSOFT2",15);

            foreach (KeyValuePair<string, int> d in dic)
            {
                chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
            }
        }
    }
}