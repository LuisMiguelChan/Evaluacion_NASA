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
            Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL CursosBal = new Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL();
            Evaluacion_NASACore.BusinessLayer.CLS_DBCATALOGOS_BAL CatalogosBal = new Evaluacion_NASACore.BusinessLayer.CLS_DBCATALOGOS_BAL();
            Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL RegistradosBal = new Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL();
            DataTable cursos = CursosBal.GetTable();
            DataTable categorias = CatalogosBal.GetTable();
            DataTable registrados = RegistradosBal.GetTable();

            Dictionary<string, int> dic = new Dictionary<string, int>();
            Dictionary<string, int> dic2 = new Dictionary<string, int>(); //pie
            Dictionary<string, decimal> dic3 = new Dictionary<string, decimal>();
            
            int cursosEcategorias;
            int registradosEcursos;
            decimal importCursos = 0;
            int numcursos = 0;
            int numcategorias = 0;

            //Chart numero 1
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            chart1.Titles.Add("REGISTROS EN CURSOS");
            
            foreach (DataRow row in cursos.Rows)
            {
                registradosEcursos = 0;
                numcursos += 1;
                foreach (DataRow row2 in registrados.Rows)
                {
                    if (Convert.ToInt32(row["num_doc"]) == Convert.ToInt32(row2["id_curso"]))
                        registradosEcursos += 1;
                }
                if (!dic.ContainsKey(row["nomcurso"].ToString()) && registradosEcursos > 0)
                {
                    dic.Add(row["nomcurso"].ToString(), registradosEcursos);
                }
            }

            foreach (var val1 in dic)
            {
                Series series = chart1.Series.Add(val1.Key);
                series.Points.Add(val1.Value);
                series.Label = (val1.Value.ToString());
            }

            textBox1.Text = numcursos.ToString();

            //Chart numero 2
            chart2.Series["Series2"].ChartType = SeriesChartType.Pie;
            chart2.Series["Series2"].BorderWidth = 5;
            chart2.Titles.Add("CURSOS EN CATEGORIA");

            foreach (DataRow row in categorias.Rows)
            {
                cursosEcategorias = 0;
                numcategorias += 1;
                foreach (DataRow row2 in cursos.Rows)
                {
                    if (Convert.ToInt32(row["id_categoria"]) == Convert.ToInt32(row2["id_categoria"]))
                        cursosEcategorias += 1;
                }
                if (!dic2.ContainsKey(row["nomcat"].ToString()) && cursosEcategorias > 0)
                {
                    dic2.Add(row["nomcat"].ToString(), cursosEcategorias);
                }
            }

            foreach (var val2 in dic2)
            {
                chart2.Series["Series2"].Points.AddXY(val2.Key,val2.Value);
            }

            textBox2.Text = numcategorias.ToString();


            //Chart numero 3
            chart3.Series["Series3"].ChartType = SeriesChartType.Column;
            chart3.Series["Series3"].BorderWidth = 5;
            chart3.Titles.Add("IMPORTE POR CURSOS");

            foreach (DataRow row in cursos.Rows)
            {
                bool ent = false;
                foreach (DataRow row2 in registrados.Rows)
                {
                    if (Convert.ToInt32(row["num_doc"]) == Convert.ToInt32(row2["id_curso"]))
                    {
                        importCursos += Convert.ToDecimal(row2["importe"]);
                        ent = true;
                    } 
                }
                if (!dic3.ContainsKey(row["nomcurso"].ToString()) && ent == true)
                {
                    dic3.Add(row["nomcurso"].ToString(), importCursos);
                }
            }

            foreach (var val3 in dic3)
            {
                Series series = chart3.Series.Add(val3.Key);
                series.Points.Add(Convert.ToInt32(val3.Value));
                series.Label = (val3.Value.ToString());
            }
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}