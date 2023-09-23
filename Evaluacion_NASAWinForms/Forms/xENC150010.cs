using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_NASAWinForms.Forms
{
    public partial class xENC150010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENC150010()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Corte(DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text));

            dataGridView1.DataSource = dt;

            decimal Total = 0;

            foreach (DataRow row in dt.Rows)
            {
                Total += Convert.ToDecimal(row["importe"]);
            }
            textBox1.Text = Total.ToString();
        }

        private void xENC150010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
        }
        public DataTable Corte(DateTime Fecha1, DateTime Fecha2)
        {

            string sql = "filtro";

            SqlConnection cn = new SqlConnection(NASA.PROCNASA.GLOBAL.CONFIG.SystemConnectionString);

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Fecha1", Fecha1);

            cmd.Parameters.AddWithValue("@Fecha2", Fecha2);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            cn.Open();

            da.Fill(dt);

            cn.Close();

            return dt;

        }
    }
}
